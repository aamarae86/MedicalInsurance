using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System._ArPdcInterface.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ERP._System._ArPdcInterface
{
    [AbpAuthorize]
    public class ArPdcInterfaceAppService : AsyncCrudAppService<ArPdcInterface, ArPdcInterfaceDto, long, PagedArPdcInterfaceResultRequestDto, ArPdcInterfaceDto, ArPdcInterfaceEditDto>
        , IArPdcInterfaceAppService
    {
        private readonly IArPdcInterfaceRepository _repoForProcedure;

        public ArPdcInterfaceAppService(IRepository<ArPdcInterface, long> repository, IArPdcInterfaceRepository repoForStored
               ) : base(repository)
        {
            _repoForProcedure = repoForStored;

            UpdatePermissionName = PermissionNames.Pages_ArPdcInterface_Update;
            GetAllPermissionName = PermissionNames.Pages_ArPdcInterface;
        }

        public override Task<ArPdcInterfaceDto> Create(ArPdcInterfaceDto input) => throw new UserFriendlyException("Invalid!!!");

        public override Task Delete(EntityDto<long> input) => throw new UserFriendlyException("Invalid!!!");

        public async override Task<ArPdcInterfaceDto> Update(ArPdcInterfaceEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            DateTime? maturityDate = string.IsNullOrEmpty(input.MaturityDate) ? (DateTime?)null : DateTimeController.ConvertToDateTime(input.MaturityDate);

            current.SetNeededUpdatedData(input.Notes, (input.DepositBankAccountId == 0 ? null : input.DepositBankAccountId), maturityDate);

            await Repository.UpdateAsync(current);

            return new ArPdcInterfaceDto();
        }

        public async Task<ArPdcInterfaceDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValuesSourceCodeLkp, z => z.FndLookupValuesStatusLkp, z => z.FndLookupValuesBankLkp, z => z.ApBankAccounts, z => z.ArCustomers, z => z.DepositApBankAccounts)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<ArPdcInterfaceDto>(current);
        }

        public async override Task<PagedResultDto<ArPdcInterfaceDto>> GetAll(PagedArPdcInterfaceResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.FndLookupValuesSourceCodeLkp, z => z.FndLookupValuesStatusLkp, z => z.FndLookupValuesBankLkp, z => z.ApBankAccounts, z => z.ArCustomers);

            if (input.Params != null && input.Params.Amount != 0 && input.Params.Amount != null)
                queryable = queryable.Where(q => q.Amount == input.Params.Amount);
          
            if (input.Params != null && input.Params.BankAccountId != 0 && input.Params.BankAccountId != null)
                queryable = queryable.Where(q => q.BankAccountId == input.Params.BankAccountId);
           
            if (input.Params != null && input.Params.CheckNumber != null)
                queryable = queryable.Where(q => q.CheckNumber == input.Params.CheckNumber);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
            {
                var dtFrom = DateTimeController.ConvertToDateTime(input.Params.FromDate);

                queryable = queryable.Where(q => q.MaturityDate >= dtFrom);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
            {
                var dtTo = DateTimeController.ConvertToDateTime(input.Params.ToDate);

                queryable = queryable.Where(q => q.MaturityDate <= dtTo);
            }

            if (input.Params != null && input.Params.StatusLkpId != 0 && input.Params.StatusLkpId != null)
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);


            var totalAmount = queryable.Select(x => x.Amount).Sum();
            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
          
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
          
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArPdcInterfaceDto>());

            data2[0].TotalAmount = totalAmount;

            var PagedResultDto = new PagedResultDto<ArPdcInterfaceDto>()
            {
                Items = data2 as IReadOnlyList<ArPdcInterfaceDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<PostOutput> PostArPdcInterface(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoForProcedure.Execute(input, "CmPostArPdc");

            return postResult.FirstOrDefault();
        }

        public async Task<PostOutput> RetrieveArPdcInterface(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoForProcedure.Execute(input, "CmReverseArPdc");

            return postResult.FirstOrDefault();
        }
    }
}

using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System._ApPdcInterface.Dto;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._ApPdcInterface
{
    [AbpAuthorize]
    public class ApPdcInterfaceAppService : AsyncCrudAppService<ApPdcInterface, ApPdcInterfaceDto, long, PagedApPdcInterfaceResultRequestDto, CreateApPdcInterfaceDto, ApPdcInterfaceEditDto>,
        IApPdcInterfaceAppService
    {
        private readonly IApPdcInterfaceRepository _repoForProcedure;

        public ApPdcInterfaceAppService(IRepository<ApPdcInterface, long> repository, IApPdcInterfaceRepository repoForStored)
            : base(repository)
        {
            _repoForProcedure = repoForStored;

            CreatePermissionName = PermissionNames.Pages_ApPdcInterface_Insert;
            UpdatePermissionName = PermissionNames.Pages_ApPdcInterface_Update;
            DeletePermissionName = PermissionNames.Pages_ApPdcInterface_Delete;
            GetAllPermissionName = PermissionNames.Pages_ApPdcInterface;
        }

        public async override Task<ApPdcInterfaceDto> Update(ApPdcInterfaceEditDto input)
        {
            CheckUpdatePermission();

            var current = await Repository.GetAsync(input.Id);

            current.UpdateData(input.MaturityDate, input.ChqReturnResonLKPId, input.Notes);

            await Repository.UpdateAsync(current);

            return new ApPdcInterfaceDto();
        }

        public async Task<ApPdcInterfaceDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValuesSourceCodeLkp, z => z.FndLookupValuesStatusLkp, z => z.ApBankAccounts, z => z.FndLookupValuesChqReturnResonLKP)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<ApPdcInterfaceDto>(current);

            return mapped;
        }

        public async override Task<PagedResultDto<ApPdcInterfaceDto>> GetAll(PagedApPdcInterfaceResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(z => z.FndLookupValuesSourceCodeLkp, z => z.FndLookupValuesStatusLkp, z => z.ApBankAccounts, z => z.FndLookupValuesChqReturnResonLKP);

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
            {
                queryable = queryable.Where(q => q.StatusLkpId == input.Params.StatusLkpId);
            }

            var count = await queryable.CountAsync();

            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };

            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);

            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var totalAmount = queryable.Select(x => x.Amount).Sum();

            var data2 = ObjectMapper.Map(data, new List<ApPdcInterfaceDto>());

            if (data2 != null && data2.Count != 0)
                data2[0].TotalAmount = totalAmount;

            var PagedResultDto = new PagedResultDto<ApPdcInterfaceDto>()
            {
                Items = data2 as IReadOnlyList<ApPdcInterfaceDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<PostOutput> PostApPdcInterface(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoForProcedure.Execute(input, "CmPostApPdc");

            return postResult.FirstOrDefault();
        }

        public async Task<PostOutput> RetrieveApPdcInterface(PostDto input)
        {
            if (AbpSession.UserId.HasValue) { input.UserId = AbpSession.UserId.Value; }

            var postResult = await _repoForProcedure.Execute(input, "CmReverseApPdc");

            return postResult.FirstOrDefault();
        }
    }
}

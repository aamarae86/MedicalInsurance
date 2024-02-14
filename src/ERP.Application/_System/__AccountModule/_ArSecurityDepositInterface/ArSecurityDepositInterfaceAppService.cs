using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using ERP._System.__AccountModule._ArSecurityDepositInterface;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Dto;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Input;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Output;
using ERP._System.__HR._HrPersonsAdditionHd.Proc;
using ERP._System._ArSecurityDepositInterface.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Core.Helpers.Extensions;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._ArSecurityDepositInterface
{
    [AbpAuthorize]
    public class ArSecurityDepositInterfaceAppService : AsyncCrudAppService<ArSecurityDepositInterface, ArSecurityDepositInterfaceDto, long, PagedArSecurityDepositInterfaceResultRequestDto, CreateArSecurityDepositInterfaceDto, ArSecurityDepositInterfaceEditDto>,
          IArSecurityDepositInterfaceAppService
    {
        private readonly IArSecurityDepositInterfaceManager _arSecurityDepositInterfaceManager;
        private readonly IHrPersonsAdditionPostRepository _hrPersonsAdditionPostRepository;
        private readonly IGetArSecurityDepositInterfaceScreenDataRepository _getArSecurityDepositInterfaceScreenDataRepository;

        public ArSecurityDepositInterfaceAppService(IRepository<ArSecurityDepositInterface, long> repository,
            IArSecurityDepositInterfaceManager arSecurityDepositInterfaceManager,
            IGetArSecurityDepositInterfacerptRepository getArSecurityDepositInterfacerptRepository,
            IHrPersonsAdditionPostRepository hrPersonsAdditionPostRepository,
            IGetArSecurityDepositInterfaceScreenDataRepository getArSecurityDepositInterfaceScreenDataRepository) : base(repository)
        {
            _getArSecurityDepositInterfaceScreenDataRepository = getArSecurityDepositInterfaceScreenDataRepository;
            _hrPersonsAdditionPostRepository = hrPersonsAdditionPostRepository;
            _arSecurityDepositInterfaceManager = arSecurityDepositInterfaceManager;
        }

        public override Task<ArSecurityDepositInterfaceDto> Create(CreateArSecurityDepositInterfaceDto input)
            => throw new UserFriendlyException("Invalid");

        public override Task<ArSecurityDepositInterfaceDto> Update(ArSecurityDepositInterfaceEditDto input)
            => throw new UserFriendlyException("Invalid");

        public override Task Delete(EntityDto<long> input) => throw new UserFriendlyException("Invalid");

        public async override Task<PagedResultDto<ArSecurityDepositInterfaceDto>> GetAll(PagedArSecurityDepositInterfaceResultRequestDto input)
        {
            CheckGetAllPermission();

            var queryable = Repository.GetAllIncluding(x => x.FndStatusLkp, x => x.FndSourceCodeLkp, x => x.ArCustomers)
                                      .Where(q => q.StatusLkpId == input.Params.StatusLkpId);

            if (input.Params != null && input.Params.SourceCodeLkpId != null)
                queryable = queryable.Where(q => q.SourceCodeLkpId == input.Params.SourceCodeLkpId);

            if (input.Params != null && input.Params.ArCustomerId != null)
                queryable = queryable.Where(q => q.ArCustomerId == input.Params.ArCustomerId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.FromDate))
            {
                DateTime dtFrom = (DateTime)DateTimeController.ConvertToDateTime(input.Params.FromDate);

                queryable = queryable.Where(q => dtFrom <= q.CreationTime);
            }

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ToDate))
            {
                DateTime dtTo = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ToDate);

                queryable = queryable.Where(q => dtTo >= q.CreationTime);
            }


            var count = await queryable.CountAsync();
            var listOrder = new List<SortModel> { new SortModel { Sort = input.OrderByValue.Sort, ColId = input.OrderByValue.ColId } };
            queryable = queryable.DynamicOrderBy(listOrder);
            queryable = queryable.Skip(input.SkipCount);
            var data = await queryable.Take(input.MaxResultCount).ToListAsync();

            var data2 = ObjectMapper.Map(data, new List<ArSecurityDepositInterfaceDto>());

            var PagedResultDto = new PagedResultDto<ArSecurityDepositInterfaceDto>()
            {
                Items = data2 as IReadOnlyList<ArSecurityDepositInterfaceDto>,
                TotalCount = count
            };

            return PagedResultDto;
        }

        public async Task<ArSecurityDepositInterfaceDto> GetDetailAsync(EntityDto<long> input)
        {
            var currentENtity = await Repository
                .GetAllIncluding(x => x.FndSourceCodeLkp, x => x.FndStatusLkp, x => x.ArCustomers)
                .Where(z => z.Id == input.Id)
                .FirstOrDefaultAsync();

            return ObjectMapper.Map(currentENtity, new ArSecurityDepositInterfaceDto());
        }

        public async Task<(string text, long id)> GetNewArSecurityDepositInterfaceStatusSelect2Option()
        {
            var newStatusLkpId = Convert.ToInt64(FndEnum.FndLkps.New_ArSecurityDepositInterfaceStatus);

            var data = await _arSecurityDepositInterfaceManager.GetNewArSecurityDepositInterfaceStatusSelect2Option(newStatusLkpId);

            return (data.text, data.id);
        }

        public async Task<List<GetArSecurityDepositInterfaceScreenDataOutput>> GetArSecurityDepositInterfaceScreenData(IdLangInputDto postDto)
        {
            var result = await _getArSecurityDepositInterfaceScreenDataRepository.Execute(postDto, "GetArSecurityDepositInterfaceScreenData");

            return result.ToList();
        }

        public async Task<PostOutput> PostArSecurityDepositInterface(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _hrPersonsAdditionPostRepository.Execute(postDto, "ArSecurityDepositInterfacePost");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> TransferArSecurityDepositInterface(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId ?? 0;

            var result = await _hrPersonsAdditionPostRepository.Execute(postDto, "ArSecurityDepositInterfaceTransfer");

            return result.FirstOrDefault();
        }

        
    }
}

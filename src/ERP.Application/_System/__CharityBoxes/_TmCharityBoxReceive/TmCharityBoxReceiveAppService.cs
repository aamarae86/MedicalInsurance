using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CharityBoxes._TmCharityBoxReceive.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxReceive
{
    [AbpAuthorize]
    public class TmCharityBoxReceiveAppService : AsyncCrudAppService<TmCharityBoxReceive, TmCharityBoxReceiveDto, long, PagedTmCharityBoxReceiveResultRequestDto, CreateTmCharityBoxReceiveDto, TmCharityBoxReceiveEditDto>,
        ITmCharityBoxReceiveAppService
    {
        private readonly ITmCharityBoxReceiveRepository _repoPost;
        private readonly IGetCounterRepository _repoProcCounter;

        public TmCharityBoxReceiveAppService(IRepository<TmCharityBoxReceive, long> repository,
            ITmCharityBoxReceiveRepository repoPost, IGetCounterRepository repoProcCounter) : base(repository)
        {
            _repoPost = repoPost;
            _repoProcCounter = repoProcCounter;

            CreatePermissionName = PermissionNames.Pages_TmCharityBoxReceive_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmCharityBoxReceive_Update;
            DeletePermissionName = PermissionNames.Pages_TmCharityBoxReceive_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmCharityBoxReceive;
        }

        public async Task<TmCharityBoxReceiveDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues, z => z.CharityBoxesType)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<TmCharityBoxReceiveDto>(current);
        }

        public async override Task<TmCharityBoxReceiveDto> Create(CreateTmCharityBoxReceiveDto input)
        {
            CheckCreatePermission();

            input.ReceiveNumber = await GetCharityBoxReceiveNumber();

            return await base.Create(input);
        }

        protected override IQueryable<TmCharityBoxReceive> CreateFilteredQuery(PagedTmCharityBoxReceiveResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.FndLookupValues, z => z.CharityBoxesType);

            if (input.Params.CharityTypeId.HasValue && input.Params.CharityTypeId.Value > 0)
                iqueryable = iqueryable.Where(z => z.CharityTypeId == input.Params.CharityTypeId);

            if (input.Params.StatusLkpIdSearch.HasValue && input.Params.StatusLkpIdSearch.Value > 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpIdSearch);

            if (!string.IsNullOrEmpty(input.Params.ReceiveNumber))
                iqueryable = iqueryable.Where(z => z.ReceiveNumber == input.Params.ReceiveNumber);

            if (!string.IsNullOrEmpty(input.Params.ReceiveDateFrom))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ReceiveDateFrom);
                iqueryable = iqueryable.Where(z => z.ReceiveDate >= dt);
            }

            if (!string.IsNullOrEmpty(input.Params.ReceiveDateTo))
            {
                DateTime dt = (DateTime)DateTimeController.ConvertToDateTime(input.Params.ReceiveDateTo);
                iqueryable = iqueryable.Where(z => z.ReceiveDate <= dt);
            }

            return iqueryable;
        }

        public async Task<PostOutput> PostTmCharityBoxReceive(PostDto idLangInputDto)
        {
            var result = await _repoPost.Execute(idLangInputDto, "TmCharityBoxReceivePost");

            return result.FirstOrDefault();
        }

        private async Task<string> GetCharityBoxReceiveNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "TmCharityBoxReceive", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}

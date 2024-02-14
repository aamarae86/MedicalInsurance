using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__CharityBoxes._TmCharityBoxCollectMembers.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollectMembers
{
    [Abp.Authorization.AbpAuthorize]
    public class TmCharityBoxCollectMembersAppService : AsyncCrudAppService<TmCharityBoxCollectMembers, TmCharityBoxCollectMembersDto, long, PagedTmCharityBoxCollectMembersResultRequestDto, TmCharityBoxCollectMembersCreateDto, TmCharityBoxCollectMembersEditDto>,
        ITmCharityBoxCollectMembersAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly ITmCharityBoxCollectMembersManager _tmCharityBoxCollectMembersManager;

        public TmCharityBoxCollectMembersAppService(ITmCharityBoxCollectMembersManager tmCharityBoxCollectMembersManager,
            IRepository<TmCharityBoxCollectMembers, long> repository,
            IGetCounterRepository getCounterRepository) : base(repository)
        {
            _tmCharityBoxCollectMembersManager = tmCharityBoxCollectMembersManager;
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_TmCharityBoxCollectMembers_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmCharityBoxCollectMembers_Update;
            DeletePermissionName = PermissionNames.Pages_TmCharityBoxCollectMembers_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmCharityBoxCollectMembers;
        }

        protected override IQueryable<TmCharityBoxCollectMembers> CreateFilteredQuery(PagedTmCharityBoxCollectMembersResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndMemberCategoryValues);

            if (input.Params != null && input.Params.MemberCategoryLkpId.HasValue && input.Params.MemberCategoryLkpId.Value > 0)
                iqueryable = iqueryable.Where(z => z.MemberCategoryLkpId == input.Params.MemberCategoryLkpId);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MemberNumber))
                iqueryable = iqueryable.Where(z => z.MemberNumber.Contains(input.Params.MemberNumber));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.MemberName))
                iqueryable = iqueryable.Where(z => z.MemberName.Contains(input.Params.MemberName));

            return iqueryable;
        }

        public async override Task<TmCharityBoxCollectMembersDto> Create(TmCharityBoxCollectMembersCreateDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "TmCharityBoxCollectMembers", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            input.MemberNumber = result?.FirstOrDefault()?.OutputStr ?? "0";

            return await base.Create(input);
        }

        public async Task<TmCharityBoxCollectMembersDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository
                .GetAllIncluding(z => z.FndMemberCategoryValues)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<TmCharityBoxCollectMembersDto>(current);
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _tmCharityBoxCollectMembersManager.GetSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}

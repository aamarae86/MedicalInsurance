using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CharityBoxes._TmLocations.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmLocations
{
    [AbpAuthorize]
    public class TmLocationsAppService : AsyncCrudAppService<TmLocations, TmLocationsDto, long, PagedTmLocationsResultRequestDto, CreateTmLocationsDto, TmLocationsEditDto>, ITmLocationsAppService
    {
        private readonly IRepository<TmLocationSub, long> _repoDetail;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly ITmLocationSubManager _tmLocationSubManager;

        public TmLocationsAppService(IRepository<TmLocations, long> repository,
                 IRepository<TmLocationSub, long> repoDetail,
                 IGetCounterRepository repoProcCounter,
                 ITmLocationSubManager tmLocationSubManager) : base(repository)
        {
            _repoDetail = repoDetail;
            _repoProcCounter = repoProcCounter;
            _tmLocationSubManager = tmLocationSubManager;

            CreatePermissionName = PermissionNames.Pages_TmLocations_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmLocations_Update;
            DeletePermissionName = PermissionNames.Pages_TmLocations_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmLocations;
        }

        public async Task<TmLocationsDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.Region.FndLookupValues, z => z.LocationSubs)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<TmLocationsDto>(current);

            return mapped;
        }

        public async override Task<TmLocationsDto> Create(CreateTmLocationsDto input)
        {
            CheckCreatePermission();

            input.LocationNumber = await GetNumberFor(nameof(TmLocations));

            var location = await base.Create(input);

            if (input.InputCollection?.Count > 0)
                foreach (var item in input.InputCollection)
                {
                    item.LocationId = location.Id;
                    item.TmLocationSubNumber = await GetNumberFor(nameof(TmLocationSub));
                    var tmLocationSub = ObjectMapper.Map<TmLocationSub>(item);

                    _ = await _repoDetail.InsertAsync(tmLocationSub);
                }

            return location;
        }

        public async override Task<TmLocationsDto> Update(TmLocationsEditDto input)
        {
            CheckUpdatePermission();

            var Entity = await Repository.FirstOrDefaultAsync(input.Id);

            ObjectMapper.Map(input, Entity);

            if (input.InputCollection?.Count > 0)
            {
                foreach (var item in input.InputCollection)
                {
                    item.LocationId = input.Id;

                    if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Updated.ToString())
                    {

                        var tmLocationSub = await _repoDetail.GetAsync((long)item.Id);

                        var mapped = ObjectMapper.Map(item, tmLocationSub);

                        _ = await _repoDetail.UpdateAsync(tmLocationSub);

                    }
                    else if (item.rowStatus == DetailRowStatus.RowStatus.New.ToString())
                    {
                        item.TmLocationSubNumber = await GetNumberFor(nameof(TmLocationSub));
                        var tmLocationSub = ObjectMapper.Map<TmLocationSub>(item);

                        _ = await _repoDetail.InsertAsync(tmLocationSub);
                    }
                    else if (item.Id != 0 && item.rowStatus == DetailRowStatus.RowStatus.Deleted.ToString())
                    {
                        await _repoDetail.DeleteAsync(item.Id);
                    }
                }
            }
            return MapToEntityDto(await Repository.UpdateAsync(Entity));
        }

        protected override IQueryable<TmLocations> CreateFilteredQuery(PagedTmLocationsResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(l => l.Region.FndLookupValues);
            if (!string.IsNullOrEmpty(input.Params.LocationName))
            {
                iqueryable = iqueryable.Where(l => l.LocationName.Contains(input.Params.LocationName));
            }
            if (!string.IsNullOrEmpty(input.Params.LocationNumber))
            {
                iqueryable = iqueryable.Where(l => l.LocationNumber.Contains(input.Params.LocationNumber));
            }
            if (input.Params.RegionId.HasValue && input.Params.RegionId.Value > 0)
            {
                iqueryable = iqueryable.Where(l => l.RegionId == input.Params.RegionId.Value);
            }
            return iqueryable;
        }

        public async Task<bool> GetExistLocationNameAsync(string input, string Id)
        {
            var current = await Repository.GetAll()
                .Where(x => x.LocationName.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<bool> GetExistSubLocationNameAsync(string input, string Id)
        {
            var current = await _repoDetail.GetAll()
                .Where(x => x.TmLocationSubName.ToLower() == input.ToLower() && x.Id.ToString() != Id).FirstOrDefaultAsync();

            return current != null;
        }

        public async Task<Select2PagedResult> GetSubLoactionForBoxesSelect2(long actionLkpId, string searchTerm, int pageSize, int pageNumber, string lang)
              => await _tmLocationSubManager.GetLoactionForBoxesSelect2(actionLkpId, searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetTmLocationSubSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _tmLocationSubManager.GetTmLocationSubSelect2(searchTerm, pageSize, pageNumber, lang);

        public async Task<Select2PagedResult> GetTmLocationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
            => await _tmLocationSubManager.GetTmLocationsSelect2(searchTerm, pageSize, pageNumber, lang);

        private async Task<string> GetNumberFor(string tableName, string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = tableName, TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result?.FirstOrDefault()?.OutputStr ?? "0";
        }
    }
}

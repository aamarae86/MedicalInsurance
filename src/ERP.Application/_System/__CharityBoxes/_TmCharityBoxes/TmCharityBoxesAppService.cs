using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CharityBoxes._TmCharityBoxes.Dto;
using ERP._System._Counters.Procs;
using ERP._System._FndLookupValues;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__CharityBoxes._TmCharityBoxes
{
    [AbpAuthorize]
    public class TmCharityBoxesAppService : AsyncCrudAppService<TmCharityBoxes, TmCharityBoxesDto, long, PagedTmCharityBoxesResultRequestDto, CreateTmCharityBoxesDto, TmCharityBoxesEditDto>,
        ITmCharityBoxesAppService
    {
        private readonly ITmCharityBoxesManager _tmCharityBoxesManager;
        private readonly ITmCharityBoxesRepository _repoPost;
        public TmCharityBoxesAppService(IRepository<TmCharityBoxes, long> repository, IRepository<FndLookupValues, long> cityLkpRepo,
            ITmCharityBoxesManager TmCharityBoxesManager,
            ITmCharityBoxesRepository repoPost) : base(repository)
        {
            _tmCharityBoxesManager = TmCharityBoxesManager;
            _repoPost = repoPost;

            CreatePermissionName = PermissionNames.Pages_TmCharityBoxes_Insert;
            UpdatePermissionName = PermissionNames.Pages_TmCharityBoxes_Update;
            DeletePermissionName = PermissionNames.Pages_TmCharityBoxes_Delete;
            GetAllPermissionName = PermissionNames.Pages_TmCharityBoxes;
        }

        public async Task<TmCharityBoxesDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAllIncluding(z => z.FndLookupValues, z => z.CharityBoxesType, z => z.TmSupervisor, z => z.TmSubLocation.TmLocation.Region.FndLookupValues)
                .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            var mapped = ObjectMapper.Map<TmCharityBoxesDto>(current);

            return mapped;
        }

        public override Task<TmCharityBoxesDto> Create(CreateTmCharityBoxesDto input)
           => throw new NotImplementedException("Invalid~!!");

        public override Task<TmCharityBoxesDto> Update(TmCharityBoxesEditDto input)
          => throw new NotImplementedException("Invalid~!!");

        protected override IQueryable<TmCharityBoxes> CreateFilteredQuery(PagedTmCharityBoxesResultRequestDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.FndLookupValues, z => z.CharityBoxesType, z => z.TmSupervisor, z => z.TmSubLocation.TmLocation.Region.FndLookupValues);

            if (input.Params.CharityTypeId.HasValue && input.Params.CharityTypeId.Value > 0)
                iqueryable = iqueryable.Where(z => z.CharityTypeId == input.Params.CharityTypeId);

            if (input.Params.StatusLkpIdSearch.HasValue && input.Params.StatusLkpIdSearch.Value > 0)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusLkpIdSearch);

            if (!string.IsNullOrEmpty(input.Params.CharityBoxName))
                iqueryable = iqueryable.Where(z => z.CharityBoxName.Contains(input.Params.CharityBoxName) || z.CharityBoxNumber.Contains(input.Params.CharityBoxName));

            if (!string.IsNullOrEmpty(input.Params.CharityBoxBarcode))
                iqueryable = iqueryable.Where(z => z.CharityBoxBarcode == input.Params.CharityBoxBarcode);

            return iqueryable;
        }

        public async Task<List<TransOutput>> GetTmCharityBoxesTrans(PostDto idLangInputDto)
        {
            var result = await _repoPost.Execute(idLangInputDto, "GetTmCharityBoxesTrans");

            return result.ToList();
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang, long? statuslkpId = null)
            => await _tmCharityBoxesManager.GetSelect2(searchTerm, pageSize, pageNumber, lang, statuslkpId);

        public async Task<(long id, string text)> GetCharityBoxByLocation(long locationsubId)
            => await _tmCharityBoxesManager.GetCharityBoxByLocation(locationsubId);
    }
}

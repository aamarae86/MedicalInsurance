using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__AccountModule._FaAssetDeprn;
using ERP._System.__AccountModule._FaAssetDeprn.Dto;
using ERP._System.__AccountModule._FaAssetDeprn.Proc;
using ERP._System.__AccountModuleExtend._FaAssets;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System._GlCodeComDetails;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._FaAssetDeprnHdDeprn
{
    [AbpAuthorize]
    public class FaAssetDeprnHdAppService : AsyncCrudAppService<FaAssetDeprnHd, FaAssetDeprnHdDto, long, FaAssetDeprnHdPagedDto, FaAssetDeprnHdCreateDto, FaAssetDeprnHdEditDto>
        , IFaAssetDeprnHdAppService
    {
        private readonly IFaAssetDeprnHdPostRepository _FaAssetDeprnHdPostRepository;
        private readonly IFaAssetsManager _faAssetsManager;
        private readonly IGetCounterRepository _repoProcCounter;
        private readonly IGlCodeComDetailsManager _glCodeComDetailsManager;
        private readonly IRepository<FaAssetDeprnTr, long> _repoFaAssetDeprnTr;
        private readonly IRepository<FaAssetDeprnTrDtl, long> _repoFaAssetDeprnTrDtl;

        public FaAssetDeprnHdAppService(IRepository<FaAssetDeprnHd, long> repository,
            IRepository<FaAssetDeprnTr, long> repoFaAssetDeprnTr,
            IRepository<FaAssetDeprnTrDtl, long> repoFaAssetDeprnTrDtl,
            IGlCodeComDetailsManager glCodeComDetailsManager,
            IFaAssetsManager faAssetsManager, IFaAssetDeprnHdPostRepository FaAssetDeprnHdPostRepository,
            IGetCounterRepository repoProcCounter
            ) : base(repository)
        {
            _FaAssetDeprnHdPostRepository = FaAssetDeprnHdPostRepository;
            _repoProcCounter = repoProcCounter;
            _faAssetsManager = faAssetsManager;
            _repoFaAssetDeprnTr = repoFaAssetDeprnTr;
            _repoFaAssetDeprnTrDtl = repoFaAssetDeprnTrDtl;
            _glCodeComDetailsManager = glCodeComDetailsManager;

            CreatePermissionName = PermissionNames.Pages_FaAssetDeprnHd_Insert;
            UpdatePermissionName = PermissionNames.Pages_FaAssetDeprnHd_Update;
            DeletePermissionName = PermissionNames.Pages_FaAssetDeprnHd_Delete;
            GetAllPermissionName = PermissionNames.Pages_FaAssetDeprnHd;
        }

        public override async Task<FaAssetDeprnHdDto> Create(FaAssetDeprnHdCreateDto input)
        {
            CheckCreatePermission();

            input.AssetDeprnNumber = await GetStoreIssueNumber();

            return await base.Create(input);
        }

        public async Task<FaAssetDeprnHdDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll().Include(z => z.StatusLkp).Include(z => z.Asset).Include(z => z.Period)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync();

            return ObjectMapper.Map<FaAssetDeprnHdDto>(current);
        }

        public async Task<List<FaAssetDeprnTrDto>> GetAllFaAssetDeprnTr(EntityDto<long> input)
        {
            var data = await _repoFaAssetDeprnTr.GetAllIncluding(z => z.Asset)
                                                .Where(z => z.FaAssetDeprnHdId == input.Id)
                                                .ToListAsync();

            return ObjectMapper.Map<List<FaAssetDeprnTrDto>>(data);
        }

        public async Task<List<FaAssetDeprnTrDtlDto>> GetAllFaAssetDeprnTrDtl(EntityDto<long> input)
        {
            var data = await _repoFaAssetDeprnTrDtl.GetAllIncluding(z => z.GlCodeComDetails)
                                                .Where(z => z.FaAssetDeprnTrId == input.Id)
                                                .ToListAsync();

            var mapped = ObjectMapper.Map<List<FaAssetDeprnTrDtlDto>>(data);

            foreach (var item in mapped)
            {
                if (item.GlCodeComDetails == null) continue;

                var codeCom = await _glCodeComDetailsManager.GetAttrNamesCodesNames(ObjectMapper.Map<GlCodeComDetails>(item.GlCodeComDetails));

                item.AccountNameAr = codeCom.namesAr;
                item.AccountNameEn = codeCom.namesEn;
                item.AccountNumber = codeCom.codes;

                item.GlCodeComDetails = null;
            }

            return mapped;
        }

        protected override IQueryable<FaAssetDeprnHd> CreateFilteredQuery(FaAssetDeprnHdPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.StatusLkp, z => z.Asset, z => z.Period, z => z.AssetDeprnTrs);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.AssetDeprnNumber))
                iqueryable = iqueryable.Where(z => z.AssetDeprnNumber.Contains(input.Params.AssetDeprnNumber));

            if (input.Params != null && input.Params.AssetId != null)
                iqueryable = iqueryable.Where(z => z.AssetId == input.Params.AssetId);

            if (input.Params != null && input.Params.PeriodId != null)
                iqueryable = iqueryable.Where(z => z.PeriodId == input.Params.PeriodId);

            if (input.Params != null && input.Params.StatusId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusId);

            return iqueryable;
        }

        public async Task<PostOutput> PostFaAssetDeprnHd(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _FaAssetDeprnHdPostRepository.Execute(postDto, "FaAssetDeprnHdPost");

            return result.FirstOrDefault();
        }

        public async Task<PostOutput> PostFaAssetDeprnHdGl(PostDto postDto)
        {
            postDto.UserId = AbpSession.UserId.Value;

            var result = await _FaAssetDeprnHdPostRepository.Execute(postDto, "FaAssetDeprnHdGlPost");

            return result.FirstOrDefault();
        }

        public async Task<Select2PagedResult> GetSelect2FaAssets(string searchTerm, int pageSize, int pageNumber, string lang)
         => await _faAssetsManager.GetSelect2FaAssets(searchTerm, pageSize, pageNumber, lang);

        private async Task<string> GetStoreIssueNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "FaAssetDeprnHdPost", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result.FirstOrDefault().OutputStr;
        }
    }
}

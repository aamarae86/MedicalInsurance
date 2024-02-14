using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ERP._System.__AccountModuleExtend._FaAssets.Dto;
using ERP._System.__AccountModuleExtend._FaAssets.Proc;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModuleExtend._FaAssets
{
    public class FaAssetAppService : AsyncCrudAppService<FaAssets, FaAssetDto, long, FaAssetPagedDto, FaAssetCreateDto, FaAssetEditDto>
        , IFaAssetsAppService
    {
        private readonly IFaAssetsPostRepository _faAssetsPostRepository;
        private readonly IGetCounterRepository _repoProcCounter;

        public FaAssetAppService(IRepository<FaAssets, long> repository, IFaAssetsPostRepository faAssetsPostRepository,
             IGetCounterRepository repoProcCounter) : base(repository)
        {
            _faAssetsPostRepository = faAssetsPostRepository;
            _repoProcCounter = repoProcCounter;

            CreatePermissionName = PermissionNames.Pages_FaAsset_Insert;
            UpdatePermissionName = PermissionNames.Pages_FaAsset_Update;
            DeletePermissionName = PermissionNames.Pages_FaAsset_Delete;
            GetAllPermissionName = PermissionNames.Pages_FaAsset;
        }

        public override async Task<FaAssetDto> Create(FaAssetCreateDto input)
        {
            CheckCreatePermission();

            input.AssetNumber = await GetStoreIssueNumber();

            return await base.Create(input);
        }

        public async Task<FaAssetDto> GetDetailAsync(EntityDto<long> input)
        {
            var current = await Repository.GetAll().Include(z => z.StatusLkp)
                        .Include(z => z.AssetTypeLkp).Include(z => z.BookingTypeLkp)
                        .Include(z => z.BoughtLkp).Include(z => z.DeprenMethodLkp)
                        .Include(z => z.OwnershipLkp).Include(z => z.SalvageValueTypeLkp)
                        .Include(z => z.ParentAsset).Include(z => z.AssetCategory)
                                   .Where(z => z.Id == input.Id).FirstOrDefaultAsync();

            return ObjectMapper.Map<FaAssetDto>(current);
        }

        protected override IQueryable<FaAssets> CreateFilteredQuery(FaAssetPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.StatusLkp, z => z.AssetTypeLkp
                , z => z.BookingTypeLkp, z => z.BoughtLkp, z => z.DeprenMethodLkp
                , z => z.SalvageValueTypeLkp, z => z.ParentAsset, z => z.AssetCategory, z => z.OwnershipLkp);

            if (input.Params != null && input.Params.Description != null)
                iqueryable = iqueryable.Where(z => z.Description == input.Params.Description);

            if (input.Params != null && input.Params.AssetTypeLkpId != null)
                iqueryable = iqueryable.Where(z => z.AssetTypeLkpId == input.Params.AssetTypeLkpId);

            if (input.Params != null && input.Params.FaAssetCategoryId != null)
                iqueryable = iqueryable.Where(z => z.FaAssetCategoryId == input.Params.FaAssetCategoryId);

            if (input.Params != null && input.Params.AssetNumber != null)
                iqueryable = iqueryable.Where(z => z.AssetNumber == input.Params.AssetNumber);

            if (input.Params != null && input.Params.StatusId != null)
                iqueryable = iqueryable.Where(z => z.StatusLkpId == input.Params.StatusId);

            return iqueryable;
        }

        public async Task<PostOutput> PostFaAsset(PostDto idLangInputDto)
        {
            idLangInputDto.UserId = AbpSession.UserId.Value;

            var result = await _faAssetsPostRepository.Execute(idLangInputDto, "FaAssetsPost");

            return result.FirstOrDefault();
        }

        private async Task<string> GetStoreIssueNumber(string lang = "ar-EG", int year = 0)
        {
            var counterInput = new GetCounterInputDto { CounterName = "FaAssets", TenantId = (int)AbpSession.TenantId, Lang = lang, year = year };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            return result.FirstOrDefault().OutputStr;
        }

        public async Task<Select2PagedResult> GetSelect2WithCategoryExcludingIds(string categoryId, string ids, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var numbers = ids.Split(',').Select(long.Parse).ToList();

            var data = Repository.GetAll()
                    .Where(z => z.FaAssetCategoryId.ToString() == categoryId && !numbers.Contains(z.Id) && (string.IsNullOrEmpty(searchTerm) || z.Description.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data
                        .OrderBy(q => q.Id)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.Description })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

    }
}

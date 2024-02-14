
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__CRM._CrmProducts;
using ERP._System.__CRM._CrmProducts.Dto;
using ERP._System.__CRM._Projects;
using ERP._System.__CRM.Products;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._Counters._CrmProducts
{
    [AbpAuthorize]
        public class CrmProductsAppService : AttachBaseAsyncCrudAppService<CrmProducts, CrmProductsDto, long, CrmProductsPagedDto, CrmProductsCreateDto, CrmProductsEditDto, AttachAuditedEntity>, ICrmProductsAppService
        {
        private readonly IEntityCounterManager _entityCounterManager;
        private readonly ICrmProductsManager _repoICrmProductsManager;
        public CrmProductsAppService(IRepository<CrmProducts,
            long> repository,
            IEntityCounterManager entityCounterManager,
            IConfiguration config,
            IImageConfig imageConfig,
            ICrmProductsManager repoICrmProductsManager
            ) : base(repository, config)
            {
            _entityCounterManager = entityCounterManager;
            _repoICrmProductsManager = repoICrmProductsManager;

            CreatePermissionName = PermissionNames.Pages_CrmProducts_Insert;
            UpdatePermissionName = PermissionNames.Pages_CrmProducts_Update;
            DeletePermissionName = PermissionNames.Pages_CrmProducts_Delete;
            GetAllPermissionName = PermissionNames.Pages_CrmProducts;
                PreFileName = "Product_";
                ServiceFolder = "CrmProducts";
            }

        protected override IQueryable<CrmProducts> CreateFilteredQuery(CrmProductsPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.ProductName))
                iqueryable = iqueryable.Where(z => z.ProductNameAr.Contains(input.Params.ProductName) ||
                                                   z.ProductNameEn.Contains(input.Params.ProductName));
 
            return iqueryable;
        }

        public async override Task<CrmProductsDto> Get(EntityDto<long> input)
        {
            var current = await Repository.GetAll().FirstOrDefaultAsync(s=>s.Id==input.Id);

            return ObjectMapper.Map<CrmProductsDto>(current);
        }

        public async override Task<CrmProductsDto> Create(CrmProductsCreateDto input)
        {
            CheckCreatePermission();
            return await base.Create(input);
        }

        public async Task<Select2PagedResult> GetCrmProductsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
           => await _repoICrmProductsManager.GetCrmProductsSelect2(searchTerm, pageSize, pageNumber, lang);
    }
}

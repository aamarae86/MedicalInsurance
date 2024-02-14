using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges
{
    [AbpAuthorize]
    public class IvUserWarehousesPrivilegesAppService : AsyncCrudAppService<IvUserWarehousesPrivileges, IvUserWarehousesPrivilegesDto, long, IvUserWarehousesPrivilegesPagedDto, IvUserWarehousesPrivilegesCreateDto, IvUserWarehousesPrivilegesEditDto>,
        IIvUserWarehousesPrivilegesAppService
    {

        private readonly IIvUserWarehousesPrivilegesManager _ivUserWarehousesPrivilegesManager;

        public IvUserWarehousesPrivilegesAppService(IRepository<IvUserWarehousesPrivileges, long> repository, 
                                                    IIvUserWarehousesPrivilegesManager ivUserWarehousesPrivilegesManager) : base(repository)
        {
            _ivUserWarehousesPrivilegesManager = ivUserWarehousesPrivilegesManager;

            CreatePermissionName = PermissionNames.Pages_IvUserWarehousesPrivileges_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvUserWarehousesPrivileges_Update;
            DeletePermissionName = PermissionNames.Pages_IvUserWarehousesPrivileges_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvUserWarehousesPrivileges;
        }

        public async Task<IvUserWarehousesPrivilegesDto> GetDetailAsync(EntityDto<long> input)
            => ObjectMapper.Map<IvUserWarehousesPrivilegesDto>(await Repository.GetAllIncluding(z => z.IvWarehouses, z => z.User)
                           .Where(z => z.Id == input.Id).FirstOrDefaultAsync());

        protected override IQueryable<IvUserWarehousesPrivileges> CreateFilteredQuery(IvUserWarehousesPrivilegesPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(z => z.IvWarehouses, z => z.User);

            if (input.Params != null && input.Params.IvWarehouseId != null)
                iqueryable = iqueryable.Where(z => z.IvWarehouseId == input.Params.IvWarehouseId);
            if (input.Params != null && input.Params.UserId != null)
                iqueryable = iqueryable.Where(z => z.UserId == input.Params.UserId);

            return iqueryable;
        }

        public async Task<Select2PagedResult> GetIvWarehousesForIssueUserSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await Repository.GetAll().Include(z => z.User).Include(z => z.IvWarehouses).Include(z => z.IvInventorySetting)
                          .Where(z => z.IvInventorySetting.UserId == AbpSession.UserId && z.HasIssue &&
                           string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.IvWarehouses.WarehouseName.Contains(searchTerm) : z.IvWarehouses.WarehouseName.Contains(searchTerm)))
                          .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.IvWarehouseId, text = lang == "ar-EG" ? z.IvWarehouses.WarehouseName : z.IvWarehouses.WarehouseName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetIvUserWarehousesPrivilegesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
             => await _ivUserWarehousesPrivilegesManager.GetIvUserWarehousesPrivilegesSelect2((long)AbpSession.UserId, searchTerm, pageSize, pageNumber, lang);

    }
}

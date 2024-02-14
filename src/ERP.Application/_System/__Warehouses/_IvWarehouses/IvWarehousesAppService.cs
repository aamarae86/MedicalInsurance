using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses._IvWarehouses.Dto;
using ERP._System.__Warehouses.Dto;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses
{
    [AbpAuthorize]
    public class IvWarehousesAppService : AsyncCrudAppService<IvWarehouses, IvWarehousesDto, long, IvWarehousesPagedDto, IvWarehousesCreateDto, IvWarehousesEditDto>,
        IIvWarehousesAppService
    {
        private readonly IGetCounterRepository _repoProcCounter;

        public IvWarehousesAppService(IGetCounterRepository getCounterRepository, IRepository<IvWarehouses, long> repository) : base(repository)
        {
            _repoProcCounter = getCounterRepository;

            CreatePermissionName = PermissionNames.Pages_IvWarehouses_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvWarehouses_Update;
            DeletePermissionName = PermissionNames.Pages_IvWarehouses_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvWarehouses;
        }

        protected override IQueryable<IvWarehouses> CreateFilteredQuery(IvWarehousesPagedDto input)
        {
            var iqueryable = Repository.GetAllIncluding(x => x.FndCityLkp);

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.WarehouseName))
                iqueryable = iqueryable.Where(z => z.WarehouseName.Contains(input.Params.WarehouseName));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.WarehouseNumber))
                iqueryable = iqueryable.Where(z => z.WarehouseNumber.Contains(input.Params.WarehouseNumber));

            if (input.Params != null && input.Params.CityLkpId != null)
                iqueryable = iqueryable.Where(z => z.CityLkpId == input.Params.CityLkpId);

            return iqueryable;
        }

        public async Task<IvWarehousesDto> GetDetailAsync(EntityDto<long> input)
            => ObjectMapper.Map<IvWarehousesDto>(await Repository.GetAllIncluding(x => x.FndCityLkp)
                           .Where(z => z.Id == input.Id)
                           .FirstOrDefaultAsync());

        public async override Task<IvWarehousesDto> Create(IvWarehousesCreateDto input)
        {
            CheckCreatePermission();

            var counterInput = new GetCounterInputDto { CounterName = "IvWarehouses", TenantId = (int)AbpSession.TenantId, Lang = "ar-EG", year = 0 };

            var result = await _repoProcCounter.Execute(counterInput, "GetCounter");

            string counter = result?.FirstOrDefault()?.OutputStr ?? string.Empty;

            input.WarehouseNumber = counter;

            if (input.IsDefault) await UpdateIsDef();

            return await base.Create(input);
        }

        public async override Task<IvWarehousesDto> Update(IvWarehousesEditDto input)
        {
            CheckUpdatePermission();

            if (input.IsDefault) await UpdateIsDef(input.Id);

            return await base.Update(input);
        }

        private async Task<bool> UpdateIsDef(long id = 0)
        {
            var data = await Repository.GetAll().Where(z => z.IsDefault && z.Id != id).ToListAsync();

            foreach (var item in data)
            {
                item.SetIsDefault(false);
                _ = await Repository.UpdateAsync(item);
            }

            return (0 == 0);
        }

        public async Task<Select2PagedResult> GetIvWarehousesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await Repository.GetAll().Where(z =>
              string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.WarehouseName.Contains(searchTerm) : z.WarehouseName.Contains(searchTerm)))
              .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.WarehouseName : z.WarehouseName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<IvWarehousesDto> GetFirstWarehousesByUserId()
        {
            var data = await Repository.GetAll().Where(z => z.TenantId == AbpSession.TenantId).FirstOrDefaultAsync();
            var obj = ObjectMapper.Map<IvWarehousesDto>(data);
            return obj;

        }
    }
}

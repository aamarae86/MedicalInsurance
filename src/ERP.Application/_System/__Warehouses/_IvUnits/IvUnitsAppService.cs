using Abp.Application.Services;
using Abp.Domain.Repositories;
using ERP._System.__Warehouses._IvUnits.Dto;
using ERP.Authorization;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvUnits
{
    public class IvUnitsAppService : AsyncCrudAppService<IvUnits, IvUnitsDto, long, IvUnitsPagedDto, IvUnitsCreateDto, IvUnitsEditDto>,
        IIvUnitsAppService
    {
        public IvUnitsAppService(IRepository<IvUnits, long> repository) : base(repository)
        {
            CreatePermissionName = PermissionNames.Pages_IvUnits_Insert;
            UpdatePermissionName = PermissionNames.Pages_IvUnits_Update;
            DeletePermissionName = PermissionNames.Pages_IvUnits_Delete;
            GetAllPermissionName = PermissionNames.Pages_IvUnits;
        }

        protected override IQueryable<IvUnits> CreateFilteredQuery(IvUnitsPagedDto input)
        {
            var iqueryable = Repository.GetAll();

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.UnitCode))
                iqueryable = iqueryable.Where(z => z.UnitCode.Contains(input.Params.UnitCode));

            if (input.Params != null && !string.IsNullOrEmpty(input.Params.UnitName))
                iqueryable = iqueryable.Where(z => z.UnitName.Contains(input.Params.UnitName));

            return iqueryable;
        }

        public async Task<Select2PagedResult> GetIvUnitsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = Repository.GetAll()
                 .Where(z => (string.IsNullOrEmpty(searchTerm) || z.UnitName.Contains(searchTerm) || z.UnitCode.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.UnitName })
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

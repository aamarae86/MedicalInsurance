using Abp.Domain.Repositories;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._IvUserWarehousesPrivileges
{
    public class IvUserWarehousesPrivilegesManager : IIvUserWarehousesPrivilegesManager
    {
        private readonly IRepository<IvUserWarehousesPrivileges, long> _repoIvUserWarehousesPrivileges;
        public IvUserWarehousesPrivilegesManager(IRepository<IvUserWarehousesPrivileges, long> repoIvUserWarehousesPrivileges)
        {
            _repoIvUserWarehousesPrivileges = repoIvUserWarehousesPrivileges;
           
        }

        public async Task<Select2PagedResult> GetIvUserWarehousesPrivilegesSelect2(long userId, string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoIvUserWarehousesPrivileges.GetAllIncluding(x => x.IvWarehouses,x=>x.IvInventorySetting)
                         .Where(z => (z.IvInventorySetting.UserId == userId && z.HasReceive) && (string.IsNullOrEmpty(searchTerm) || z.IvWarehouses.WarehouseName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(x => new Select2OptionModel { id = x.IvWarehouses.Id, text = x.IvWarehouses.WarehouseName })
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

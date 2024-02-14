using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._PoPurchaseOrder
{
    public class PoPurchaseOrderManager : IPoPurchaseOrderManager
    {
        //private readonly IRepository<PoPurchaseOrderHd, long> _repoPoPurchaseOrder;

        //public async Task<Select2PagedResult> GetPoPurchaseOrderSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        //{
        //    var data = _repoPoPurchaseOrder.GetAll()
        //            .Where(z => string.IsNullOrEmpty(searchTerm));

        //    long count = await data.LongCountAsync();

        //    var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
        //                .Select(z => new Select2OptionModel { id = z.Id, text = z.CaseName })
        //                .ToListAsync();

        //    var select2pagedResult = new Select2PagedResult
        //    {
        //        Total = count,
        //        Results = result
        //    };

        //    return select2pagedResult;
        //}
    }
}

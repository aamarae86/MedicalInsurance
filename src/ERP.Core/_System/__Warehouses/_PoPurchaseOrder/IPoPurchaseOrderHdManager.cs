using Abp.Domain.Services;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._PoPurchaseOrder
{
    public interface IPoPurchaseOrderHdManager : IDomainService
    {
        Task<Select2PagedResult> GetPurchaseOrderSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}

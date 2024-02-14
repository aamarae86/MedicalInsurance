using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__Warehouses._PoPurchaseOrder
{
    public class PoPurchaseOrderHdManager : IPoPurchaseOrderHdManager
    {
        private readonly IRepository<PoPurchaseOrderHd, long> _repoPoPurchaseOrderHd;

        public PoPurchaseOrderHdManager(IRepository<PoPurchaseOrderHd, long> repoPoPurchaseOrderHd)
        {
            _repoPoPurchaseOrderHd = repoPoPurchaseOrderHd;
        }

        public async Task<Select2PagedResult> GetPurchaseOrderSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoPoPurchaseOrderHd.GetAllIncluding(x => x.Vendor).Where(z => (string.IsNullOrEmpty(searchTerm) || z.PurchaseOrderNumber.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.PurchaseOrderNumber, altText = $"{z.VendorId}-{z.Vendor.VendorNameAr}-{z.Vendor.VendorNameEn}" })
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

using Abp.Domain.Repositories;
using ERP._System.__CRM._Projects;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CRM.Products
{
    public class CrmProductsManager : ICrmProductsManager
    {
        private readonly IRepository<CrmProducts, long> _repoCrmProducts;

        public CrmProductsManager(IRepository<CrmProducts, long> repoCrmProducts)
        {
            _repoCrmProducts = repoCrmProducts;
        }
        public async Task<Select2PagedResult> GetCrmProductsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoCrmProducts.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.ProductNameAr.Contains(searchTerm) : z.ProductNameEn.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.ProductNameAr : z.ProductNameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

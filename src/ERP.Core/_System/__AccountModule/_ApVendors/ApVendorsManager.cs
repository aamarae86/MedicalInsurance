using Abp.Domain.Repositories;
using Abp.Extensions;
using ERP._System._ApVendors;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._ApVendors
{
    public class ApVendorsManager : IApVendorsManager
    {
        private readonly IRepository<ApVendors, long> _repoApVendors;

        public ApVendorsManager(IRepository<ApVendors, long> repoApVendors)
        {
            _repoApVendors = repoApVendors;
        }

        public async Task<Select2PagedResult> GetVendorsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoApVendors.GetAll().Where(z => string.IsNullOrEmpty(searchTerm) || z.VendorNameAr.Contains(searchTerm) ||
                                   z.VendorNameEn.Contains(searchTerm));

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .Select(z => new Select2OptionModel
                {
                    id = z.Id,
                    text = (lang == "ar-EG" ? z.VendorNameAr : z.VendorNameEn),
                    altText = $"{z.VendorNumber.ToString()}-{z.TaxNo ?? string.Empty}"
                }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

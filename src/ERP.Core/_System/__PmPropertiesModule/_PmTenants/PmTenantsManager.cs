using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._PmTenants
{
    public class PmTenantsManager : IPmTenantsManager
    {
        private readonly IRepository<PmTenants, long> _repoPmTenants;

        public PmTenantsManager(IRepository<PmTenants, long> repoPmTenants)
        {
            _repoPmTenants = repoPmTenants;
        }

        public async Task<Select2PagedResult> GetPmTenantsNameAndIdNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoPmTenants.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.TenantNameAr.Contains(searchTerm) || z.IdNumber.Contains(searchTerm) : z.TenantNameEn.Contains(searchTerm) || z.IdNumber.Contains(searchTerm)) )
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? $"{z.TenantNameAr} - {z.IdNumber}" : $"{z.TenantNameEn} - {z.IdNumber}" }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> PmTenantsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoPmTenants.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.TenantNameAr.Contains(searchTerm) : z.TenantNameEn.Contains(searchTerm)) || z.TenantNumber.Contains(searchTerm))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.TenantNameAr : z.TenantNameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

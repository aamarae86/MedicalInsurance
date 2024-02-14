using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceQuotations
{
    public class ScMaintenanceQuotationsManager : IScMaintenanceQuotationsManager
    {
        private readonly IRepository<ScMaintenanceQuotations, long> _repoScMaintenanceQuotations;

        public ScMaintenanceQuotationsManager(IRepository<ScMaintenanceQuotations, long> repoScMaintenanceQuotations)
        {
            _repoScMaintenanceQuotations = repoScMaintenanceQuotations;
        }

        public async Task<Select2PagedResult> GetScMaintenanceQuotationsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoScMaintenanceQuotations.GetAllIncluding(z => z.ScMaintenanceTechnicalReport.PortalRequest.PortalUser, x => x.ApVendors, x => x.ScMaintenanceQuotationDetails).Where(z => z.StatusLkpId == 943 && (string.IsNullOrEmpty(searchTerm) || z.QuotationNumber.Contains(searchTerm)));

            var result = await data.OrderByDescending(q => q.CreationTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.QuotationNumber, altText = $"{z.ScMaintenanceTechnicalReport.PortalRequest.PortalRequestNumber}-{z.ScMaintenanceTechnicalReport.PortalRequest.PortalUser.Name}-{z.ApVendors.VendorNameAr}.{z.ApVendors.VendorNameEn}__{z.ScMaintenanceQuotationDetails.Sum(x => x.Amount)}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

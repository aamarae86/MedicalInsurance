using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport
{
    public class ScMaintenanceTechnicalReportManager : IScMaintenanceTechnicalReportManager
    {
        private readonly IRepository<ScMaintenanceTechnicalReport, long> _repoScMaintenanceTechnicalReport;

        public ScMaintenanceTechnicalReportManager(IRepository<ScMaintenanceTechnicalReport, long> repoScMaintenanceTechnicalReport)
        {
            _repoScMaintenanceTechnicalReport = repoScMaintenanceTechnicalReport;
        }

        public async Task<Select2PagedResult> GetScMaintenanceTechnicalReportSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoScMaintenanceTechnicalReport.GetAllIncluding(z => z.PortalRequest.PortalUser).Where(z => z.StatusLkpId == 941 && z.PortalRequest.StatusLkpId == 10952 && (string.IsNullOrEmpty(searchTerm) || z.TechnicalReportNumber.Contains(searchTerm)));

            var result = await data.OrderByDescending(q => q.CreationTime).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.TechnicalReportNumber, altText = $"{z.PortalRequest.PortalRequestNumber}-{z.PortalRequest.PortalUser.Name}" }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

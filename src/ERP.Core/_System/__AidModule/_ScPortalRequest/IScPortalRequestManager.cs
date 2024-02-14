using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AidModule._ScPortalRequest
{
    public interface IScPortalRequestManager : IDomainService
    {
        Task<Select2PagedResult> GetScPortalRequestMaintenanceNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetScPortalRequestSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetScPortalRequestMaintenanceSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetScPortalRequestForStudySelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetScPortalRequestForStudyByNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<Select2PagedResult> GetScPortalRequestForMgrSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}

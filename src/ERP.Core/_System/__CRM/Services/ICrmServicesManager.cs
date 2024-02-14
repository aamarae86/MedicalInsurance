using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CRM.Services
{
    public interface ICrmServicesManager : IDomainService
    {
        Task<Select2PagedResult> GetCrmServicesSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}

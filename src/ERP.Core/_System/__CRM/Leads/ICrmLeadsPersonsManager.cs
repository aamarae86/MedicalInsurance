using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CRM.Leads
{
    public interface ICrmLeadsPersonsManager : IDomainService
    {
        Task<Select2PagedResult> GetLeadsNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}

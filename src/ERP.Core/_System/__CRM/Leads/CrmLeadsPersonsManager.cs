using Abp.Domain.Repositories;
using ERP._System.__CRM._Projects;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CRM.Leads
{
    public class CrmLeadsPersonsManager : ICrmLeadsPersonsManager
    {
        private readonly IRepository<CrmLeadsPersons, long> _repoCrmLeads;

        public CrmLeadsPersonsManager(IRepository<CrmLeadsPersons, long> repoCrmLeads)
        {
            _repoCrmLeads = repoCrmLeads;
        }
        public async Task<Select2PagedResult> GetLeadsNameSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoCrmLeads.GetAll()
                .Where(z => string.IsNullOrEmpty(searchTerm) || z.FirstName.Contains(searchTerm) || z.LastName.Contains(searchTerm))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.FirstName +" "+ z.LastName }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

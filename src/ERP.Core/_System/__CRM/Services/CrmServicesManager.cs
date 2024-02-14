using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__CRM.Services
{
    public class CrmServicesManager : ICrmServicesManager
    {

        private readonly IRepository<CrmServices, long> _repoCrmServices;

        public CrmServicesManager(IRepository<CrmServices, long> repoCrmServices)
        {
            _repoCrmServices = repoCrmServices;
        }
        public async Task<Select2PagedResult> GetCrmServicesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {

            var data = await _repoCrmServices.GetAll()
                .Where(z =>
                 string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.ServiceNameAr.Contains(searchTerm) : z.ServiceNameEn.Contains(searchTerm)))
                .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.ServiceNameAr : z.ServiceNameEn }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

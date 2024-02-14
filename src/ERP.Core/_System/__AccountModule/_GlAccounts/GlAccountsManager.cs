using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System._GlAccounts
{
    public class GlAccountsManager : IGlAccountsManager
    {
        private readonly IRepository<GlAccounts, long> _repoGlAccounts;

        public GlAccountsManager(IRepository<GlAccounts, long> repoGlAccounts)
        {
            _repoGlAccounts = repoGlAccounts;
        }

        public async Task<Select2PagedResult> GetGlAccountsForAccMappingSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoGlAccounts.GetAll().Where(z => !z.Disabled && (string.IsNullOrEmpty(searchTerm) || z.DescriptionAr.Contains(searchTerm) || z.DescriptionEn.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = (lang == "ar-EG" ? $"{z.Code}-{z.DescriptionAr}" : $"{z.Code}-{z.DescriptionEn}") })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetGlAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang, string filterTrigger = null)
        {
            var data = await _repoGlAccounts.GetAll()
              .Where(z =>
              z.Disabled == false &&
              !_repoGlAccounts.GetAll().Any(c => c.ParentId == z.Id) &&
              (string.IsNullOrEmpty(filterTrigger) || filterTrigger == "PORTAL_STUDY" && z.Code.StartsWith("40101")) &&
               (string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? (z.DescriptionAr.Contains(searchTerm) || z.Code.Contains(searchTerm)) : z.DescriptionEn.Contains(searchTerm) || z.Code.Contains(searchTerm))))
              .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? $"{z.DescriptionAr} - {z.Code}" : $"{z.DescriptionEn} - {z.Code}" }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

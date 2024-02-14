using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System._GlMainAccounts
{
    public class GlMainAccountsManager : IGlMainAccountsManager
    {
        private readonly IRepository<GlMainAccounts, long> _repoGlMainAccounts;

        public GlMainAccountsManager(IRepository<GlMainAccounts, long> repoGlMainAccounts)
        {
            _repoGlMainAccounts = repoGlMainAccounts;
        }

        public async Task<Select2PagedResult> GetGlMainAccountsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _repoGlMainAccounts.GetAll()
               .Where(z =>  string.IsNullOrEmpty(searchTerm) || z.Description.Contains(searchTerm))
               .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.Description }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

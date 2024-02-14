using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System.__SpGuarantees._SpFamilies
{
    public class SpFamiliesManager : ISpFamiliesManager
    {
        private readonly IRepository<SpFamilies, long> _repoSpFamilies;

        public SpFamiliesManager(IRepository<SpFamilies, long> repoSpFamilies)
        {
            _repoSpFamilies = repoSpFamilies;
        }

        public async Task<Select2PagedResult> GetGaurdiantSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoSpFamilies.GetAll().Where(z => string.IsNullOrEmpty(searchTerm) || z.GuardianName.Contains(searchTerm));

            long count = await data.LongCountAsync();

            var result = await data
                .OrderBy(q => q.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.GuardianName}" })
                .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoSpFamilies
                    .GetAll()
                    .Where(z => string.IsNullOrEmpty(searchTerm) || (z.FamilyName.Contains(searchTerm) || z.FamilyNumber.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data
                .OrderBy(q => q.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(z => new Select2OptionModel { id = z.Id, text = $"{z.FamilyName}-{z.FamilyNumber}" })
                .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;
        }
    }
}

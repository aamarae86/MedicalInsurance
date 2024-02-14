using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._GlAccMappingHd
{
    public class GlAccMappingHdManager : IGlAccMappingHdManager
    {
        private readonly IRepository<GlAccMappingHd, long> _repoGlAccMappingHd;

        public GlAccMappingHdManager(IRepository<GlAccMappingHd, long> repoGlAccMappingHd)
        {
            _repoGlAccMappingHd = repoGlAccMappingHd;
        }

        public async Task<Select2PagedResult> GetGlAccMappingHdSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoGlAccMappingHd.GetAll().Where(z => (string.IsNullOrEmpty(searchTerm) || z.MapName.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.MapName })
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

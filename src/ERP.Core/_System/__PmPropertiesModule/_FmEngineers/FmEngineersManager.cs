using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__PmPropertiesModule._FmEngineers
{
    public class FmEngineersManager : IFmEngineersManager
    {
        private readonly IRepository<FmEngineers, long> _repoFmEngineers;

        public FmEngineersManager(IRepository<FmEngineers, long> repoFmEngineers)
        {
            _repoFmEngineers = repoFmEngineers;
        }

        public async Task<Select2PagedResult> GetFmEngineersNumberSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoFmEngineers.GetAll().Where(z =>
              string.IsNullOrEmpty(searchTerm) || (z.EngineerName.Contains(searchTerm) || z.EngineerNumber.Contains(searchTerm)));

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = z.EngineerNumber, altText = z.EngineerName }).ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = await data.CountAsync(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

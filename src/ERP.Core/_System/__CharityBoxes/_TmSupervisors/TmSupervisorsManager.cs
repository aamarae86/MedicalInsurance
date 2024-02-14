using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;

namespace ERP._System.__CharityBoxes._TmSupervisors
{
    public class TmSupervisorsManager : ITmSupervisorsManager
    {
        private readonly IRepository<TmSupervisors, long> _repoTmSupervisors;

        public TmSupervisorsManager(IRepository<TmSupervisors, long> repoTmSupervisors)
        {
            _repoTmSupervisors = repoTmSupervisors;
        }

        public async Task<Select2PagedResult> GetTmSupervisorsBoxesSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoTmSupervisors
             .GetAll()
             .Where(z => (z.SourceLkpId == 592 && z.StatusLkpId == 593) && (string.IsNullOrEmpty(searchTerm) || (z.SupervisorName.Contains(searchTerm))));

            long count = await data.LongCountAsync();

            var result = await data
                        .OrderBy(q => q.Id)
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = z.SupervisorName })
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

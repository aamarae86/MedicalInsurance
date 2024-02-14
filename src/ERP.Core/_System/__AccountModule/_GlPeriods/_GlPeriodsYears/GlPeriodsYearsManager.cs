using Abp.Domain.Repositories;
using Abp.Events.Bus;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System._GlPeriods
{
    public class GlPeriodsYearsManager : IGlPeriodsYearsManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IRepository<GlPeriodsYears, long> _GlPeriodsYearsRepository;

        public GlPeriodsYearsManager
            (
            IRepository<GlPeriodsYears, long> GlPeriodsYearsRepository
            )
        {
            _GlPeriodsYearsRepository = GlPeriodsYearsRepository;
        }

        public async Task<Select2PagedResult> GetGlPeriodsYearsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _GlPeriodsYearsRepository.GetAll()
                         .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.PeriodYear.ToString().Contains(searchTerm) : z.PeriodYear.ToString().Contains(searchTerm)))
                         .ToListAsync();

            var result = data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.PeriodYear.ToString() : z.PeriodYear.ToString(), altText = z.PeriodYear.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }

        public async Task<Select2PagedResult> GetGlPeriodsYearsReportSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = await _GlPeriodsYearsRepository.GetAll()
                         .Where(z => string.IsNullOrEmpty(searchTerm) || (lang == "ar-EG" ? z.PeriodYear.ToString().Contains(searchTerm) : z.PeriodYear.ToString().Contains(searchTerm)))
                         .ToListAsync();

            var result = data.OrderByDescending(q => q.PeriodYear).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(z => new Select2OptionModel { id = z.PeriodYear, text = lang == "ar-EG" ? z.PeriodYear.ToString() : z.PeriodYear.ToString(), altText = z.PeriodYear.ToString() }).ToList();

            var select2pagedResult = new Select2PagedResult
            {
                Total = data.Count(),
                Results = result
            };

            return select2pagedResult;
        }
    }
}

using Abp.Domain.Repositories;
using ERP.Helpers.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlPeriods
{
    public class GlPeriodsDetailsManager : IGlPeriodsDetailsManager
    {
        private readonly IRepository<GlPeriodsDetails, long> _repoGlPeriodsDetails;

        public GlPeriodsDetailsManager(IRepository<GlPeriodsDetails, long> repoGlPeriodsDetails)
        {
            _repoGlPeriodsDetails = repoGlPeriodsDetails;
        }

        public async Task<Select2PagedResult> GetGlPeriodsSelect2(string searchTerm, int pageSize, int pageNumber, string lang)
        {
            var data = _repoGlPeriodsDetails.GetAll()
                     .Where(z => (string.IsNullOrEmpty(searchTerm) || z.PeriodNameAr.Contains(searchTerm) || z.PeriodNameEn.Contains(searchTerm)));

            long count = await data.LongCountAsync();

            var result = await data.OrderBy(q => q.Id).Skip((pageNumber - 1) * pageSize).Take(pageSize)
                        .Select(z => new Select2OptionModel { id = z.Id, text = lang == "ar-EG" ? z.PeriodNameAr : z.PeriodNameEn, altText = $"{z.StartDate.ToString(Formatters.DateFormat)}__{z.EndDate.ToString(Formatters.DateFormat)}" })
                        .ToListAsync();

            var select2pagedResult = new Select2PagedResult
            {
                Total = count,
                Results = result
            };

            return select2pagedResult;

        }

        public async Task<GlPeriodsDetails> GetPeriod(DateTime transDate)
            => await _repoGlPeriodsDetails.GetAll().Where(z => z.StartDate <= transDate && z.EndDate >= transDate).FirstOrDefaultAsync();
    }
}

using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlPeriods
{
    public interface IGlPeriodsDetailsManager : IDomainService
    {
        Task<GlPeriodsDetails> GetPeriod(DateTime transDate);

        Task<Select2PagedResult> GetGlPeriodsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
    }
}

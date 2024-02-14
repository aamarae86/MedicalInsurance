using Abp.Application.Services;
using ERP._System._GlPeriods.Dto;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System._GlPeriods
{
    public interface IGlPeriodsDetailsAppService: IApplicationService
    {
        Task<GlPeriodsDetails> GetPeriod(string transDate);

        Task<Select2PagedResult> GetGlPeriodsSelect2(string searchTerm, int pageSize, int pageNumber, string lang);
        Task<GlPeriodsDetailsDto> GetFirstItemByUserId();

    }
}

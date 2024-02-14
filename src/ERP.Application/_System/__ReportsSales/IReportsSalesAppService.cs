using Abp.Application.Services;
using ERP._System.__ReportsSales.Input;
using ERP._System.__ReportsSales.Output;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__ReportsSales
{
    public interface IReportsSalesAppService : IApplicationService
    {
        Task<List<ArJobCardOutput>> GetArJobCards(ArJobCardHelperInput input);
        Task<List<ArJobCardDetailsOutput>> GetArJobCardsDetails(ArJobCardDetailsHelperInput input);

    }
}

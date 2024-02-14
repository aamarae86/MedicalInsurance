using Abp.Application.Services;
using ERP._System.__ReportsTms.Inputs;
using ERP._System.__ReportsTms.Outputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__ReportsTms
{
    public interface ITmCharityBoxListAppService : IApplicationService
    {
        Task<List<TmCharityBoxListScreenDataOutput>> GetTmCharityBoxListScreenData(TmCharityBoxListScreenDataInput input);
    }
}

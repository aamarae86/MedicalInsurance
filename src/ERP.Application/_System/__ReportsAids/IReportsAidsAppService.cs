using Abp.Application.Services;
using ERP._System.__ReportsAids.Input;
using ERP._System.__ReportsAids.Output;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__ReportsAids
{
    public interface IReportsAidsAppService : IApplicationService
    {
        Task<List<RptScPortalAidsOutput>> GetRptScPortalAids(RptScPortalAidsInputHelper inputHelper);

        Task<List<rptScPortalAidsPerNationalityOutput>> GetrptScPortalAidsPerNationality(rptScPortalAidsPerNationalityHelperInput input);

        Task<List<GeSCCasesListScreenDataOutput>> GetSCCasesListScreenData(GeSCCasesListScreenDataInput input);
    }
}

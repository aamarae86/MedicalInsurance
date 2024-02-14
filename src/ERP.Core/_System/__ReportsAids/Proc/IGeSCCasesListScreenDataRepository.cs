using ERP._System.__ReportsAids.Input;
using ERP._System.__ReportsAids.Output;
using ERP.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAids.Proc
{
    public interface IGeSCCasesListScreenDataRepository:
        IExecuteProcedure<PortalUser, long, GeSCCasesListScreenDataInput, GeSCCasesListScreenDataOutput>
    {
    }
}

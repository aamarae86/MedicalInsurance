using ERP._System.__ReportsPms.Input;
using ERP._System.__ReportsPms.Output;
using ERP._System._ArCustomers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsPms.Proc
{
    public interface IGetrptArDebitCreditRepository : IExecuteProcedure<ArCustomers, long, rptArDebitCreditInput, rptArDebitCreditOutput>
    {
    }
}

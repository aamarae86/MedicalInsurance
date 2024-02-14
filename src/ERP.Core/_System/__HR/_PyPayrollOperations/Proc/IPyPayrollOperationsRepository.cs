using ERP._System.__HR._PyPayrollOperations.Input;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._PyPayrollOperations.Proc
{
    public interface IPyPayrollOperationsRepository : IExecuteProcedure<PyPayrollOperations, long, StoredInput, PostOutput>
    {
    }
}

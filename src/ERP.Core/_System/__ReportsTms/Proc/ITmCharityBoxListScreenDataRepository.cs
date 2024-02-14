using ERP._System.__CharityBoxes._TmCharityBoxes;
using ERP._System.__ReportsTms.Inputs;
using ERP._System.__ReportsTms.Outputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsTms.Proc
{
    public interface ITmCharityBoxListScreenDataRepository
        : IExecuteProcedure<TmCharityBoxes, long, TmCharityBoxListScreenDataInput, TmCharityBoxListScreenDataOutput>
    {
    }
}

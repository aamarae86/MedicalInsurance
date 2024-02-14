using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._HrPersonsAdditionHd.Dto
{
    public class HrPersonsAdditionHdSearchDto
    {
        public string AdditionNumber { get;  set; }
        public string AdditionName { get;  set; }
        public override string ToString()
               => $"Params.AdditionName={AdditionName}&Params.AdditionNumber={AdditionNumber}";
    }
}

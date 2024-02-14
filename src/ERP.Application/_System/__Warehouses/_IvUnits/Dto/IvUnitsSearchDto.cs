using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__Warehouses._IvUnits.Dto
{
    public class IvUnitsSearchDto
    {
        public string UnitCode { get;  set; }
        public string UnitName { get;  set; }
        public override string ToString() => $"Params.UnitCode={UnitCode}&Params.UnitName={UnitName}";
    }
}

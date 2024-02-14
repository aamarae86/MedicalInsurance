using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__HR._PyElements.Dto
{
    public class PyElementsSearchDto
    {
        public int? ElementSerial { get;  set; }
        public string ElementName { get;  set; }
        public override string ToString() => $"Params.ElementName={ElementName}&Params.ElementSerial={ElementSerial}";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._TmCharityBoxesType.Dto
{
    public class TmCharityBoxesTypeSearchDto
    {
        public string TypeCode { get; set; }
        public string CharityBoxTypeName { get; set; }
        public override string ToString()
        {
            return $"Params.TypeCode={TypeCode}&Params.CharityBoxTypeName={CharityBoxTypeName}";
        }
    }
}

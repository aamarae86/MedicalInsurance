using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccDetails.Dto
{
    public class GlAccDetailsSearchDto
    {
        public string Code { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public long? GlAccHeaderId { get; set; }
    }
}

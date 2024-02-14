using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccHeaders.Dto
{
    public class CreateGlAccHeadersDto
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int ShowOrder { get; set; }
        public bool IsHide { get; set; }
        public long AttributeLkpId { get; set; }
        public Nullable<long> ParentId { get; set; }
    }
}

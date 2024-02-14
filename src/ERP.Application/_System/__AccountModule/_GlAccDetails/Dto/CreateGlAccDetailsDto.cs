using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccDetails.Dto
{
    [AutoMap(typeof(GlAccDetails))]
    public class CreateGlAccDetailsDto
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Code { get; set; }
        public long GlAccHeaderId { get; set; }
        public long? ParentId { get; set; }
        public bool IsDefault { get; set; }
    }
}

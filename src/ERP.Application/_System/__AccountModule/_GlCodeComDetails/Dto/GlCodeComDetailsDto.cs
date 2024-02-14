using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlCodeComDetails.Dto
{
    [AutoMapFrom(typeof(GlCodeComDetails))]
    [AutoMap(typeof(GlCodeComDetails))]
    [AutoMapTo(typeof(GlCodeComDetails))]
    public class GlCodeComDetailsDto : EntityDto<long>
    {
        public long? Attribute1 { get; set; }
        public long? Attribute2 { get; set; }
        public long? Attribute3 { get; set; }
        public long? Attribute4 { get; set; }
        public long? Attribute5 { get; set; }
        public long? Attribute6 { get; set; }
        public long? Attribute7 { get; set; }
        public long? Attribute8 { get; set; }
        public long? Attribute9 { get; set; }
        public long? AccId { get; set; }
    }
}

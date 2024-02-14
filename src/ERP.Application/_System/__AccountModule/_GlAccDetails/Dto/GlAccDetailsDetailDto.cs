using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._GlAccHeaders.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccDetails.Dto
{
    [AutoMapFrom(typeof(GlAccDetails))]
    public class GlAccDetailsDetailDto : EntityDto<long>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Code { get; set; }

        public long GlAccHeaderId { get;  set; }

        public bool IsDefault { get;  set; }

        public long? ParentId { get;  set; }

        public GlAccDetailsDto GlAccDetail { get;  set; }
        public GlAccHeadersDto GlAccHeader { get;  set; }
    }
}

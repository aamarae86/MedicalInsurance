using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccHeaders.Dto
{
    [AutoMapFrom(typeof(GlAccHeaders))]
    public class GlAccHeadersDetailDto : EntityDto<long>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Code { get; set; }
        public bool IsHide { get; set; }
        public int ShowOrder { get; set; }

        public long AttributeLkpId { get; set; }
        public Nullable<long> ParentId { get; set; }

        public GlAccHeaders Parent { get; set; }
        public FndLookupValuesForeginDto FndLookupValues { get;  set; }

    }
}

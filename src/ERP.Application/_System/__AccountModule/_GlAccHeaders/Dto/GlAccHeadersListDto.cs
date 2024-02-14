using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccHeaders.Dto
{
    [AutoMapFrom(typeof(GlAccHeaders))]
    public class GlAccHeadersListDto: AuditedEntity<long>
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Code { get; set; }
        public bool IsHide { get; set; }
        public long AttributeLkpId { get; set; }
        public Nullable<long> ParentId { get; set; }
    }
}

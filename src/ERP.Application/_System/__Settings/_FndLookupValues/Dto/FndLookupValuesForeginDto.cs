using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._FndLookupValues.Dto
{
    [AutoMapFrom(typeof(FndLookupValues))]
    public class FndLookupValuesForeginDto : AuditedEntity<long>
    {
        public string NameEn { get; set; }

        public string NameAr { get; set; }

        public string LookupCode { get; set; }

        public string LookupType { get; set; }

        public bool YesNo { get; set; }

        public string AddedValues { get; set; }
    }
}

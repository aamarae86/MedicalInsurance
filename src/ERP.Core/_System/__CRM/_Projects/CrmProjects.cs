using Abp.Domain.Entities;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._Projects
{
    public class CrmProjects : PostAuditedEntity<long>, IMustHaveTenant
    {
        public DateTime ProjectDate { get;protected set; }
        [StringLength(200)]
        public string ProjectNameAr { get; protected set; }
        [StringLength(200)]
        public string ProjectNameEn { get; protected set; }
        [StringLength(4000)]
        public string ProjectAdressAr { get; protected set; }
        [StringLength(4000)]
        public string ProjectAdressEn { get; protected set; }
        [StringLength(4000)]
        public string ContentAr { get; protected set; }
        [StringLength(4000)]
        public string ContentEn { get; protected set; }
        [StringLength(500)]
        public string Filepath { get; protected set; }
        public int TenantId { get;  set; }
    }
}

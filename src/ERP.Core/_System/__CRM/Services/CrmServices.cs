using Abp.Domain.Entities;
using ERP._System.__CRM.Leads;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__CRM.Services
{
   public class CrmServices : PostAuditedEntity<long>, IMustHaveTenant
    {
        public bool IsActive { get; protected set; }
        [StringLength(200)]
        public string ServiceNameAr { get; protected set; }
        [StringLength(200)]
        public string ServiceNameEn { get; protected set; }
        [StringLength(4000)]
        public string ContentAr { get; protected set; }
        [StringLength(4000)]
        public string ContentEn { get; protected set; }
        [StringLength(500)]
        public string Filepath { get; protected set; }
        public int TenantId { get; set; }

        public virtual ICollection<CrmLeadsPersons> CrmLeadsPersons { get; set; }
    }
}

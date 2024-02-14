using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP.MultiTenancy
{
    public class TenantDetail : AuditedEntity<int>, IMustHaveTenant
    {
        [ForeignKey(nameof(TenantId))]
        public Tenant Tenant { get; protected set; }

        public int TenantId { get; set; }

        [MaxLength(100)]
        public string LogoPath { get; protected set; }

        [MaxLength(100)]
        public string TenantNameAr { get; protected set; }

        [MaxLength(100)]
        public string TenantNameEn { get; protected set; }

        [MaxLength(100)]
        public string BoxNo { get; protected set; }

        [MaxLength(100)]
        public string Tel { get; protected set; }

        [MaxLength(100)]
        public string MobileNo { get; protected set; }

        [MaxLength(100)]
        public string Fax { get; protected set; }

        [MaxLength(100)]
        public string Email { get; protected set; }

        [MaxLength(100)]
        public string WebSite { get; protected set; }

        [MaxLength(200)]
        public string ManagerName { get; protected set; }

        [MaxLength(200)]
        public string RepManagerName { get; protected set; }
    }
}

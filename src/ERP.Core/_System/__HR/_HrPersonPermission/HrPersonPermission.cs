using Abp.Domain.Entities;
using ERP._System.__HR._HrPersons;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__HR._HrPersonPermission
{
  public class HrPersonPermission : PostAuditedEntity<long>, IMustHaveTenant
    {
        public string OperationNumber { get; protected set; }
        public long PermissionTypeId { get; protected set; }
        public DateTime PermissionDate { get; protected set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal FromTime { get; protected set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal EndTime { get; protected set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal TotalPermission { get; protected set; }
        public string permissionDetails { get; protected set; }
        public long HrPersonId { get; protected set; }
        public long StatusLkpId { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }
        
        [ForeignKey(nameof(PermissionTypeId))]
        public HrPermissionType HrPermissionType { get; protected set; }
        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }
        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }
        public int TenantId { get;  set; }
    }
}

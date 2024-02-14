using Abp.Domain.Entities;
using ERP._System.__HR._HrPersons;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__HR._HrPersonTimeSheet
{
   public class HrPersonTimeSheet : PostAuditedEntity<long>, IMustHaveTenant
    {
        public string TimeSheetNumber { get; protected set; }
        public string  ProjectName { get; protected set; }
        public long HrPersonId { get; protected set; }
        public long TimeSheetTypeId { get; protected set; }
        public DateTime TimeSheetDate { get; protected set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal FromTime { get; protected set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal EndTime { get; protected set; }
        [MaxLength(4000)]
        public string Notes { get; protected set; }
        [ForeignKey(nameof(HrPersonId))]
        public HrPersons HrPersons { get; protected set; }
        [ForeignKey(nameof(TimeSheetTypeId))]
        public TimeSheetType TimeSheetType { get; protected set; }
        public int TenantId { get; set; }
    }
}

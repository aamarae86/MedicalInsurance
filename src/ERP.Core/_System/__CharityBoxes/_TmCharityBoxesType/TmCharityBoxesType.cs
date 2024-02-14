using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Services;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.__AccountModule._TmCharityBoxesType
{
    public class TmCharityBoxesType : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        [MaxLength(20)]
        [Required]
        public string TypeCode { get; protected set; }
        [Required]
        [MaxLength(200)]
        public string CharityBoxTypeName { get; protected set; }
        [MaxLength(4000)]
        public string Notes { get; protected set; }
        public int TenantId { get; set ; }
        public bool IsActive { get ; set; }
    }
}

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__HR._HrPersons;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._FmEngineers
{
    public class FmEngineers : AuditedEntity<long>, IMustHaveTenant
    {
        [Required]
        [MaxLength(30)]
        public string EngineerNumber { get; protected set; }

        [Required]
        [MaxLength(100)]
        public string EngineerName { get; protected set; }

        public long StatusLkpId { get; protected set; }

        [MaxLength(4000)]
        public string Comments { get; protected set; }

        [MaxLength(50)]
        public string Mobile1 { get; protected set; }

        [MaxLength(50)]
        public string Mobile2 { get; protected set; }

        public DateTime? HireDate { get; protected set; }

        public long? HrPersonsId { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(HrPersonsId))]
        public HrPersons HrPersons { get; protected set; }
        public virtual ICollection<FmMaintRequisitionsExe> FmMaintRequisitionsExe { get; protected set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__PmPropertiesModule._PmProperties;
using System.ComponentModel.DataAnnotations.Schema;
using ERP._System.__PmPropertiesModule._FmEngineers;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe;

namespace ERP._System.__PmPropertiesModule._FmContracts
{
     

    public class FmContractVisits : AuditedEntity<long>, IMustHaveTenant, IPassivable
    {
        public long ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public FmContracts FmContracts { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string VisitNumber { get; set; }

        public DateTime VisitDate { get; set; }

        public long EngineerId { get; set; }
        [ForeignKey(nameof(EngineerId))]
        public FmEngineers FmEngineers { get; set; }

        [Column(TypeName = "nvarchar(4000)")]
        public string Comments { get; set; }
        public bool IsActive { get; set; }
        public int TenantId { get; set; }
        public virtual ICollection<FmMaintRequisitionsExe> FmMaintRequisitionsExe { get; protected set; }
    }



}

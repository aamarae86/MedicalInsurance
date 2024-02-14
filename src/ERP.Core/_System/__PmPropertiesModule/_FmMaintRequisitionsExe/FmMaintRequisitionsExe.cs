using Abp.Domain.Entities;
using ERP._System.__PmPropertiesModule._FmContracts;
using ERP._System.__PmPropertiesModule._FmEngineers;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe
{
    public class FmMaintRequisitionsExe : PostAuditedEntity<long>, IMustHaveTenant
    {
        public long StatusLkpId { get; protected set; }

        public long ExecuteTypeLkpId { get; protected set; }

        public long? EngineerId { get; protected set; }

        public long? FmContractsId { get; protected set; }

        public long? FmContractVisitsId { get; protected set; }

        public long? FmMaintRequisitionsHdrId { get; protected set; }

        public DateTime ExecuteDate { get; protected set; }

        public DateTime ExecuteTime { get; protected set; }

        [MaxLength(4000)]
        public string Comments { get; protected set; }

        public int TenantId { get;  set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 0)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(ExecuteTypeLkpId)), Column(Order = 1)]
        public FndLookupValues FndExecuteTypeLkp { get; protected set; }

        [ForeignKey(nameof(EngineerId))]
        public FmEngineers FmEngineers { get; protected set; }

        [ForeignKey(nameof(FmContractsId))]
        public FmContracts FmContracts { get; protected set; }

        [ForeignKey(nameof(FmContractVisitsId))]
        public FmContractVisits FmContractVisits { get; protected set; }

        [ForeignKey(nameof(FmMaintRequisitionsHdrId))]
        public FmMaintRequisitionsHdr FmMaintRequisitionsHdr { get; protected set; }
    }
}

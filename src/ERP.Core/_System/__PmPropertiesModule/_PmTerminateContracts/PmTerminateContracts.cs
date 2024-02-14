using Abp.Domain.Entities;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System._FndLookupValues;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System.__PmPropertiesModule._PmTerminateContracts
{
    public class PmTerminateContracts : PostAuditedEntity<long>, IMustHaveTenant
    {
        public long? PmContractId { get; protected set; }

        public long? StatusLkpId { get; protected set; }

        public DateTime? TerminationDate { get; protected set; }

        [MaxLength(30)]
        public string TerminationNumber { get; protected set; }

        public decimal? FineAmount { get; protected set; }

        [MaxLength(4000)]
        public string Notes { get; protected set; }

        public bool? IsTransferDepositToCustomer { get; protected set; }

        public int TenantId { get; set; }

        [ForeignKey(nameof(StatusLkpId))]
        public FndLookupValues FndLookupValuesPmTerminateContractsStatusLkp { get; set; }

        [ForeignKey(nameof(PmContractId))]
        public PmContract PmContract { get; set; }

    }
}

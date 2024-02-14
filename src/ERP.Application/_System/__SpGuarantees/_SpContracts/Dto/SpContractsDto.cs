using Abp.AutoMapper;
using ERP._System.__SpGuarantees._SpBeneficent.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;

namespace ERP._System.__SpGuarantees._SpContracts.Dto
{
    [AutoMap(typeof(SpContracts))]
    public class SpContractsDto : PostAuditedEntityDto<long>
    {
        public string EncId => Core.Helpers.Core.CipherStringController.Encrypt(this.Id.ToString());

        public string ContractNumber { get; set; }

        public string ContractDate { get; set; }

        public long StatusLkpId { get; set; }

        public long? PaymentTypeLkpId { get;  set; }

        public long? DeductedLkpId { get;  set; }

        public long SpBeneficentId { get; set; }

        public SpBeneficentDto SpBeneficent { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndPaymentTypeLkp { get; set; }

        public FndLookupValuesDto FndDeductedLkp { get; set; }

        public ICollection<SpContractAttachmentsDto> ContractAttachments { get; set; }

        public ICollection<SpContractDetailsDto> ContractDetails { get; set; }
    }
}

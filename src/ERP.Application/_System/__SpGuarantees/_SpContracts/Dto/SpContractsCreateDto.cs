using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP._System.__SpGuarantees._SpBeneficent.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SpGuarantees._SpContracts.Dto
{
    [AutoMap(typeof(SpContracts))]
    public class SpContractsCreateDto
    {
        public string ContractNumber { get; set; }

        public string ContractDate { get; set; }

        public long StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_SpContract);

        public long? PaymentTypeLkpId { get;  set; }

        public long? DeductedLkpId { get;  set; }

        public long SpBeneficentId { get; set; }

        public SpBeneficentDto SpBeneficent { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public ICollection<SpContractAttachmentsDto> ContractAttachments { get; set; }

        public ICollection<SpContractDetailsDto> ContractDetails { get; set; }
    }
}

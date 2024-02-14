using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using ERP.ModificationsValidation;
using System;
using System.Collections.Generic;

namespace ERP._System.__SpGuarantees._SpContracts.Dto
{
    [AutoMap(typeof(SpContracts))]
    public class SpContractsEditDto : EditEntityDto<long> //, IHasModificationTimeValidation //, IHasPostTimeValidation
    {
        public string EncId => Core.Helpers.Core.CipherStringController.Encrypt(this.Id.ToString());

        public string ContractDate { get; set; }

        public long? PaymentTypeLkpId { get;  set; }

        public long? DeductedLkpId { get;  set; }

        public long SpBeneficentId { get; set; }

        public ICollection<SpContractAttachmentsDto> ContractAttachments { get; set; }

        public ICollection<SpContractDetailsDto> ContractDetails { get; set; }
        //public DateTime? LastModificationTime { get; }
        //public string LastModificationTimeStr { get; set; }

        //public DateTime? PostTime { get; }
    }
}

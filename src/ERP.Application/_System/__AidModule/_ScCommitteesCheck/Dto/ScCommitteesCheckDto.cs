using Abp.AutoMapper;
using ERP._System.__AidModule._ScCommittee.Dto;
using ERP._System.__AidModule._ScCommitteesCheckDetails.Dto;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommitteesCheck.Dto
{
    [AutoMap(typeof(ScCommitteesCheck))]
    public class ScCommitteesCheckDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string OperationNumber { get; set; }

        public string OperationDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long CommitteeId { get; set; }

        [MaxLength(30)]
        public string FromCheckNumber { get; set; }

        public long? BankAccountId { get; set; }

        public string MaturityDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }

        public ScCommitteeDto ScCommittee { get; set; }

        public ApBankAccountsDto ApBankAccounts { get; set; }

        public virtual ICollection<ScCommitteesCheckDetailsDto> ScCommitteesCheckDetails { get; set; }

        public virtual ICollection<ScCommitteesCheckDetailsDto> ScCommitteesCheckDetailsList { get; set; }
    }
}

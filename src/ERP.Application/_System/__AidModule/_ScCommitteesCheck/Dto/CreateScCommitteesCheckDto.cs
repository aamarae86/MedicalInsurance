using Abp.AutoMapper;
using ERP._System.__AidModule._ScCommitteesCheckDetails.Dto;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommitteesCheck.Dto
{
    [AutoMap(typeof(ScCommitteesCheck))]
    public class CreateScCommitteesCheckDto
    {
        public string OperationNumber { get; set; }

        public string OperationDate { get; set; }

        public long? StatusLkpId => Convert.ToInt64(FndEnum.FndLkps.New_ScCommitteesCheckStatues);

        public long? CommitteeId { get; set; }

        [MaxLength(30)]
        public string FromCheckNumber { get; set; }

        public long? BankAccountId { get; set; }

        public string MaturityDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<ScCommitteesCheckDetailsDto> ScCommitteesCheckDetailsList { get; set; }
    }
}

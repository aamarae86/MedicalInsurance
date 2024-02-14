using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AidModule._ScCommitteesCheckDetails.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScCommitteesCheck.Dto
{
    [AutoMap(typeof(ScCommitteesCheck))]
    public class ScCommitteesCheckEditDto : EntityDto<long>
    {
        public string OperationNumber { get; set; }

        public string OperationDate { get; set; }

        [MaxLength(30)]
        public string FromCheckNumber { get; set; }

        public long? BankAccountId { get; set; }

        public string MaturityDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public virtual ICollection<ScCommitteesCheckDetailsDto> ScCommitteesCheckDetails { get; set; }

        public virtual ICollection<ScCommitteesCheckDetailsDto> ScCommitteesCheckDetailsList { get; set; }
    }
}

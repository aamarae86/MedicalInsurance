using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._ArPdcInterface.Dto
{
    [AutoMapFrom(typeof(ArPdcInterface))]
    public class CreateArPdcInterfaceDto
    {
        public long? SourceCodeLkpId { get;   set; }
        public long? SourceId { get;   set; }
        [MaxLength(30)]
        public string SourceNumber { get;   set; }
        public long? StatusLkpId { get;   set; }
        public decimal? Amount { get;   set; }
        [MaxLength(30)]
        public string CheckNumber { get; set; }
        public DateTime? MaturityDate { get;   set; }
        public long? BankAccountId { get;   set; }
        [MaxLength(4000)]
        public string Notes { get;   set; }
        public DateTime? ConfirmedDate { get;   set; }
        public DateTime? ReversedDate { get;   set; }
        public long? CustomerId { get;   set; }
        public long? BankLkpId { get;   set; }
    }
}

using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._ApPdcInterface.Dto
{
    [AutoMapFrom(typeof(ApPdcInterface))]
    public class CreateApPdcInterfaceDto
    {
        public long? SourceCodeLkpId { get; set; }
        public long? SourceId { get; set; }
        public long? StatusLkpId { get; set; }
        [MaxLength(30)]
        public string SourceNumber { get; set; }
        public decimal? Amount { get; set; }
        [MaxLength(30)]
        public string CheckNumber { get; set; }
        public DateTime? MaturityDate { get; set; }
        public long? BankAccountId { get; set; }
        [MaxLength(4000)]
        public string Notes { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public DateTime? ReversedDate { get; set; }
        public long? VendorId { get; set; }
        public long? ChqReturnResonLKPId { get; set; }
    }
}

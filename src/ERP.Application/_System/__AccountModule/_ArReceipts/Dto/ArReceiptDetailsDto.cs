using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArReceipts.Dto
{
    [AutoMap(typeof(ArReceiptDetails))]
    public class ArReceiptDetailsDto : EntityDto<long>, IDetailRowStatus
    {
        public long ReceiptId { get; set; }

        [Required]
        [MaxLength(30)]
        public string CheckNumber { get; set; }

        [Required]
        public string MaturityDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        [Required]
        public long BankLkpId { get; set; }

        public FndLookupValuesDto Bank { get; set; }

        public long? SourceCodeLkpId { get; set; } = 280;

        public long? SourceId { get; set; }

        public string rowStatus { get; set; }
    }

}

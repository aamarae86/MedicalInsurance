using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using ERP.Helpers.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArReceipts.Dto
{
    [AutoMap(typeof(ArReceiptsOnAccount))]
    public class ArReceiptsOnAccountDto : EntityDto<long>, IDetailRowStatus
    {
        [Required]
        public string ApplyDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        [Required]
        public long ReceiptTypeLkpId { get; set; }

        public FndLookupValuesDto FndReceiptTypeLkp { get; set; }

        public long? SourceCodeLkpId { get; set; } = 280;

        public long? SourceId { get; set; }

        public long ReceiptId { get; set; }

        public string rowStatus { get; set; }
    }
}

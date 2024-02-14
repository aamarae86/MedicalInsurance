using Abp.AutoMapper;
using ERP._System._ArDrCrTr.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System._ArDrCrHd.Dto
{
    [AutoMap(typeof(ArDrCrHd))]
    public class CreateArDrCrHdDto
    {
        public long? Id { get; set; }

        [MaxLength(30)]
        public string HdDrCrNumber { get; set; }

        public string HdDate { get; set; }

        public long? HdTypeLkpId { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public long? StatusLkpId => 194;

        public int CurrencyId { get; set; }

        public decimal? CurrencyRate { get; set; }

        public long? ArCustomerId { get; set; }

        public long? SourceLkpId { get; set; }

        public long? SourceId { get; set; }

        [MaxLength(30)]
        public string SourceNo { get; set; }

        public List<ArDrCrTrVM> ArDrCrTrList { get; set; }
    }
}

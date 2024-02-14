using Abp.AutoMapper;
using ERP._System.__AccountModule._ApDrCrTr.Dto;
using ERP._System._ArDrCrTr.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__AccountModule._ApDrCrHd.Dto
{
    [AutoMap(typeof(ApDrCrHd))]
    public class ApDrCrHdCreateDto
    {
        public long? Id { get; set; }

        [MaxLength(30)]
        public string HdDrCrNumber { get; set; }

        public string HdDate { get; set; }

        public long? HdTypeLkpId { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public long? StatusLkpId => 31606;

        public int CurrencyId { get; set; }

        public decimal? CurrencyRate { get; set; }

        public long? VendorId { get; set; }

        public long? SourceLkpId { get; set; }

        public long? SourceId { get; set; }

        [MaxLength(30)]
        public string SourceNo { get; set; }

        public List<ApDrCrTrDto> ApDrCrTrList { get; set; }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ArDrCrHd;
using ERP._System._ArDrCrTr.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArDrCrHd.Dto
{
    [AutoMap(typeof(ArDrCrHd))]
    public class ArDrCrHdEditDto : EntityDto<long>
    {
        public string HdDate { get; set; }

        public long? HdTypeLkpId { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public int CurrencyId { get; set; }

        public decimal? CurrencyRate { get; set; }

        public long? ArCustomerId { get; set; }

        [MaxLength(30)]
        public string SourceNo { get; set; }

        public virtual ICollection<ArDrCrTrVM> ArDrCrTr { get; set; }

        public List<ArDrCrTrVM> ArDrCrTrList { get; set; }
    }
}

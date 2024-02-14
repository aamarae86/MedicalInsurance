using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._ApDrCrTr.Dto;
using ERP._System._ArDrCrHd;
using ERP._System._ArDrCrTr.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ApDrCrHd.Dto
{
    [AutoMap(typeof(ApDrCrHd))]
    public class ApDrCrHdEditDto : EntityDto<long>
    {
        public string HdDate { get; set; }

        public long? HdTypeLkpId { get; set; }

        [MaxLength(4000)]
        public string Comments { get; set; }

        public int CurrencyId { get; set; }

        public decimal? CurrencyRate { get; set; }

        public long? VendorId { get; set; }

        [MaxLength(30)]
        public string SourceNo { get; set; }

        public virtual ICollection<ApDrCrTrDto> ApDrCrTr { get; set; }

        public List<ApDrCrTrDto> ApDrCrTrList { get; set; }
    }
}

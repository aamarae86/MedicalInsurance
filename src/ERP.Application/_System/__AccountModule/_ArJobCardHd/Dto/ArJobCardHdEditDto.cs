using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ERP._System.__AccountModule._ArJobCardHd.Dto
{
    [AutoMap(typeof(ArJobCardHd))]
    public class ArJobCardHdEditDto : EntityDto<long>
    {
        public string JobNumber { get; set; }

        public string JobDate { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public long JobTypeLkpId { get; set; }
        public string PoliceReportNo { get; set; }
        public long? PoliceReportSourceLkpId { get; set; }

        public long ArCustomerId { get; set; }

        [MaxLength(200)]
        public string ContactName { get; set; }

        [MaxLength(50)]
        public string ContactNo { get; set; }

        [MaxLength(50)]
        public string VehiclePlateNo { get; set; }
        public long? VehicleEmirateLkpId { get; set; }
        public long VehicleMakeLkpId { get; set; }

        [MaxLength(50)]
        public string VehicleType { get; set; }
        public long VehicleModelLkpId { get; set; }
        public long VehicleColorLkpId { get; set; }
        public decimal EstimatedAmount { get; set; }

        [MaxLength(200)]
        public string ClaimNo { get; set; }

        [MaxLength(200)]
        public string LpoNo { get; set; }
        public decimal? OriginalAmount { get; set; }
        public string CreditNote { get; set; }
        //public decimal? CustomerVatPercentage { get; set; }
        public decimal? CustomerVatAmount { get; set; }
        public long? ExcessStatusLkpId { get; set; }
        public decimal? ExcessAmount { get; set; }
        //public decimal? ExcessVatPercentage { get; set; }
        public decimal? ExcessVatAmount { get; set; }
        public long StatusLkpId { get; set; }
        public decimal? DiscountAmount { get; set; }
        public string InvoiceDate { get; set; }
        [MaxLength(4000)]
        public string CloseReason { get; set; }
        public long? FndSalesMenId { get; set; }
        public virtual ICollection<ArJobCardAttachmentsDto> ArJobCardAttachments { get;   set; }
    }
}

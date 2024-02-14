using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System.__SalesModule._FndSalesMen.Dto;
using ERP._System._ArCustomers.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AccountModule._ArJobCardHd.Dto
{
    [AutoMap(typeof(ArJobCardHd))]
    public class ArJobCardHdDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
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
        public decimal? CustomerVatPercentage { get; set; }
        public decimal? CustomerVatAmount { get; set; }
        public long? ExcessStatusLkpId { get; set; }
        public decimal? ExcessAmount { get; set; }
        public decimal? ExcessVatPercentage { get; set; }
        public decimal? ExcessVatAmount { get; set; }
        public long StatusLkpId { get; set; }
        public string InvoiceDate { get; set; }
        [MaxLength(4000)]
        public string CloseReason { get; set; }

        public int TenantId { get; set; }

        #region LookupValues

        public FndLookupValuesDto FndJobTypeLkp { get;  set; }

        public ArCustomersDto ArCustomers { get;  set; }

        public FndLookupValuesDto FndVehicleEmirateLkp { get;  set; }

        public FndLookupValuesDto FndVehicleMakeLkp { get;  set; }

        public FndLookupValuesDto FndVehicleModelLkp { get;  set; }
        public FndLookupValuesDto FndPoliceReportSourceLkp { get; set; }

        public FndLookupValuesDto FndVehicleColorLkp { get;  set; }

        public FndLookupValuesDto FndExcessStatusLkp { get;  set; }

        public FndLookupValuesDto FndStatusLkp { get;  set; }

        public decimal? DiscountAmount { get; set; }
        public long? FndSalesMenId { get; set; }
        public FndSalesMenDto FndSalesMen { get; set; }
        #endregion

        public virtual ICollection<ArJobCardAttachments> ArJobCardAttachments { get; protected set; }
    }
}

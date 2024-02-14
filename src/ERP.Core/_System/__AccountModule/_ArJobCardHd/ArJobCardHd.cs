using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ERP._System.__AccountModule._ArJobCardHd
{
    public class ArJobCardHd  : AuditedEntity<long>, IMustHaveTenant
    {
        


        [Required]
        [MaxLength(30)]
        public string JobNumber { get; set; }

        [Required]
        public DateTime JobDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [Required]
        public long JobTypeLkpId { get; set; }
        
        public string PoliceReportNo { get; set; }

        public long? PoliceReportSourceLkpId { get; set; }

        [Required]
        public long ArCustomerId { get; set; }

        [MaxLength(200)]
        public string ContactName { get; set; }

        [MaxLength(50)]
        public string ContactNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string VehiclePlateNo { get; set; }

        [Required]
        public long VehicleEmirateLkpId { get; set; }

        [Required]
        public long VehicleMakeLkpId { get; set; }

        [Required]
        [MaxLength(50)]
        public string VehicleType { get; set; }

        [Required]
        public long VehicleModelLkpId { get; set; }

        [Required]
        public long VehicleColorLkpId { get; set; }

        [Required]
        public decimal EstimatedAmount { get; set; }

        [MaxLength(200)]
        public string ClaimNo { get; set; }

        [MaxLength(200)]
        public string LpoNo { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? OriginalAmount { get; set; }

        [MaxLength(100)]
        public string CreditNote { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? CustomerVatPercentage { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? CustomerVatAmount { get; set; }
        public long? ExcessStatusLkpId { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? ExcessAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? ExcessVatPercentage { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? ExcessVatAmount { get; set; }
        public long? StatusLkpId { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? DiscountAmount { get; set; }

        public long? FndSalesMenId { get; set; }     
        public DateTime? InvoiceDate { get; set; }
        [MaxLength(4000)]
        public string CloseReason { get; set; }
        public int TenantId { get; set; }
       
        #region LookupValues

        [ForeignKey(nameof(JobTypeLkpId)), Column(Order = 0)]
        public FndLookupValues FndJobTypeLkp { get; protected set; }

        [ForeignKey(nameof(PoliceReportSourceLkpId)), Column(Order = 7)]
        public FndLookupValues FndPoliceReportSourceLkp { get; protected set; }

        [ForeignKey(nameof(ArCustomerId))]
        public ArCustomers ArCustomers { get; protected set; }

        [ForeignKey(nameof(VehicleEmirateLkpId)), Column(Order = 1)]
        public FndLookupValues FndVehicleEmirateLkp { get; protected set; }

        [ForeignKey(nameof(VehicleMakeLkpId)), Column(Order = 2)]
        public FndLookupValues FndVehicleMakeLkp { get; protected set; }

        [ForeignKey(nameof(VehicleModelLkpId)), Column(Order = 3)]
        public FndLookupValues FndVehicleModelLkp { get; protected set; }

        [ForeignKey(nameof(VehicleColorLkpId)), Column(Order = 4)]
        public FndLookupValues FndVehicleColorLkp { get; protected set; }

        [ForeignKey(nameof(ExcessStatusLkpId)), Column(Order = 5)]
        public FndLookupValues FndExcessStatusLkp { get; protected set; }

        [ForeignKey(nameof(StatusLkpId)), Column(Order = 5)]
        public FndLookupValues FndStatusLkp { get; protected set; }

        [ForeignKey(nameof(FndSalesMenId)), Column(Order = 6)]
        public FndSalesMen FndSalesMen { get; protected set; }
        public long? TenxMigrationId { get; set; }

        #endregion

        public virtual ICollection<ArJobCardAttachments> ArJobCardAttachments { get; protected set; }

        public virtual ICollection<ArJobCardPaymentHd> ArJobCardPaymentHd { get; protected set; }
    }
}

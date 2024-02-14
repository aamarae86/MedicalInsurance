using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ERP._System._FndLookupValues;
using ERP._System.__AccountModule._ArJobSurveyTr;
using ERP._System._ArCustomers;

namespace ERP._System.__AccountModule._ArJobSurveyHd
{
    public class ArJobSurveyHd : AuditedEntity<long>, IMustHaveTenant
    {

        [Required]
        [MaxLength(30)]
        public string ClaimNo { get; set; }
        [Required]
        public DateTime ClaimDate { get; set; }
        public bool InsuredVehicle { get; set; }
        public bool TPVehicle { get; set; }
        [MaxLength(200)]
        public string ContactName { get; set; }
        [MaxLength(50)]
        public string ContactNo { get; set; }
        public long? VehicleMakeLkpId { get; set; }
        [ForeignKey(nameof(VehicleMakeLkpId)), Column(Order = 0)]
        public FndLookupValues ArJobCardVehicleMakeLkp { get; protected set; }
        public long? VehicleModelLkpId { get; set; }
        [ForeignKey(nameof(VehicleModelLkpId)), Column(Order = 1)]
        public FndLookupValues ArJobCardVehicleModelLkp { get; protected set; }
        public long? ArJobSurveyStatusLkpId { get; set; }
        [ForeignKey(nameof(ArJobSurveyStatusLkpId)), Column(Order = 2)]
        public FndLookupValues ArJobSurveyStatusLkp { get; protected set; }
        public long? VehicleColorLkpId { get; set; }
        [ForeignKey(nameof(VehicleColorLkpId)), Column(Order = 3)]
        public FndLookupValues VehicleColorLkp { get; protected set; }
        public long? VehicleEmirateLkpId { get; set; }
        [ForeignKey(nameof(VehicleEmirateLkpId)), Column(Order = 4)]
        public FndLookupValues VehicleEmirateLkp { get; protected set; }
        public long? JobTypeLkpId { get; set; }
        [ForeignKey(nameof(JobTypeLkpId)), Column(Order = 0)]
        public FndLookupValues JobTypeLkp { get; protected set; }
        public long? ArCustomerId { get; set; }
        [ForeignKey(nameof(ArCustomerId))]
        public ArCustomers ArCustomers { get; protected set; }
        [Required]
        public string PlateNo { get; set; }
        [MaxLength(4000)]
        public string Comments { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? EstimatedAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? LabourCharges { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? LumpsumAmount { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public int TenantId { get; set; }
        public virtual ICollection<ArJobSurveyTr> ArJobSurveyTr { get;  set; }

    }
}

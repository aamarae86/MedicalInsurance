using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._ArJobSurveyHd;
using ERP._System.__AccountModule._ArJobSurveyTr;
using ERP._System._ArCustomers.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using Stripe;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP._System._ArJobSurveyHd.Dto
{
    [AutoMap(typeof(ArJobSurveyHd))]
    public class ArJobSurveyHdDto : AuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string ClaimNo { get; set; }
        public string ClaimDate { get; set; }
        public bool InsuredVehicle { get; set; }
        public bool TPVehicle { get; set; }
        public long? VehicleMakeLkpId { get; set; }
        public long? VehicleModelLkpId { get; set; }
        [MaxLength(4000)]
        public string Comments { get; set; }
        public long? ArJobSurveyStatusLkpId { get; set; }
        public string PlateNo { get; set; }
        [MaxLength(200)]
        public string ContactName { get; set; }
        [MaxLength(50)]
        public string ContactNo { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
        public string Attribute4 { get; set; }
        public decimal? EstimatedAmount { get; set; }
        public decimal? LabourCharges { get; set; }
        public decimal? LumpsumAmount { get; set; }
        public long? VehicleColorLkpId { get; set; }
        public long? VehicleEmirateLkpId { get; set; }
        public long? JobTypeLkpId { get; set; }
        public long? ArCustomerId { get; set; }
        public ArCustomersDto ArCustomers { get;   set; }
        public FndLookupValuesDto JobTypeLkp { get;   set; }
        public FndLookupValuesDto VehicleColorLkp { get;   set; }
        public FndLookupValuesDto VehicleEmirateLkp { get;   set; }
        public FndLookupValuesDto ArJobCardVehicleMakeLkp { get; set; }
        public FndLookupValuesDto ArJobCardVehicleModelLkp { get; set; }
        public FndLookupValuesDto ArJobSurveyStatusLkp { get; set; }
        public virtual ICollection<ArJobSurveyTrDto> ArJobSurveyTr { get; set; }
    }
}

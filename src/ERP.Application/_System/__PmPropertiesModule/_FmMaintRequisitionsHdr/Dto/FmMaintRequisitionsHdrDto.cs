using ERP._System.__PmPropertiesModule._PmProperties.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto
{
    public class FmMaintRequisitionsHdrDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        [MaxLength(30)]
        public string RequisitionNumber { get; set; }

        public long RequisitionStatusLkpId { get; set; }

        public long PmPropertiesId { get; set; }

        public long ComplaintTypeLkpId { get; set; }

        public long? UnitTypeLkpId { get; set; }

        public long? UnitId { get; set; }

        public string RequisitionDate { get; set; }

        public string RequisitionTime { get; set; }

        [MaxLength(150)]
        public string CallerName { get; set; }

        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [MaxLength(30)]
        public string Mobile { get; set; }

        [MaxLength(4000)]
        public string ComplaintDetails { get; set; }

        public FndLookupValuesDto FndComplaintTypeLkp { get; set; }

        public FndLookupValuesDto FndUnitTypeLkp { get; set; }

        public FndLookupValuesDto FndRequisitionStatusLkp { get; set; }

        public PmPropertiesDto PmProperties { get; set; }

        public PmPropertiesUnitsDto PmPropertiesUnits { get; set; }
    }
}

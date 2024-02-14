using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr.Dto
{
    [AutoMap(typeof(FmMaintRequisitionsHdr))]
    public class FmMaintRequisitionsHdrCreateDto
    {
        [MaxLength(30)]
        public string RequisitionNumber { get;  set; }

        public long RequisitionStatusLkpId => 11048;

        public long PmPropertiesId { get;  set; }

        public long ComplaintTypeLkpId { get;  set; }

        public long? UnitTypeLkpId { get;  set; }

        public long? UnitId { get;  set; }

        public string RequisitionDate { get;  set; }

        public string RequisitionTime { get;  set; }

        [MaxLength(150)]
        public string CallerName { get;  set; }

        [MaxLength(30)]
        public string PhoneNumber { get;  set; }

        [MaxLength(30)]
        public string Mobile { get;  set; }

        [MaxLength(4000)]
        public string ComplaintDetails { get;  set; }
    }
}

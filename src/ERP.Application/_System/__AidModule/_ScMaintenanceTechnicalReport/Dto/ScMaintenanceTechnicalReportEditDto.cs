using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    [AutoMap(typeof(ScMaintenanceTechnicalReport))]

    public class ScMaintenanceTechnicalReportEditDto : EditEntityDto<long>
    {
        public string TechnicalReportDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long PortalRequestId { get; set; }

        public long? StatusLkpId { get; set; }

        public long? ScCommitteeDetailId { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public virtual ICollection<ScMaintenanceTechnicalReportDetailDto> ListOfDetails { get; set; }

        public virtual ICollection<ScMaintenanceTechnicalReportAttachmentsDto> ListOfAttachs { get; set; }
    }
}

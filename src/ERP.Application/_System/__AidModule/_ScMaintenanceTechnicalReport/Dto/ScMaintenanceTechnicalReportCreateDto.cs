using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    [AutoMap(typeof(ScMaintenanceTechnicalReport))]
    public class ScMaintenanceTechnicalReportCreateDto //: ScMaintenanceTechnicalReportBaseDto
    {
        public string TechnicalReportDate { get; set; }

        [MaxLength(30)]
        public string TechnicalReportNumber { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long PortalRequestId { get; set; }

        public long? ScCommitteeDetailId { get;  set; }

        public long StatusLkpId => 940;

        public ICollection<ScMaintenanceTechnicalReportDetailDto> ListOfDetails { get; set; }

        public virtual ICollection<ScMaintenanceTechnicalReportAttachmentsDto> ListOfAttachs { get; set; }
    }
}

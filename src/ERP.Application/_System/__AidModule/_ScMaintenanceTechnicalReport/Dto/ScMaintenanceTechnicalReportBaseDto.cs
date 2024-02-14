using ERP._System._FndLookupValues.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__AidModule._ScMaintenanceTechnicalReport.Dto
{
    public class ScMaintenanceTechnicalReportBaseDto
    {
        public string TechnicalReportDate { get; set; }

        [MaxLength(4000)]
        public string Notes { get; set; }

        public long PortalRequestId { get; set; }

        public long? StatusLkpId { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }
    }
}

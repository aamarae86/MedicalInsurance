using System;

namespace ERP.Web.UI.Models.ReportModels
{
    public class ScCampainssScreenDataOutput
    {
        public string CampainName { get; set; }

        public string CampainNumber { get; set; }

        public string Name { get; set; }

        public string IdNumber { get; set; }

        public string AidName { get; set; }

        public string NameAr { get; set; }

        public long RelativeCount { get; set; }

        public string Notes { get; set; }

        public DateTime ScCampainDate { get; set; }

        public long StatusLkpId { get; set; }
    }
}
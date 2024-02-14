using System;

namespace ERP.Web.UI.Models.ReportModels
{
    public class GetScMaintenanceContractScreenDataOutputDto
    {
        public string MaintenanceContractNumber { get; set; }

        public long StatusLkpId { get; set; }

        public string Status { get; set; }

        public DateTime MaintenanceContractDate { get; set; }

        public string QuotationNumber { get; set; }

        public string PortalRequestNumber { get; set; }

        public string CaseName { get; set; }

        public string VendorNameAr { get; set; }

        public string VendorNameEn { get; set; }

        public decimal TotalVal { get; set; }

        public string DurationOfImplementation { get; set; }

        public DateTime StartDate { get; set; }

        public string Notes { get; set; }

        public string ContractTerms { get; set; }

        public string OtherContractTerms { get; set; }

        public string DetailsPayemtNo { get; set; }

        public DateTime DetailsMaturityDate { get; set; }

        public decimal DetailsAmount { get; set; }

        public string DetailsPaymentCondition { get; set; }
    }
}
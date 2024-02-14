using ERP.Core.Helpers.Core;

namespace ERP._System.__AidModule._ScMaintenanceQuotations.Dto
{
    public class ScMaintenanceTechnicalReportQuotationsDto:Abp.Application.Services.Dto.EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string QuotationNumber { get; set; }

        public string QuotationDate { get; set; }

        public string StatusAr { get; set; }

        public string StatusEn { get; set; }

        public string VendorAr { get; set; }

        public string VendorEn { get; set; }

        public string VendorNumber { get; set; }

        public decimal TotalAmount { get; set; }
    }
}

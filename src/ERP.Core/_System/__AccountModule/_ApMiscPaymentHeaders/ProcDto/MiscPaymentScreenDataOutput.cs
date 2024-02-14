using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApMiscPaymentHeaders.ProcDto
{
    public class MiscPaymentScreenDataOutput
    {
        public long id { get; set; }
        public string PaymentNumber { get; set; }
        public DateTime MiscPaymentDate { get; set; }
        public string BeneficiaryName { get; set; }
        public decimal amount { get; set; }
        public string FileNo { get; set; }
        public string ResearcherName { get; set; }
        public string PaymentType { get; set; }
        public string BankAccountNameAr { get; set; }
        public string BankAccountNameEn { get; set; }
        public string Notes { get; set; }

        public string AccountCode { get; set; }
        public string AccountName { get; set; }
        public decimal MiscPaymentAmount { get; set; }
        public string TaxNo { get; set; }
        public string TaxAccountCode { get; set; }
        public string TaxAccountName { get; set; }
        public decimal trTax { get; set; }
        public decimal Total { get; set; }
        public string LinesNotes { get; set; }
        public string CheckNumber { get; set; }
        public DateTime MaturityDate { get; set; }
        public string DetailsBeneficiaryName { get; set; }
        public string DetailsNotes { get; set; }
        public decimal CheckAmount { get; set; }
        public string AmountTafqeet { get; set; }
        public string DType { get; set; }
        public string CostCenterName { get; set; }
    }
}

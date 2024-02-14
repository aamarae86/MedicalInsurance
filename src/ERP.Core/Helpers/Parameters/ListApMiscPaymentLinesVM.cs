
using ERP._System._FndTaxType;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Helpers.Parameters
{
    public class ListApMiscPaymentLinesVM : CodeComUtility, IDetailRowStatus
    {
        public int index { get; set; }

        public long? miscId { get; set; }

        public long? apMiscPaymentLinesId { get; set; }

        public decimal? miscPaymentAmount { get; set; }

        public string notes { get; set; }

        public string taxNo { get; set; }

        public decimal? trTax { get; set; }

        public long? TaxAccountId { get; set; }

        public string invoiceNumber { get; set; }

        public long? MiscPaymentId { get; set; }

        public string rowStatus { get; set; }

        public long? FndTaxTypeLkpId { get; set; }

        public string FndTaxTypeNameAr { get; set; }

        public string FndTaxTypeNameEn { get; set; }

        public long? TaxPercentageLkpId { get; set; }

        public string TaxPercentageNameAr { get; set; }

        public string TaxPercentageNameEn { get; set; }
       
    }
}

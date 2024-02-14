using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__CharityBoxes._TmCharityBoxCollect.ProcDto
{
    public class TmCharityBoxCollectScreenDataOutput
    {
        public long Id { get; set; }
        public string CollectNumber { get; set; }
        public DateTime CollectDate { get; set; }
        public string CollectStatus { get; set; }
        public string Notes { get; set; }
        public string BankAccountNameAr { get; set; }
        public string CharityBoxBarcode { get; set; }
        public string CharityBoxName { get; set; }
        public string locationSub { get; set; }
        public string MemberNumber { get; set; }
        public string MemberName { get; set; }
        public string MemberCategory { get; set; }
        public decimal TotalAmount { get; set; }
        public string DType { get; set; }

        public decimal Value25F { get; set; }
        public decimal Value50F { get; set; }
        public decimal Value1Dh { get; set; }
        public decimal Value5Dh { get; set; }
        public decimal Value10Dh { get; set; }
        public decimal Value20Dh { get; set; }
        public decimal Value50Dh { get; set; }
        public decimal Value100Dh { get; set; }
        public decimal Value200Dh { get; set; }
        public decimal Value500Dh { get; set; }
        public decimal Value1000Dh { get; set; }
    }
}

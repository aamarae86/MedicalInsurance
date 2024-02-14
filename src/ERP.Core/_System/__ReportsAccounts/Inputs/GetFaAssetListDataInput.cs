using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__ReportsAccounts.Inputs
{
    public class GetFaAssetListDataInput
    {
        public int TenantId { get; set; }
        public string Lang { get; set; }
        public long? FaAssetCategoryId { get; set; }
        public string Description { get; set; }
        public long? StatusLkpId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class GetFaAssetListDataInputHelper
    {
        public int TenantId { get; set; }
        public string Lang { get; set; }
        public long? FaAssetCategoryId { get; set; }
        public string FaAssetCategoryIdtxt { get; set; }
        public string Description { get; set; }
        public long? StatusLkpId { get; set; }
        public string StatusLkpIdtxt { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public override string ToString()
        {
            return $"?Lang={Lang}&TenantId={TenantId}&FaAssetCategoryId={FaAssetCategoryId}&Description={Description}&StatusLkpId={StatusLkpId}&FromDate={FromDate}&ToDate={ToDate}";
        }
    }
}

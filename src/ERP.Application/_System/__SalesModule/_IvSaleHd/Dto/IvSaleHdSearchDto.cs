using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__SalesModule._IvSaleHd.Dto
{
    public class IvSaleHdSearchDto
    {

        public string IvSaleNumber { get; set; }
        public long StatusLkpId { get; set; }
        //public DateTime IvSaleDate { get; set; }
        public string IvSaleDate { get; set; }
        public string LpoNo { get; set; }
        public long IvPriceListHdId { get; set; }
        public string Comments { get; set; }
        public long IvWarehouseId { get; set; }
        public int CurrencyId { get; set; }
        public decimal CurrencyRate { get; set; }
        public long? FndSalesMenId { get; set; }
        public bool IsCash { get; set; }
        public long ArCustomerId { get; set; }
        public decimal? DiscAmount { get; set; }
        public decimal? DiscPercentage { get; set; }
        public override string ToString() => $"Params.IvSaleNumber={IvSaleNumber}&Params.StatusLkpId={StatusLkpId}&Params.IvWarehouseId={IvWarehouseId}&Params.ArCustomerId={ArCustomerId}&Params.LpoNo={LpoNo}&Params.IvSaleDate={IvSaleDate}&Params.FndSalesMenId={FndSalesMenId}";

    }
}



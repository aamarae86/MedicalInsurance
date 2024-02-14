using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__Warehouses._IvPriceListHd.Dto
{
    [AutoMap(typeof(IvPriceListTr))]
    public class IvPriceListTrDto : EntityDto<long>, IDetailRowStatus
    {
        public long IvPriceListHdId { get; set; }
        public long IvItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public string rowStatus { get; set; }


    }
}

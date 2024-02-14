using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SalesModule._FndSalesMen.Dto
{
    
    [AutoMap(typeof(FndSalesMen))]
    public class FndSalesMenEditDto : EntityDto<long>
    {
        [MaxLength(200)]
        public string SalesManNameAr { get; set; }

        [MaxLength(200)]
        public string SalesManNameEn { get; set; }

        public bool IsActive { get; set; }

        public long? UserId { get; set; }
        public int? DiscountPercentageAllowed { get; set; }
    }
}

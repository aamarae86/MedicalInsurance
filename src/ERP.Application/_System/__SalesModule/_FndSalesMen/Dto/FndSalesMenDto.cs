using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Users.Dto;
using System.ComponentModel.DataAnnotations;

namespace ERP._System.__SalesModule._FndSalesMen.Dto
{

    [AutoMap(typeof(FndSalesMen))]
    public class FndSalesMenDto : AuditedEntityDto<long>
    {
        public string SalesManNo { get; set; }

        [MaxLength(200)]
        public string SalesManNameAr { get; set; }

        [MaxLength(200)]
        public string SalesManNameEn { get; set; }

        public bool IsActive { get; set; }

        public long? UserId { get; set; }
        public UserDto User { get; set; }
        public int? DiscountPercentageAllowed { get; set; }

    }
}

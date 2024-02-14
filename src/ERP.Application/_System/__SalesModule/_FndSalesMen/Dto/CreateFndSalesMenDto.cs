using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__SalesModule._FndSalesMen.Dto
{

    [AutoMap(typeof(FndSalesMen))]
    public class CreateFndSalesMenDto
    {
        public string Lang { get; set; }
        public string SalesManNo { get; set; } 
        
        [MaxLength(200)]
        public string SalesManNameAr { get; set; }
        
        [MaxLength(200)]
        public string SalesManNameEn { get; set; }

        public bool IsActive { get; set; }

        public long? UserId { get; set; }
        public int? DiscountPercentageAllowed { get;  set; }
    }
}

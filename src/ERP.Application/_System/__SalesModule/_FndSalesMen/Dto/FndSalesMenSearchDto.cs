using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;


namespace ERP._System.__SalesModule._FndSalesMen.Dto
{  

    [AutoMapFrom(typeof(FndSalesMen))]
    public class FndSalesMenSearchDto
    {
        public string SalesManNo { get; set; }
        public string SalesManNameAr { get; set; }
        public string SalesManNameEn { get; set; }
        public bool? IsActive { get; set; }

        public override string ToString()
        {
            return $"Params.SalesManNameAr={SalesManNameAr}&Params.SalesManNameEn={SalesManNameEn}&Params.SalesManNo={SalesManNo}&Params.IsActive={IsActive}";
        }
       
    }
}

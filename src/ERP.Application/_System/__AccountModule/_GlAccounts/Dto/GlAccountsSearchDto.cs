using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._GlAccounts.Dto
{
    [AutoMapFrom(typeof(GlAccounts))]
    public class GlAccountsSearchDto
    {
        public string Code { get;  set; }
        public string DescriptionEn { get;  set; }
        public string DescriptionAr { get;  set; }
        public override string ToString()
        {
            return $"Params.Code={Code}&Params.DescriptionEn={DescriptionEn}&Params.DescriptionAr={DescriptionAr}";
        }
    }
}

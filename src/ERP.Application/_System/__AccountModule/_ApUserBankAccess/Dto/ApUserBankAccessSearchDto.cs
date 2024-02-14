using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApUserBankAccess.Dto
{
    [AutoMapFrom(typeof(ApUserBankAccess))]
    public class ApUserBankAccessSearchDto
    {
        public long UserId { get; set; }
        public override string ToString()
        {
            return $"Params.UserId={UserId}";
        }
    }
}

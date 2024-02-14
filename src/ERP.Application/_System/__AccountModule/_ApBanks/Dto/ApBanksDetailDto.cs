using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._FndLookupValues.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ApBanks.Dto
{
    [AutoMapFrom(typeof(ApBanks))]
    public class ApBanksDetailDto : EntityDto<long>
    {
        public string BankNameAr { get; set; }
        public string BankNameEn { get; set; }
        public long BankTypeLkpId { get; set; }
        public bool IsActive { get; set; }

        public FndLookupValuesDto FndLookupValues { get; set; }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;

namespace ERP.Currencies.Dto
{
    [AutoMapFrom(typeof(Currency))]
    public class CurrencyListDto : EntityDto, IHasCreationTime
    {
        public string Code { get; set; }

        public string DescriptionAr { get; set; }

        public string DescriptionEn { get; set; }

        public decimal Rate { get; set; }

        public bool IsLocalCurrency { get; set; }
        public bool IsActive { get; set; }

        public DateTime CreationTime { get; set; }
    }
}

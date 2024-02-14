using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__PmPropertiesModule._PmPropertiesAttachments.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts.Dto;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits.Dto;
using ERP.Core.Helpers.Core;
using System;
using System.Collections.Generic;

namespace ERP._System.__PmPropertiesModule._PmProperties.Dto
{
    [AutoMap(typeof(PmProperties))]
    public class PmPropertiesEditDto : EntityDto<long>
    {
        public string PropertyNameAr { get; set; }

        public string PropertyNameEn { get; set; }

        public string LandNumber { get; set; }

        public string MilkiyaNumber { get; set; }

        public string Region { get; set; }

        public string Address { get; set; }

        public string Notes { get; set; }

        public decimal? PropertyValue { get; set; }

        public decimal? CommissionPercentage { get; set; }

        public string CompletionDate { get; set; }

        public int? NoOfFloors { get; set; }

        public long PmOwnerId { get; set; }

        public long BankAccountId { get; set; }

        public long StatusLkpId { get; set; }

        public long? CountryLkpId { get; set; }

        public long? CityLkpId { get; set; }

        public long? CommissionTypeLkpId { get; set; }

        public long? PmPurposeLkpId { get; set; }

        public ICollection<PmPropertiesAttachmentsDto> PropAttachments { get; set; }

        public ICollection<PmPropertiesRevenueAccountsDto> PropRevenues { get; set; }

        public ICollection<PmPropertiesUnitsDto> PropUnits { get; set; }
    }
}

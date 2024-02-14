﻿using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ApVendors;

namespace ERP._System.__AccountModule._ApVendors.Dto
{
    [AutoMap(typeof(ApVendors))]
    public class ApVendorsEditDto : EntityDto<long>
    {
        public string VendorNameAr { get; set; }

        public string VendorNameEn { get; set; }

        public long VendorCategoryLkpId { get; set; }

        public string TaxNo { get; set; }

        public string Comments { get; set; }

        public string Address { get; set; }

        public string WorkTel { get; set; }

        public string Mobile { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public long StatusLkpId { get; set; }
    }
}
using Abp.AutoMapper;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System.__Warehouses;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System._ArCustomers;
using ERP._System._FndLookupValues;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlPeriods.Dto;
using ERP.Authorization.Users;
using ERP.Core.Helpers.Core;
using ERP.Currencies;
using ERP.Helpers.Core.__PostAudited;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERP._System._FndTaxType
{
    [AutoMap(typeof(FndTaxType))]
    public class FndTaxTypeDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());
  
        [MaxLength(30)]
        public string TaxTypeNumber { get; set; }
        [MaxLength(200)]
      
        public string TaxNameAr { get; set; }
     
        [MaxLength(200)]
        public string TaxNameEn { get; set; }
     
        public decimal Percentage { get; set; }


    }
}

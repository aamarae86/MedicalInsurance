using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System.__AccountModule._ApVendors.Dto;
using ERP._System._FndLookupValues.Dto;
using ERP._System._GlCodeComDetails.Dto;
using ERP.Core.Helpers.Core;
using ERP.Currencies.Dto;
using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System.__AccountModule._ApInvoiceHd.Dto
{
    [AutoMap(typeof(ApInvoiceHd))]
    public class ApInvoiceHdDto : PostAuditedEntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string codeComUtilityIds { get; set; }
        public string codeComUtilityTexts { get; set; }

        public string codeComUtilityIds_alt1 { get; set; }
        public string codeComUtilityTexts_alt1 { get; set; }

        public string codeComUtilityIds_alt2 { get; set; }
        public string codeComUtilityTexts_alt2 { get; set; }

        public string codeComUtilityIds_alt3 { get; set; }
        public string codeComUtilityTexts_alt3 { get; set; }

        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string HdInvNo { get; set; }

        public string HdDate { get; set; }

        public decimal CurrencyRate { get; set; }

        public decimal? PrepaidAmount { get; set; }

        public string Comments { get; set; }

        public int? PrepaidPeriod { get; set; }

        public long StatusLkpId { get; set; }

        public long HdTypeLkpId { get; set; }

        public long VendorId { get; set; }

        public int CurrencyId { get; set; }

        public long? FromAccountId { get; set; }

        public long? ToAccountId { get; set; }

        public string TaxNo { get; set; }

        public ApVendorsDto ApVendors { get; set; }

        public CurrencyDto Currency { get; set; }

        public FndLookupValuesDto FndStatusLkp { get; set; }

        public FndLookupValuesDto FndHdTypeLkp { get; set; }

        public GlCodeComDetailsDto FromGlCodeComDetails { get; set; }

        public GlCodeComDetailsDto ToGlCodeComDetails { get; set; }

        public ICollection<ApInvoiceTrDto> InvoiceDetails { get; set; }
    }
}

using Abp.AutoMapper;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._FndLookupValues.Dto;
using ERP._System._FndTaxType;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto
{
    [AutoMap(typeof(ApMiscPaymentHeaders))]
    public class CreateApMiscPaymentHeadersDto
    {
        public string PaymentNumber { get; set; }

        public string MiscPaymentDate { get; set; }

        public string Notes { get; set; }

        public string BeneficiaryName { get; set; }

        public decimal? Amount { get; set; }

        public bool? AccPayeeOnly { get; set; }

        public long? BankAccountId { get; set; }

        public long? PaymentTypeLkpId { get; set; }

        public long? PostedlkpId => Convert.ToInt64(FndEnum.FndLkps.New_ApMiscPaymentHeadersPost);

        public long? SourceCodeLkpId => Convert.ToInt64(FndEnum.FndLkps.ApMiscPaymentHeadersSourceCode);

        public long? SourceId { get; set; }

        public string Lang { get; set; }

        public FndTaxTypeDto FndTaxTypeLkp { get;  set; }
        public List<ListApMiscPaymentDetailsVM> ListApMiscPaymentDetailsVM { get; set; }
        public List<ListApMiscPaymentLinesVM> ListApMiscPaymentLinesVM { get; set; }
    }
}

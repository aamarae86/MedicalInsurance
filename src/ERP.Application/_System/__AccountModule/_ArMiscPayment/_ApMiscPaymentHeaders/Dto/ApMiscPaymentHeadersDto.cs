using Abp.AutoMapper;
using ERP._System._ApBankAccounts.Dto;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._FndLookupValues.Dto;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Core.__PostAudited;
using ERP.Helpers.Parameters;
using System.Collections.Generic;

namespace ERP._System._ArMiscPayment._ApMiscPaymentHeaders.Dto
{
    [AutoMap(typeof(ApMiscPaymentHeaders))]
    public class ApMiscPaymentHeadersDto : PostAuditedEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string PortalUserName { get; set; }

        public long FirstLinePortalUserId { get; set; }

        public string CheckNumber { get; set; }

        public string PaymentNumber { get; set; }

        public string MiscPaymentDate { get; set; }

        public string Notes { get; set; }

        public string BeneficiaryName { get; set; }

        public decimal? Amount { get; set; }

        public bool? AccPayeeOnly { get; set; }

        public long? BankAccountId { get; set; }

        public long? PaymentTypeLkpId { get; set; }

        public long? PostedlkpId { get; set; }

        public long? SourceCodeLkpId { get; set; }

        public long? SourceId { get; set; }

        public List<ListApMiscPaymentDetailsVM> ListApMiscPaymentDetailsVM { get; set; }
        public List<ListApMiscPaymentLinesVM> ListApMiscPaymentLinesVM { get; set; }

        public FndLookupValuesDto FndLookupValuesPostedPaymentLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesPaymentTypeLkp { get; set; }

        public FndLookupValuesDto FndLookupValuesSourceCodePaymentLkp { get; set; }

        public ApBankAccountsDto ApBankAccounts { get; set; }

    }
}

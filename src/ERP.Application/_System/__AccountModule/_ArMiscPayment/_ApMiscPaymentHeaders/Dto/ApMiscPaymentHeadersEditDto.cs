using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ApMiscPaymentHeaders;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;

namespace ERP._System.__AccountModule._ArMiscPayment._ApMiscPaymentHeaders.Dto
{
    [AutoMap(typeof(ApMiscPaymentHeaders))]
    public class ApMiscPaymentHeadersEditDto : EntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string MiscPaymentDate { get; set; }

        public string BeneficiaryName { get; set; }

        public decimal? Amount { get; set; }

        public bool? AccPayeeOnly { get; set; }

        public long? BankAccountId { get; set; }

        public long? PaymentTypeLkpId { get; set; }

        public string Notes { get; set; }

        public List<ListApMiscPaymentDetailsVM> ListApMiscPaymentDetailsVM { get; set; }

        public List<ListApMiscPaymentLinesVM> ListApMiscPaymentLinesVM { get; set; }
    }
}

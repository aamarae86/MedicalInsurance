using Abp.AutoMapper;
using ERP._System._ApMiscPaymentDetails;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._ArMiscPayment._ApMiscPaymentDetails.Dto
{
    [AutoMap(typeof(ApMiscPaymentDetails))]
    [AutoMapTo(typeof(ApMiscPaymentDetails))]
    [AutoMapFrom(typeof(ApMiscPaymentDetails))]
    public class ApMiscPaymentDetailsDto
    {
        public string CheckNumber { get;  set; }

        public string BeneficiaryName { get;  set; }

        public decimal? Amount { get;  set; }

        public string Notes { get;  set; }

        public DateTime? MaturityDate { get;  set; }

        public long? MiscPaymentId { get;  set; }
    }
}

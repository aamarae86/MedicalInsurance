using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Helpers.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmOtherContractPayments.Dto
{
    [AutoMap(typeof(PmOtherContractPayments))]
    public class PmOtherContractPaymentsDto : EntityDto<long>, IDetailRowStatus
    {
        public long OtherPaymentTypesId { get;  set; }

        public string OtherPaymentTypes { get;  set; }

        public long PmContractId { get;  set; }

        public decimal Amount { get;  set; }

        [MaxLength(4000)]
        public string Notes { get;  set; }

        public string rowStatus { get; set; }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP._System._ArSecurityDepositInterface;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArSecurityDepositInterface.Dto
{
    [AutoMap(typeof(ArSecurityDepositInterface))]
    public class ArSecurityDepositInterfaceEditDto : EntityDto<long>, ICodeComUtilityIds, ICodeComUtilityTexts
    {
        public string SecurityDepositInterfaceNumber { get; set; }

        public decimal? Amount { get; set; }

        public string Notes { get; set; }

        public decimal? FineAmount { get; set; }

        public long? ArCustomerId { get; set; }

        public long? FineAccountId { get; set; }

        public string SourceNo { get; set; }

        public string codeComUtilityIds { get; set; }

        public string codeComUtilityTexts { get; set; }

    }
}

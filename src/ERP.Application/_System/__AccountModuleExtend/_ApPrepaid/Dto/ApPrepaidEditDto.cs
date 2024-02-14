using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ERP.Core.Helpers.Core;
using ERP.Helpers.Parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModuleExtend._ApPrepaid.Dto
{
    [AutoMap(typeof(ApPrepaid))]
    public class ApPrepaidEditDto : CodeComUtility, IEntityDto<long>
    {
        public string EncId => CipherStringController.Encrypt(this.Id.ToString());

        public string SourceNo { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TransactionDateStr { get; set; }

        public decimal Amount { get; set; }

        public long? DrAccountId { get; set; }

        public long? CrAccountId { get; set; }

        public long? SourceId { get; set; }

        public long SourceCodeLkpId { get; set; }

        public long Id { get; set; }
    }
}

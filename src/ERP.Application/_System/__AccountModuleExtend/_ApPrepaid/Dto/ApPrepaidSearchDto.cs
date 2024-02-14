using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModuleExtend._ApPrepaid.Dto
{
    public class ApPrepaidSearchDto
    {
        public string SourceNo { get; set; }

        public string TransactionDate { get; set; }

        public long? StatusLkpId { get; set; }

        public long? SourceCodeLkpId { get; set; }

        public override string ToString() => $"Params.SourceNo={SourceNo}&Params.TransactionDate={TransactionDate}&Params.SourceCodeLkpId={SourceCodeLkpId}&Params.StatusLkpId={StatusLkpId}";

    }
}

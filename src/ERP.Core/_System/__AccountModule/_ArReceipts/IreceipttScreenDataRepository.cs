using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArReceipts
{
    public interface IGetReceiptScreenDataRepository : IExecuteProcedure<ArReceipts, long, IdLangInputDto, receipttScreenDataOutput>
    {
    }
}

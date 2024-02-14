using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._ArJobCardHd
{
    public interface IArJobCardRepository : IExecuteProcedure<ArJobCardHd, long, PostDto, PostOutput>
    {
    }
}

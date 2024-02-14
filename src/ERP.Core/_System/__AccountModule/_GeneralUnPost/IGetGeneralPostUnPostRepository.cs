using ERP._System.__AccountModule._GeneralUnPost.Input;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._GeneralUnPost
{
    public interface IGetGeneralPostUnPostRepository:
        IExecuteProcedure<GeneralUnPost, long, GeneralPostUnPostInput, PostOutput>
    {
    }
}

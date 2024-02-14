using ERP._System.__AccountModule._GeneralUnPost.Input;
using ERP._System.__AccountModule._GeneralUnPost.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AccountModule._GeneralUnPost
{
    public interface IGetGeneralPostNotesRepository:
        IExecuteProcedure<GeneralUnPost, long, GetGeneralPostNotesInput, GetGeneralPostNotesOutput>
    {
    }
}

using ERP._System.__AidModule._ScCommittee.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScCommittee.Proc
{
    public interface IGetScCommitteesScreenDataRepository
        : IExecuteProcedure<ScCommittee, long, IdLangInputDto, ScCommitteeScreenDataOutput>
    {
    }
}

using ERP._System.__AidModule._ScPortalRequestStudy.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScPortalRequestStudy.Proc
{
    public interface IGetScPortalRequestStudyScreenDataRepository
        : IExecuteProcedure<ScPortalRequestStudy, long, IdLangInputDto, ScPortalRequestStudyScreenDataOutput>
    {
    }
}

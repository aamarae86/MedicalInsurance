using ERP._System.__AidModule._ScCampains.Outputs;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__AidModule._ScCampains.Procs
{
    public interface IGetScCampainssScreenDataRepository : IExecuteProcedure<ScCampains, long, IdLangInputDto, ScCampainssScreenDataOutput>
    {
    }
}

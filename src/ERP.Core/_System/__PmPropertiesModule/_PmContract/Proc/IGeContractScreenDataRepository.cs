using ERP._System.__PmPropertiesModule._PmContract.ProcDto;
using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmContract.Proc
{
    public interface IGeContractScreenDataRepository : IExecuteProcedure<PmContract, long, IdLangInputDto, GeContractScreenDataOutput>
    {
    }
}

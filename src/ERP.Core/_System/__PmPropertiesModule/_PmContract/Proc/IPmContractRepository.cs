using ERP._System.PostRecords.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.__PmPropertiesModule._PmContract.Proc
{
    public interface IPmContractRepository : IExecuteProcedure<PmContract, long, PostDto, PostOutput>
    {
    }
}

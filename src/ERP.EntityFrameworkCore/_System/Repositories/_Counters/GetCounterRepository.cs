using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System._Counters;
using ERP._System._Counters.ProcDto;
using ERP._System._Counters.Procs;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;

namespace ERP._System.Repositories._Counters
{
    public class GetCounterRepository :
        ERPProcedureRepositoryBase<Counters, long, GetCounterInputDto, StringOutput>,
        IGetCounterRepository
    {
        public GetCounterRepository
          (   
              IDbContextProvider<ERPDbContext> dbContextProvider,
              IActiveTransactionProvider activeTransactionProvider
          ) : base(dbContextProvider, activeTransactionProvider)
        { }

    }
}

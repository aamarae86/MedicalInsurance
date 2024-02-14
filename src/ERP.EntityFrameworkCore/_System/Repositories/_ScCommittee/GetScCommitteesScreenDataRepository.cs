using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScCommittee.Proc;
using ERP._System.__AidModule._ScCommittee.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ScCommittee
{
    public class GetScCommitteesScreenDataRepository :
           ERPProcedureRepositoryBase<ScCommittee, long, IdLangInputDto, ScCommitteeScreenDataOutput>,
        IGetScCommitteesScreenDataRepository
    {

        public GetScCommitteesScreenDataRepository(
              IDbContextProvider<ERPDbContext> dbContextProvider,
              IActiveTransactionProvider activeTransactionProvider
          ) : base(dbContextProvider, activeTransactionProvider)
        {
        }

    }
}

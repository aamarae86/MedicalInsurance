using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__AidModule._ScPortalRequestStudy.Proc;
using ERP._System.__AidModule._ScPortalRequestStudy.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ScPortalRequestStudy
{
    public class GetScPortalRequestStudyScreenDataRepository :
           ERPProcedureRepositoryBase<ScPortalRequestStudy, long, IdLangInputDto, ScPortalRequestStudyScreenDataOutput>,
        IGetScPortalRequestStudyScreenDataRepository
    {
        public GetScPortalRequestStudyScreenDataRepository(
                 IDbContextProvider<ERPDbContext> dbContextProvider,
                 IActiveTransactionProvider activeTransactionProvider
             ) : base(dbContextProvider, activeTransactionProvider)
        {
        }
    }
}

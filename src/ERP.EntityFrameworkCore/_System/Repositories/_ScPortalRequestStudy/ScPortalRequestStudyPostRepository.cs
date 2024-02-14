using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__AidModule._ScPortalRequestStudy.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ScPortalRequestStudy
{
    public class ScPortalRequestStudyPostRepository:
        ERPProcedureRepositoryBase<ScPortalRequestStudy, long, PostDto, PostOutputWithId>,
        IScPortalRequestStudyPostRepository
    {
        public ScPortalRequestStudyPostRepository(
               IDbContextProvider<ERPDbContext> dbContextProvider,
               IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}

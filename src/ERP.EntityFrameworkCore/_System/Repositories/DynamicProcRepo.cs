using Abp.Data;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories
{
    public class DynamicProcRepo<TEntity, TPrimaryKey>:
               ERPDynamicProcedureRepositoryBase<TEntity, TPrimaryKey>,
        IERPDynamicProcedureRepositoryBase<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {

        public DynamicProcRepo  (IDbContextProvider<ERPDbContext> dbContextProvider,
               IActiveTransactionProvider activeTransactionProvider ) 
            :  base(dbContextProvider, activeTransactionProvider)
        { }
    }
}

using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories
{
    public class ArJobCardRepository :   ERPProcedureRepositoryBase<ArJobCardHd, long, PostDto, PostOutput>
        ,
        IArJobCardRepository
    {
        public ArJobCardRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}

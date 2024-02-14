using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmContract.Proc;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._PmContract
{
    public class PmContractRepository :
        ERPProcedureRepositoryBase<PmContract, long, PostDto, PostOutput>, IPmContractRepository
    {
        public PmContractRepository(
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}

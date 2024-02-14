using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmContract.Proc;
using ERP._System.__PmPropertiesModule._PmContract.ProcDto;
using ERP._System.PostRecords.Dto;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._PmContract
{
    public class GeContractScreenDataRepository:
        ERPProcedureRepositoryBase<PmContract, long, IdLangInputDto, GeContractScreenDataOutput>, IGeContractScreenDataRepository
    {
        public GeContractScreenDataRepository(
                   IDbContextProvider<ERPDbContext> dbContextProvider,
                   IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider)
        { }
    }
}

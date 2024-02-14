using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__CharityBoxes._TmCharityBoxes;
using ERP._System.__ReportsTms.Inputs;
using ERP._System.__ReportsTms.Outputs;
using ERP._System.__ReportsTms.Proc;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._ReportsTms
{
    public class TmCharityBoxListScreenDataRepository :
           ERPProcedureRepositoryBase<TmCharityBoxes, long, TmCharityBoxListScreenDataInput, TmCharityBoxListScreenDataOutput>, ITmCharityBoxListScreenDataRepository
    {
        public TmCharityBoxListScreenDataRepository(
         IDbContextProvider<ERPDbContext> dbContextProvider,
         IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}

﻿using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP._System.__Warehouses._IvItems;
using ERP._System._GlAccDetails;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ERP._System.Repositories._ReportsAccounts
{
    public class VendorItemReportRepository :
           ERPProcedureRepositoryBase<IvItems, long, VendorItemReportInput, GetVendorItemReportDataOutput>, IVendorItemReportRepository
    {
        public VendorItemReportRepository(
         IDbContextProvider<ERPDbContext> dbContextProvider,
         IActiveTransactionProvider activeTransactionProvider) : base(dbContextProvider, activeTransactionProvider) { }
    }
}
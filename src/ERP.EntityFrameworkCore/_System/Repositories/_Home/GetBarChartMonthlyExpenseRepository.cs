using Abp.Data;
using Abp.EntityFrameworkCore;
using ERP._System.Home.Input;
using ERP._System.Home.Ouput;
using ERP._System.Home.Proc;
using ERP.Authorization.Users;
using ERP.EntityFrameworkCore;
using ERP.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Repositories._Home
{
   public class GetBarChartMonthlyExpenseRepository :
        ERPProcedureRepositoryBase<User, long, GetBarChartMonthlyExpenseInput, GetBarChartMonthlyExpenseOutput>
        ,
        IGetBarChartMonthlyExpenseRepository
    {
        public GetBarChartMonthlyExpenseRepository
            (
                IDbContextProvider<ERPDbContext> dbContextProvider,
                IActiveTransactionProvider activeTransactionProvider
            ) :
            base(dbContextProvider, activeTransactionProvider)
        {

        }
    }
}

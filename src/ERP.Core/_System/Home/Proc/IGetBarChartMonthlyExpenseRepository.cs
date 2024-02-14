using ERP._System.Home.Input;
using ERP._System.Home.Ouput;
using ERP.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System.Home.Proc
{
   public interface IGetBarChartMonthlyExpenseRepository : IExecuteProcedure<User, long, GetBarChartMonthlyExpenseInput, GetBarChartMonthlyExpenseOutput>
    {
    }
}

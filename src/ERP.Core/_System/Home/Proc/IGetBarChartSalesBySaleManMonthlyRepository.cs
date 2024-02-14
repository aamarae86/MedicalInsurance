using ERP._System.Home.Input;
using ERP._System.Home.Ouput;
using ERP.Authorization.Users;

namespace ERP._System.Home.Proc
{
    public interface IGetBarChartSalesBySaleManMonthlyRepository : IExecuteProcedure<User, long, GetBarChartSalesBySaleManInput, GetBarChartItemSoldbyValueOutput>
    { }
}

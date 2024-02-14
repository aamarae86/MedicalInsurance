using ERP._System.Home.Input;
using ERP._System.Home.Ouput;
using ERP.Authorization.Users;

namespace ERP._System.Home.Proc
{
    public interface IGetBarChartItemSoldbyValueRepository : IExecuteProcedure<User, long, GetTopGraphHomePageInput, GetBarChartItemSoldbyValueOutput>
    { }
}

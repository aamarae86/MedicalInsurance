using ERP._System.__HR._HrPersonVacations.Input;
using ERP._System.__HR._HrPersonVacations.Output;

namespace ERP._System.__HR._HrPersonVacations.Proc
{
    public interface IGetVacationsBalanceRepository : IExecuteProcedure<HrPersonVacations, long, GetVacationsBalanceInput, GetVacationsBalanceOutput>
    { }

}

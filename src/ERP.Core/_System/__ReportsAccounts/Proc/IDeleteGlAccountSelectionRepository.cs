using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using ERP._System._GlAccDetails;

namespace ERP._System.__ReportsAccounts.Proc
{
    public interface IDeleteGlAccountSelectionRepository :
        IExecuteProcedure<GlAccDetails, long, GlAccountSelectionDeleteInput, GlAccountSelectionOutput>
    {}
}

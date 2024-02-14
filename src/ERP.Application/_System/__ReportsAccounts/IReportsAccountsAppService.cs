using Abp.Application.Services;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Input;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Output;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ERP._System.__ReportsAccounts
{
    public interface IReportsAccountsAppService : IApplicationService
    {
        Task<List<GetFaAssetListDataOutput>> GetFaAssetListData(GetFaAssetListDataInputHelper input);

        Task<List<AccountsStatmentOutput>> GetAccountStatment(AccountsStatmentHelperInput input);

        Task<GlAccountSelectionOutput> GlAccountSelection(GlAccountSelectionHelperInput input);

        Task<GlAccountSelectionOutput> GlInsertAccountSelection(GlAccountSelectionInput input);

        Task<GlAccountSelectionOutput> GlDeleteAccountSelection(GlAccountSelectionDeleteInput input);

        Task<List<GlAccBalanceSheetOutput>> GetGeneralBALANCE_SHEETRPT(GlAccBalanceInput input);

        Task<List<GlAccBalanceOutput>> GetgltrialbalancesRPT(GlAccBalanceInput input);

        Task<List<GlAccProLosOutput>> GetGeneralProLosRPT(GlAccBalanceInput input);

        Task<GlAccountSelectionOutput> PrepareRPT(PrepareRPTInput input);

        Task<List<GlAccountsScreenDatarptOutput>> GetGlAccountsScreenDatarpt(GlAccountsScreenDatarptInput input);

        Task<List<rptGlAccMappingHdOutput>> GetrptGlAccMappingHd(rptGlAccMappingHdInput input);

        Task<List<GetArSecurityDepositInterfacerptOutput>> GetArSecurityDepositInterfacerpt(GetArSecurityDepositInterfacerptInput Input);
        
    }
}

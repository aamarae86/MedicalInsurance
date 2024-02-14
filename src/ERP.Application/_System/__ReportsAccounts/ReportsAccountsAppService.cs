using Abp.Domain.Uow;
using ERP._System.___SpHelpers;
using ERP._System.__AccountModule._ApPdcInterface.Proc;
using ERP._System.__AccountModule._ApPdcInterface.ProcDto;
using ERP._System.__AccountModule._ArSecurityDepositInterface;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Input;
using ERP._System.__AccountModule._ArSecurityDepositInterface.Output;
using ERP._System.__ReportsAccounts.Inputs;
using ERP._System.__ReportsAccounts.Outputs;
using ERP._System.__ReportsAccounts.Proc;
using ERP._System._SpDtos._TaxReportData;
using ERP._System._SpDtos._TaxReportData2;
using ERP.Helpers.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP._System.__ReportsAccounts
{
    [Abp.Authorization.AbpAuthorize]
    public class ReportsAccountsAppService : ERPAppServiceBase, IReportsAccountsAppService
    {
        private readonly IAccountsStatmentReportRepository _accountsStatmentReportRepository;
        private readonly IDeleteGlAccountSelectionRepository _deleteGlAccountSelectionRepository;
        private readonly IInsertGlAccountSelectionRepository _insertGlAccountSelectionRepository;
        private readonly IExecuteSpRepository _executeSpRepositoryRepository;
        private readonly IPrepareRPTRepository _prepareRPTRepository;
        private readonly IGlAccBalanceSheetRepository _glAccBalanceSheetRepository;
        private readonly IGlAccBalanceRepository _glAccBalanceRepository;
        private readonly IGlAccProLosRepository _glAccProLosRepository;
        private readonly IGlAccountsScreenDatarptRepository _glAccountsScreenDatarptRepository;
        private readonly IGetRptGlAccMappingHdRepository _getRptGlAccMappingHdRepository;
        private readonly IGetFaAssetListDataRepository _getFaAssetListDataRepository;
        private readonly IGetArSecurityDepositInterfacerptRepository _getArSecurityDepositInterfacerptRepository;
        private readonly IGetApPdcInterfaceDataRepository _getApPdcInterfaceDataRepository;
        private readonly IGetArPdcInterfaceDataRepository _getArPdcInterfaceDataRepository;

        public ReportsAccountsAppService(
            IGetFaAssetListDataRepository getFaAssetListDataRepository,
            IGetArSecurityDepositInterfacerptRepository getArSecurityDepositInterfacerptRepository,
            IPrepareRPTRepository prepareRPTRepository,
            IGlAccBalanceSheetRepository glAccBalanceSheetRepository,
            IGlAccBalanceRepository glAccBalanceRepository,
            IGlAccProLosRepository glAccProLosRepository, IGetApPdcInterfaceDataRepository getApPdcInterfaceDataRepository,
            IGetRptGlAccMappingHdRepository getRptGlAccMappingHdRepository,
            IGetArPdcInterfaceDataRepository getArPdcInterfaceDataRepository,
            IAccountsStatmentReportRepository accountsStatmentReportRepository,
            IDeleteGlAccountSelectionRepository deleteGlAccountSelectionRepository,
            IInsertGlAccountSelectionRepository insertGlAccountSelectionRepository,
            IExecuteSpRepository executeSpRepositoryRepository,

             IUnitOfWorkManager unitOfWorkManager,

            IGlAccountsScreenDatarptRepository glAccountsScreenDatarptRepository)
        {
            _getArSecurityDepositInterfacerptRepository = getArSecurityDepositInterfacerptRepository;
            _getFaAssetListDataRepository = getFaAssetListDataRepository;
            _getRptGlAccMappingHdRepository = getRptGlAccMappingHdRepository;
            _prepareRPTRepository = prepareRPTRepository;
            _glAccBalanceRepository = glAccBalanceRepository;
            _glAccBalanceSheetRepository = glAccBalanceSheetRepository;
            _glAccProLosRepository = glAccProLosRepository;
            _accountsStatmentReportRepository = accountsStatmentReportRepository;
            _deleteGlAccountSelectionRepository = deleteGlAccountSelectionRepository;
            _insertGlAccountSelectionRepository = insertGlAccountSelectionRepository;
            _executeSpRepositoryRepository = executeSpRepositoryRepository;

            _glAccountsScreenDatarptRepository = glAccountsScreenDatarptRepository;
            _getApPdcInterfaceDataRepository = getApPdcInterfaceDataRepository;
            _getArPdcInterfaceDataRepository = getArPdcInterfaceDataRepository;
        }

        public async Task<IReadOnlyList<GetApPdcInterfaceDataOutput>> GetApPdcInterfaceData(GetApPdcInterfaceDataInputHelper input)
        {
            var mapped = ObjectMapper.Map<GetApPdcInterfaceDataInput>(input);
           
            mapped.TenantId = AbpSession.TenantId.Value;
            
            var result = await _getApPdcInterfaceDataRepository.Execute(mapped, "GetApPdcInterfaceData");

            return result.ToList();
        }

        public async Task<IReadOnlyList<GetArPdcInterfaceDataOutput>> GetArPdcInterfaceData(GetArPdcInterfaceDataInputHelper input)
        {
            var mapped = ObjectMapper.Map<GetArPdcInterfaceDataInput>(input);

            mapped.TenantId = AbpSession.TenantId.Value;

            var result = await _getArPdcInterfaceDataRepository.Execute(mapped, "GetArPdcInterfaceData");

            return result.ToList();
        }

        public async Task<List<GetFaAssetListDataOutput>> GetFaAssetListData(GetFaAssetListDataInputHelper input)
        {
            input.TenantId = AbpSession.TenantId.Value;

            var mapped = ObjectMapper.Map<GetFaAssetListDataInput>(input);

            var result = await _getFaAssetListDataRepository.Execute(mapped, "GetFaAssetListData");
            return result.ToList();
        }

        public async Task<List<AccountsStatmentOutput>> GetAccountStatment(AccountsStatmentHelperInput input)
        {
            var mapped = ObjectMapper.Map<AccountsStatmentInput>(input);

            if (!string.IsNullOrEmpty(input.ToDateStr)) mapped.ToDate = DateTimeController.ConvertToDateTime(input.ToDateStr);
            if (!string.IsNullOrEmpty(input.FromDateStr)) mapped.FromDate = DateTimeController.ConvertToDateTime(input.FromDateStr);

            var result = await _accountsStatmentReportRepository.Execute(mapped, "rptGLStatementAccount");

            return result.ToList<AccountsStatmentOutput>();
        }

        public async Task<List<GlAccBalanceSheetOutput>> GetGeneralBALANCE_SHEETRPT(GlAccBalanceInput input)
        {
            input.User_ID = ((long)AbpSession.UserId).ToString();

            var result = await _glAccBalanceSheetRepository.Execute(input, "GetGeneralBalanceSheetrpt");

            return result.ToList();
        }

        public async Task<List<GlAccProLosOutput>> GetGeneralProLosRPT(GlAccBalanceInput input)
        {
            input.User_ID = ((long)AbpSession.UserId).ToString();

            var result = await _glAccProLosRepository.Execute(input, "GetGeneralProLosrpt");

            return result.ToList();
        }

        public async Task<List<GlAccBalanceOutput>> GetgltrialbalancesRPT(GlAccBalanceInput input)
        {
            input.User_ID = ((long)AbpSession.UserId).ToString();

            var result = await _glAccBalanceRepository.Execute(input, "GetGlTrialBalancesrpt");

            return result.ToList();
        }

        public async Task<GlAccountSelectionOutput> GlAccountSelection(GlAccountSelectionHelperInput input)
        {
            await GlDeleteAccountSelection(new GlAccountSelectionDeleteInput { User_ID = (long)AbpSession.UserId, TenantId = (int)AbpSession.TenantId });

            int lastLengthForAcc = input.YesNoAttrs.Where(z => z != null).ToList().Count;

            string accY_N = input.YesNoAttrs[lastLengthForAcc - 1];

            input.YesNoAttrs[lastLengthForAcc - 1] = null;

            for (int i = 0; i < 10; i++)
            {
                if (i == 0)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute1),
                        FromValue = input.FromCodeCom.Attribute1 == -1 ? null : input.FromCodeCom.Attribute1.ToString(),
                        ToValue = input.ToCodeCom.Attribute1 == -1 ? null : input.ToCodeCom.Attribute1.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 1)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute2),
                        FromValue = input.FromCodeCom.Attribute2 == -1 ? null : input.FromCodeCom.Attribute2.ToString(),
                        ToValue = input.ToCodeCom.Attribute2 == -1 ? null : input.ToCodeCom.Attribute2.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 2)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute3),
                        FromValue = input.FromCodeCom.Attribute3 == -1 ? null : input.FromCodeCom.Attribute3.ToString(),
                        ToValue = input.ToCodeCom.Attribute3 == -1 ? null : input.ToCodeCom.Attribute3.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 3)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute4),
                        FromValue = input.FromCodeCom.Attribute4 == -1 ? null : input.FromCodeCom.Attribute4.ToString(),
                        ToValue = input.ToCodeCom.Attribute4 == -1 ? null : input.ToCodeCom.Attribute4.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 4)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute5),
                        FromValue = input.FromCodeCom.Attribute5 == -1 ? null : input.FromCodeCom.Attribute5.ToString(),
                        ToValue = input.ToCodeCom.Attribute5 == -1 ? null : input.ToCodeCom.Attribute5.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 5)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute6),
                        FromValue = input.FromCodeCom.Attribute6 == -1 ? null : input.FromCodeCom.Attribute6.ToString(),
                        ToValue = input.ToCodeCom.Attribute6 == -1 ? null : input.ToCodeCom.Attribute6.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 6)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute7),
                        FromValue = input.FromCodeCom.Attribute7 == -1 ? null : input.FromCodeCom.Attribute7.ToString(),
                        ToValue = input.ToCodeCom.Attribute7 == -1 ? null : input.ToCodeCom.Attribute7.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 7)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute8),
                        FromValue = input.FromCodeCom.Attribute8 == -1 ? null : input.FromCodeCom.Attribute8.ToString(),
                        ToValue = input.ToCodeCom.Attribute8 == -1 ? null : input.ToCodeCom.Attribute8.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 8)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "C",
                        FLEX_FIELD = nameof(input.FromCodeCom.Attribute9),
                        FromValue = input.FromCodeCom.Attribute9 == -1 ? null : input.FromCodeCom.Attribute9.ToString(),
                        ToValue = input.ToCodeCom.Attribute9 == -1 ? null : input.ToCodeCom.Attribute9.ToString(),
                        YesNo = input.YesNoAttrs[i],
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else if (i == 9)
                {
                    var current = new GlAccountSelectionInput
                    {
                        SEQ = i + 1,
                        ACC_TYPE = "A",
                        FLEX_FIELD = nameof(input.FromCodeCom.AccId),
                        FromValue = input.FromCodeCom.AccId == -1 ? null : input.FromCodeCom.AccId.ToString(),
                        ToValue = input.ToCodeCom.AccId == -1 ? null : input.ToCodeCom.AccId.ToString(),
                        YesNo = accY_N,
                        User_ID = (long)AbpSession.UserId,
                        TenantId = (int)AbpSession.TenantId
                    };

                    await GlInsertAccountSelection(current);
                }
                else { }
            }

            await PrepareRPT(new PrepareRPTInput { PERIOD_ID_From = input.PERIOD_ID_From, PERIOD_ID_To = input.PERIOD_ID_To, user_id = (long)AbpSession.UserId ,lang=input.lang});

            return new GlAccountSelectionOutput();
        }

        public async Task<GlAccountSelectionOutput> GlDeleteAccountSelection(GlAccountSelectionDeleteInput input)
        {
            var result = await _deleteGlAccountSelectionRepository.Execute(input, "deleteGlAccountSelection");

            return new GlAccountSelectionOutput();
        }

        public async Task<GlAccountSelectionOutput> GlInsertAccountSelection(GlAccountSelectionInput input)
        {
            var result = await _insertGlAccountSelectionRepository.Execute(input, "InsertGlAccountSelection");

            return new GlAccountSelectionOutput();
        }

        public async Task<GlAccountSelectionOutput> PrepareRPT(PrepareRPTInput input)
        {
            var result = await _prepareRPTRepository.Execute(input, "PrepareRPT");

            return new GlAccountSelectionOutput();
        }

        public async Task<List<GlAccountsScreenDatarptOutput>> GetGlAccountsScreenDatarpt(GlAccountsScreenDatarptInput input)
        {
            input.TenantId = AbpSession.TenantId.Value;

            var result = await _glAccountsScreenDatarptRepository.Execute(input, "GetGlAccountsScreenDatarpt");

            return result.ToList();
        }
        public async Task<List<rptGlAccMappingHdOutput>> GetrptGlAccMappingHd(rptGlAccMappingHdInput input)
        {
            input.TenantId = AbpSession.TenantId.Value;

            var result = await _getRptGlAccMappingHdRepository.Execute(input, "rptGlAccMappingHd");

            return result.ToList();
        }

        public async Task<List<GetArSecurityDepositInterfacerptOutput>> GetArSecurityDepositInterfacerpt(GetArSecurityDepositInterfacerptInput Input)
        {
            Input.TenantId = AbpSession.TenantId.Value;

            var result = await _getArSecurityDepositInterfacerptRepository.Execute(Input, "GetArSecurityDepositInterfacerpt");

            return result.ToList();
        }




        public async Task<IReadOnlyList<GetTaxReportDataOutput>> GetTaxReportData(GetTaxReportDataInputHelper input)
        {
            var mapped = ObjectMapper.Map<GetTaxReportDataInput>(input);
            mapped.TenantId = AbpSession.TenantId.Value;

            var AsyncResult = await _executeSpRepositoryRepository.ExecuteAsync<GetTaxReportDataOutput, GetTaxReportDataInput>(mapped, "GetTaxrpt");

            return AsyncResult.ToList();
        }

        public async Task<IReadOnlyList<GetTaxReportData2Output>> GetTaxReportData2(GetTaxReportData2InputHelper input)
        {
            var mapped = ObjectMapper.Map<GetTaxReportData2Input>(input);
            mapped.TenantId = AbpSession.TenantId.Value;
            var result1 = await _executeSpRepositoryRepository.ExecuteAsync<GetTaxReportData2Output, GetTaxReportData2Input>(mapped, "GetTaxrpt2");
            return result1.ToList();
        }


        //public async Task<IReadOnlyList<GetCustomersBalanceOutput>> GetCustomersBalanceReportData(GetCustomersBalanceInput input)
        //{
        //    input.TenantId = AbpSession.TenantId.Value;

        //    var model = new GetCustomersBalanceInput { CustomerID = input.CustomerID, Lang = input.Lang, TenantId = AbpSession.TenantId.Value };


        //    var result1 = executeSpRepository.Execute1<GetCustomersBalanceOutput, GetCustomersBalanceInput>(input, "GetCustomersBalancerpt");
        //    var result = await _getCustomersBalancerptRepository.Execute(model, "GetCustomersBalancerpt");
        //    return result1.ToList();
        //}







    }
}

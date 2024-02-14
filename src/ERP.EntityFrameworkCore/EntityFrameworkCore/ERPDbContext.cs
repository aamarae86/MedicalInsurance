#region Usings
using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ERP.Authorization.Roles;
using ERP.Authorization.Users;
using ERP.MultiTenancy;
using ERP._System._FndLookupValues;
using ERP._System._GlAccHeaders;
using ERP.Currencies;
using ERP._System._GlJeHeaders;
using ERP._System._GlPeriods;
using ERP._System._GlAccDetails;
using ERP._System._GlAccounts;
using ERP._System._GlCodeComDetails;
using ERP._System._GlJeLines;
using ERP._System._ArCustomers;
using ERP._System._Counters;
using ERP._System._CountersDetails;
using ERP._System._ApVendors;
using ERP._System._ApBanks;
using ERP._System._ApBankAccounts;
using ERP._System._ApUserBankAccess;
using ERP._System._GlMainAccounts;
using ERP._System._ApPdcInterface;
using ERP._System._ArPdcInterface;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._ArMiscReceiptLines;
using ERP._System._ArMiscReceiptDetails;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ApMiscPaymentLines;
using ERP._System._ApMiscPaymentDetails;
using ERP._System._FndCollectors;
using ERP._System.__AidModule._ScFndAidRequestType;
using ERP._System.__AidModule._ScFndPortalIntervalSetting;
using ERP._System.__AidModule._ScFndProtalAttachmentSetting;
using ERP._System._ScComityMembers;
using ERP._System.__AidModule._FndSpell;
using ERP._System._Portal;
using ERP._System._ScCampainsAid;
using ERP._System.__AidModule._ScCampains;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System.__AidModule._ScPortalRequest;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__AidModule._ScPortalRequestStudyAttachment;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__AidModule._ScPortalRequestVisited;
using ERP._System.__AidModule._ScCommitteesCheckDetails;
using ERP._System.__AidModule._ScCommitteesCheck;
using ERP._System._ArDrCrTr;
using ERP._System._ArDrCrHd;
using ERP._System.__PmPropertiesModule._PmOwners;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP._System.__PmPropertiesModule._PmPropertiesAttachments;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System.__PmPropertiesModule._PmPropertiesRevenueAccounts;
using ERP._System.__PmPropertiesModule._PmOtherPaymentTypes;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__PmPropertiesModule._ArInvoiceTr;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmContractAttachments;
using ERP._System.__PmPropertiesModule._PmContractPayments;
using ERP._System.__PmPropertiesModule._PmContractUnitDetails;
using ERP._System.__PmPropertiesModule._PmOtherContractPayments;
using ERP._System.__PmPropertiesModule._PmTenants;
using ERP._System.__PmPropertiesModule._PmTenantsAttachments;
using ERP._System.__PmPropertiesModule._PmCancellationContracts;
using ERP._System.__PmPropertiesModule._PmTerminateContracts;
using ERP._System._ArSecurityDepositInterface;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System.__AidModule._Portal._PortalUserDuties;
using ERP._System.__AidModule._Portal._PortalUserIncomes;
using ERP._System.__AccountModule._TmCharityBoxesType;
using ERP._System.__CharityBoxes._TmRegions;
using ERP._System.__AccountModule._GL_TRIAL_BALANCES;
using ERP._System.__AccountModule._GL_ACCOUNT_SELECTION;
using ERP._System.__CharityBoxes._TmLocations;
using ERP._System.__CharityBoxes._TmSupervisors;
using ERP._System.__AidModule._Portal._PortalUserAttachments;
using ERP._System.__CharityBoxes._TmCharityBoxReceive;
using ERP._System.__CharityBoxes._TmCharityBoxes;
using ERP._System.__CharityBoxes._TmCharityBoxActions;
using ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails;
using ERP._System.__CharityBoxes._TmCharityBoxCollectMembers;
using ERP._System.__CharityBoxes._TmCharityBoxCollect;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectDetails;
using ERP._System.__CharityBoxes._TmCharityBoxCollect._TmCharityBoxCollectMembersDetail;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs._TmDamagedCharityBoxDetails;
using ERP._System.__SpGuarantees._SpCasesAttachments;
using ERP._System.__SpGuarantees._SpCases;
using ERP._System.__SpGuarantees._SpFamilies;
using ERP._System.__SpGuarantees._SpFamilyDuties;
using ERP._System.__SpGuarantees._SpFamilyIncomes;
using ERP._System.__SpGuarantees._SpContracts._SpContractAttachments;
using ERP._System.__SpGuarantees._SpContracts._SpContractDetails;
using ERP._System.__SpGuarantees._SpContracts;
using ERP._System.__SpGuarantees._SpBeneficent;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations;
using ERP._System.__AccountModule._ApInvoiceHd;
using ERP._System.__AccountModule._ApInvoiceHd._ApInvoiceTr;
using ERP._System.__AccountModuleExtend._ApPrepaid;
using ERP._System.__AccountModuleExtend._ApPaymentsTransactions;
using ERP._System.__SpGuarantees._SpCaseEditData;
using ERP._System.__Warehouses;
using ERP._System.__Warehouses._IvUnits;
using ERP._System.__Warehouses._IvUserWarehousesPrivileges;
using ERP._System.__Warehouses._IvItemsTypesConfigure;
using ERP._System.__Warehouses._PoPurchaseOrder;
using ERP._System.__Warehouses._IvItems;
using ERP._System.__SpGuarantees._SpCaseHistory;
using ERP._System.__Warehouses._IvAdjustmentHd._IvAdjustmentTr;
using ERP._System.__Warehouses._IvAdjustmentHd;
using ERP._System.__Warehouses._IvWarehouseItems;
using ERP._System.__Warehouses._IvStoreIssue;
using ERP._System.__Warehouses._IvReceiveHd._IvReceiveTr;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System.__HR._HrOrganizations;
using ERP._System.__HR._PyPayrollTypes;
using ERP._System.__HR._HrAbsencesTypes;
using ERP._System.__HR._HrPersons;
using ERP._System.__HR._HrPersons._HrPersonVisaDetails;
using ERP._System.__HR._HrPersons._HrPersonPassportDetails;
using ERP._System.__HR._HrPersons._HrPersonIdentityCard;
using ERP._System.__Warehouses._PyElements;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._HrPersons._HrPersonSalaryElements;
using ERP._System.__HR._HrPersonVacations;
using ERP._System.__HR._HrPersonsAdditionHd;
using ERP._System.__HR._HrPersonsAdditionHd._HrPersonsAdditionTr;
using ERP._System.__HR._PyPayrollOperations;
using ERP._System._modules;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTrDtl;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTr;
using ERP._System.__AccountModule._GlAccMappingHd;
using ERP._System.__AccountModule._FaAssetCategory;
using ERP._System.__AccountModuleExtend._FaAssets;
using ERP._System.__AccountModule._FaAssetDeprn;
using ERP._System.__AidModule._ScDeliveryOtherAids;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders;
using ERP._System.__AidModule._PortalUserData;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System.__AidModule._ScMaintenanceTechnicalReport;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using ERP._System.__AidModule._ScMaintenanceContract;
using ERP._System.__AidModule._ScMaintenancePayments;
using ERP._System.__SpGuarantees._SpPayments;
using ERP._System.__SpGuarantees._SpPaymentSetting;
using ERP._System.Home;
using ERP._System.__PmPropertiesModule._FmEngineers;
using ERP._System.__PmPropertiesModule._FmContracts;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsHdr;
using ERP._System.__PmPropertiesModule._FmMaintRequisitionsExe;
using ERP._System._AffliateAccount;
using ERP._System.__CRM.Leads;
using ERP._System.__CRM.Deals;
using ERP._System.__CRM._ActivityCall;
using ERP._System.__CRM._ActivityTasks;
using ERP._System.__CRM._ActivityMeeting;
using ERP._System._Projects;
using ERP._System.__CRM._Projects;
using ERP._System.__CRM.Services;
using ERP._System.__CRM.AboutUs;
using ERP._System.__CRM._CrmContactUs;
using ERP._System._TenantFreeModules;
using ERP._System.Calender;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__SalesModule._FndSalesMen;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentHd;
using ERP._System.__AccountModule._ArJobCardPayment._ArJobCardPaymentTr;
using ERP._System.__AccountModule._ApDrCrHd;
using ERP._System.__AccountModule._ApDrCrTr;
using ERP._System.__Warehouses._IvPriceListHd;
using ERP._System.__Warehouses._IvInventorySetting;
using ERP._System.__SalesModule._IvSaleHd;
using ERP._System.__SalesModule._IvReturnSaleHd;
using ERP._System.__Warehouses._IvReturnReceiveHd;
using ERP._System._FndTaxType;
using ERP._System.__HR._HrPersonPermission;
using ERP._System.__HR._HrPersonRequestDocument;
using ERP._System.__HR._HrPersonTimeSheet;
using ERP._System.__HR._HRPaperRequest;
using ERP._System.__AccountModule._ArJobSurveyPartsList;
using ERP._System.__AccountModule._ArJobSurveyHd;
using ERP._System.__AccountModule._ArJobSurveyTr;



#endregion

namespace ERP.EntityFrameworkCore
{
    public class ERPDbContext : AbpZeroDbContext<Tenant, Role, User, ERPDbContext>
    {
        #region DbSets
        
        public virtual DbSet<HrPaperRequestAttachment> HrPaperRequestAttachment { get; set; }
        public virtual DbSet<PaperReqType> PaperReqType { get; set; }
        public virtual DbSet<HrPaperRequest> HrPaperRequest { get; set; }
        public virtual DbSet<TimeSheetType> TimeSheetType { get; set; }
        public virtual DbSet<HrPersonTimeSheet> HrPersonTimeSheet { get; set; }
        public virtual DbSet<HrPersonRequestDocument> HrPersonRequestDocument { get; set; }
        public virtual DbSet<DocumentRequestType> DocumentRequestType { get; set; }
        public virtual DbSet<HrPersonPermission> HrPersonPermission { get; set; }
        public virtual DbSet<HrPermissionType> HrPermissionType { get; set; }
        public virtual DbSet<FndTaxType> FndTaxType { get; set; }
        public virtual DbSet<IvReturnReceiveHd> IvReturnReceiveHd { get; set; }
        public virtual DbSet<IvReturnReceiveTr> IvReturnReceiveTr { get; set; }
        public virtual DbSet<IvReturnSaleHd> IvReturnSaleHd { get; set; }
        public virtual DbSet<IvReturnSaleTr> IvReturnSaleTr { get; set; }
        public virtual DbSet<IvSaleHd> IvSaleHd { get; set; }
        public virtual DbSet<IvSaleTr> IvSaleTr { get; set; }
        public virtual DbSet<IvInventorySetting> IvInventorySetting { get; set; }
        public virtual DbSet<IvInventorySettingPriceList> IvInventorySettingPriceList { get; set; }
        public virtual DbSet<IvPriceListHd> IvPriceListHd { get; set; }
        public virtual DbSet<IvPriceListTr> IvPriceListTr { get; set; }
        public virtual DbSet<ApDrCrHd> ApDrCrHd { get; set; }
        public virtual DbSet<ApDrCrTr> ApDrCrTr { get; set; }
        public virtual DbSet<AbpKpiRole> AbpKpiRole { get; set; }
        public virtual DbSet<ArInvoiceSettlementHd> ArInvoiceSettlementHd { get; set; }
        public virtual DbSet<ArInvoiceSettlementCr> ArInvoiceSettlementCr { get; set; }
        public virtual DbSet<ArInvoiceSettlementDr> ArInvoiceSettlementDr { get; set; }
        public virtual DbSet<ArJobCardHd> ArJobCardHd { get; set; }
        public virtual DbSet<ArJobSurveyPartsList> ArJobSurveyPartsList { get; set; }
        public virtual DbSet<ArJobSurveyHd> ArJobSurveyHd { get; set; }
        public virtual DbSet<ArJobSurveyTr> ArJobSurveyTr { get; set; }
        public virtual DbSet<ArJobCardPaymentHd> ArJobCardPaymentHd { get; set; }
        public virtual DbSet<ArJobCardPaymentTr> ArJobCardPaymentTr { get; set; }
        public virtual DbSet<ArJobCardAttachments> ArJobCardAttachments { get; set; }
        public virtual DbSet<FndCalendarMemo> FndCalendarMemo { get; set; }
        public virtual DbSet<TenantRenewalHistory> TenantRenewalHistories { get; set; }
        public virtual DbSet<TenantFreeModules> TenantFreeModules { get; set; }
        public virtual DbSet<CrmContactUs> CrmContactUs { get; set; }
        public virtual DbSet<AboutUSSlider> AboutUSSlider { get; set; }
        public virtual DbSet<CrmAboutUs> CrmAboutUs { get; set; }
        public virtual DbSet<CrmServices> CrmServices { get; set; }
        public virtual DbSet<CrmProducts> CrmProducts { get; set; }
        public virtual DbSet<CrmProjects> CrmProjects { get; set; }

        public virtual DbSet<ActivityMeetingParticipant> ActivityMeetingParticipant { get; set; }
        public virtual DbSet<ActivityMeeting> ActivityMeeting { get; set; }

        public virtual DbSet<ActivityTasks> ActivityTasks { get; set; }
        public virtual DbSet<ActivityCall> ActivityCall { get; set; }
        public virtual DbSet<CrmDeals> CrmDeals { get; set; }
        public virtual DbSet<CrmDealsAttachments> CrmDealsAttachments { get; set; }
        public virtual DbSet<CrmLeadsPersons> CrmLeadsPersons { get; set; }
        public virtual DbSet<AffliateAccount> AffliateAccount { get; set; }
        public virtual DbSet<FmMaintRequisitionsExe> FmMaintRequisitionsExe { get; set; }
        public virtual DbSet<FmContracts> FmContracts { get; set; }
        public virtual DbSet<FmBuildingsContracts> FmBuildingsContracts { get; set; }
        public virtual DbSet<FmContractVisits> FmContractVisits { get; set; }
        public virtual DbSet<FmMaintRequisitionsHdr> FmMaintRequisitionsHdr { get; set; }
        public virtual DbSet<FmEngineers> FmEngineers { get; set; }
        public virtual DbSet<SpPaymentSetting> SpPaymentSetting { get; set; }
        public virtual DbSet<SpCasesPaymentDeserving> SpCasesPaymentDeserving { get; set; }
        public virtual DbSet<SpPaymentPersonDetails> SpPaymentPersonDetails { get; set; }
        public virtual DbSet<SpPaymentPersons> SpPaymentPersons { get; set; }
        public virtual DbSet<SpPayments> SpPayments { get; set; }
        public virtual DbSet<HrPersonAttachments> HrPersonAttachments { get; set; }
        public virtual DbSet<ScMaintenancePayments> ScMaintenancePayments { get; set; }
        public virtual DbSet<ScMaintenanceContract> ScMaintenanceContract { get; set; }
        public virtual DbSet<ScMaintenanceContractPayments> ScMaintenanceContractPayments { get; set; }
        public virtual DbSet<ScMaintenanceQuotations> ScMaintenanceQuotations { get; set; }
        public virtual DbSet<ScMaintenanceQuotationDetails> ScMaintenanceQuotationDetails { get; set; }
        public virtual DbSet<ScMaintenanceQuotationAttachments> ScMaintenanceQuotationAttachments { get; set; }
        public virtual DbSet<ScCommitteeDetailsElectronicAid> ScCommitteeDetailsElectronicAid { get; set; }
        public virtual DbSet<ScPRMgrDecisionElectronicAid> ScPRMgrDecisionElectronicAid { get; set; }
        public virtual DbSet<PortalUserData> PortalUserData { get; set; }
        public virtual DbSet<GeneralUnPost> GeneralUnPost { get; set; }
        public virtual DbSet<GlJeIntegrationLines> GlJeIntegrationLines { get; set; }
        public virtual DbSet<GlJeIntegrationHeaders> GlJeIntegrationHeaders { get; set; }
        public virtual DbSet<PmPropertiesUnitsAttachments> PmPropertiesUnitsAttachments { get; set; }
        public virtual DbSet<ScDeliveryOtherAids> ScDeliveryOtherAids { get; set; }
        public virtual DbSet<ScDeliveryOtherAidDetails> ScDeliveryOtherAidDetails { get; set; }
        public virtual DbSet<FaAssetDeprnHd> FaAssetDeprnHd { get; set; }
        public virtual DbSet<FaAssetDeprnTr> FaAssetDeprnTr { get; set; }
        public virtual DbSet<FaAssetDeprnTrDtl> FaAssetDeprnTrDtl { get; set; }
        public virtual DbSet<FaAssets> FaAssets { get; set; }
        public virtual DbSet<FavoritePage> FavoritePages { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PyPayrollOperationPersonDetails> PyPayrollOperationPersonDetails { get; set; }
        public virtual DbSet<GlAccMappingHd> GlAccMappingHd { get; set; }
        public virtual DbSet<GlAccMappingTr> GlAccMappingTr { get; set; }
        public virtual DbSet<GlAccMappingTrDtl> GlAccMappingTrDtl { get; set; }
        public virtual DbSet<PyPayrollOperationPersons> PyPayrollOperationPersons { get; set; }
        public virtual DbSet<PyPayrollOperations> PyPayrollOperations { get; set; }
        public virtual DbSet<HrPersonsAdditionHd> HrPersonsAdditionHd { get; set; }
        public virtual DbSet<HrPersonsAdditionTr> HrPersonsAdditionTr { get; set; }
        public virtual DbSet<HrPersonVacations> HrPersonVacations { get; set; }
        public virtual DbSet<HrPersonSalaryElements> HrPersonSalaryElements { get; set; }
        public virtual DbSet<HrPersonsDeductionHd> HrPersonsDeductionHd { get; set; }
        public virtual DbSet<HrPersonsDeductionTr> HrPersonsDeductionTr { get; set; }
        public virtual DbSet<HrPersons> HrPersons { get; set; }
        public virtual DbSet<PyElements> PyElements { get; set; }
        public virtual DbSet<HrPersonVisaDetails> HrPersonVisaDetails { get; set; }
        public virtual DbSet<HrPersonPassportDetails> HrPersonPassportDetails { get; set; }
        public virtual DbSet<HrPersonIdentityCard> HrPersonIdentityCard { get; set; }
        public virtual DbSet<PyPayrollTypes> PyPayrollTypes { get; set; }
        public virtual DbSet<HrOrganizations> HrOrganizations { get; set; }
        public virtual DbSet<IvReceiveHd> IvReceiveHd { get; set; }
        public virtual DbSet<IvReceiveTr> IvReceiveTr { get; set; }
        public virtual DbSet<HrVacationsTypes> HrVacationsTypes { get; set; }
        public virtual DbSet<SpCaseHistory> SpCaseHistory { get; set; }
        public virtual DbSet<IvWarehouseItems> IvWarehouseItems { get; set; }
        public virtual DbSet<IvAdjustmentHd> IvAdjustmentHd { get; set; }
        public virtual DbSet<IvAdjustmentTr> IvAdjustmentTr { get; set; }
        public virtual DbSet<IvItemsTypesConfigure> IvItemsTypesConfigure { get; set; }
        public virtual DbSet<IvItems> IvItems { get; set; }
        public virtual DbSet<IvStoreIssueHd> IvStoreIssueHd { get; set; }
        public virtual DbSet<IvStoreIssueTr> IvStoreIssueTr { get; set; }
        public virtual DbSet<IvWarehouses> IvWarehouses { get; set; }
        public virtual DbSet<IvUnits> IvUnits { get; set; }
        public virtual DbSet<ApPaymentsTransactions> ApPaymentsTransactions { get; set; }
        public virtual DbSet<ApPrepaid> ApPrepaid { get; set; }
        public virtual DbSet<IvUserWarehousesPrivileges> IvUserWarehousesPrivileges { get; set; }
        public virtual DbSet<ApInvoiceTr> ApInvoiceTr { get; set; }
        public virtual DbSet<ApInvoiceHd> ApInvoiceHd { get; set; }
        public virtual DbSet<SpCaseOperations> SpCaseOperations { get; set; }
        public virtual DbSet<SpCaseEditData> SpCaseEditData { get; set; }
        public virtual DbSet<SpBeneficentAttachments> SpBeneficentAttachments { get; set; }
        public virtual DbSet<SpBeneficentBanks> SpBeneficentBanks { get; set; }
        public virtual DbSet<SpContractAttachments> SpContractAttachments { get; set; }
        public virtual DbSet<SpContractDetails> SpContractDetails { get; set; }
        public virtual DbSet<SpContracts> SpContracts { get; set; }
        public virtual DbSet<SpFamilies> SpFamilies { get; set; }
        public virtual DbSet<SpFamilyDuties> SpFamilyDuties { get; set; }
        public virtual DbSet<SpFamilyIncomes> SpFamilyIncomes { get; set; }
        public virtual DbSet<TmDamagedCharityBoxDetails> TmDamagedCharityBoxDetails { get; set; }
        public virtual DbSet<SpCasesAttachments> SpCasesAttachments { get; set; }
        public virtual DbSet<SpCases> SpCases { get; set; }
        public virtual DbSet<TmDamagedCharityBoxs> TmDamagedCharityBoxs { get; set; }
        public virtual DbSet<TmCharityBoxCollectDetails> TmCharityBoxCollectDetails { get; set; }
        public virtual DbSet<TmCharityBoxCollectMembersDetail> TmCharityBoxCollectMembersDetail { get; set; }
        public virtual DbSet<TmCharityBoxCollect> TmCharityBoxCollect { get; set; }
        public virtual DbSet<TmCharityBoxCollectMembers> TmCharityBoxCollectMembers { get; set; }
        public virtual DbSet<PortalUserAttachments> PortalUserAttachments { get; set; }
        public virtual DbSet<TmCharityBoxActionDetails> TmCharityBoxActionDetails { get; set; }
        public virtual DbSet<TmCharityBoxActions> TmCharityBoxActions { get; set; }
        public virtual DbSet<TmSupervisors> TmSupervisors { get; set; }
        public virtual DbSet<GlTrailBalances> GlTrailBalances { get; set; }
        public virtual DbSet<GlAccountSelection> GlAccountSelection { get; set; }
        public virtual DbSet<PortalUserDuties> PortalUserDuties { get; set; }
        public virtual DbSet<TmRegions> TmRegions { get; set; }
        public virtual DbSet<TmCharityBoxesType> TmCharityBoxesType { get; set; }
        public virtual DbSet<PortalUserIncomes> PortalUserIncomes { get; set; }
        public virtual DbSet<ScPortalRequestIncome> ScPortalRequestIncome { get; set; }
        public virtual DbSet<ScPortalRequestDuties> ScPortalRequestDuties { get; set; }
        public virtual DbSet<FndLookupValues> FndLookupValues { get; set; }
        public virtual DbSet<PmCancellationContracts> PmCancellationContracts { get; set; }
        public virtual DbSet<PmTerminateContracts> PmTerminateContracts { get; set; }
        public virtual DbSet<ArSecurityDepositInterface> ArSecurityDepositInterface { get; set; }
        public virtual DbSet<ArReceipts> ArReceipts { get; set; }
        public virtual DbSet<ArReceiptDetails> ArReceiptDetails { get; set; }
        public virtual DbSet<ArReceiptsOnAccount> ArReceiptsOnAccount { get; set; }
        public virtual DbSet<PmTenants> PmTenants { get; set; }
        public virtual DbSet<PmTenantsAttachments> PmTenantsAttachments { get; set; }
        public virtual DbSet<PmContract> PmContract { get; set; }
        public virtual DbSet<PmContractAttachments> PmContractAttachments { get; set; }
        public virtual DbSet<PmContractPayments> PmContractPayments { get; set; }
        public virtual DbSet<PmContractUnitDetails> PmContractUnitDetails { get; set; }
        public virtual DbSet<PmOtherContractPayments> PmOtherContractPayments { get; set; }
        public virtual DbSet<ArInvoiceHd> ArInvoiceHd { get; set; }
        public virtual DbSet<ArInvoiceTr> ArInvoiceTr { get; set; }
        public virtual DbSet<PmOtherPaymentTypes> PmOtherPaymentTypes { get; set; }
        public virtual DbSet<ArDrCrTr> ArDrCrTr { get; set; }
        public virtual DbSet<ArDrCrHd> ArDrCrHd { get; set; }
        public virtual DbSet<ScCampainsAid> ScCampainsAid { get; set; }
        public virtual DbSet<ScComityMembers> ScComityMembers { get; set; }
        public virtual DbSet<GlAccHeaders> GlAccHeaders { get; set; }
        public virtual DbSet<GlJeHeaders> GlJeHeaders { get; set; }
        public virtual DbSet<Counters> Counters { get; set; }
        public virtual DbSet<CountersDetails> CountersDetails { get; set; }
        public virtual DbSet<GlPeriodsYears> GlPeriodsYears { get; set; }
        public virtual DbSet<GlPeriodsDetails> GlPeriodsDetails { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<GlAccDetails> GlAccDetails { get; set; }
        public virtual DbSet<GlAccounts> GlAccounts { get; set; }
        public virtual DbSet<GlCodeComDetails> GlCodeComDetails { get; set; }
        public virtual DbSet<FaAssetCategory> FaAssetCategory { get; set; }
        public virtual DbSet<GlJeLines> GlJeLines { get; set; }
        public virtual DbSet<ArCustomers> ArCustomers { get; set; }
        public virtual DbSet<FndCollectors> FndCollectors { get; set; }
        public virtual DbSet<FndSalesMen> FndSalesMen { get; set; }
        public virtual DbSet<ApVendors> ApVendors { get; set; }
        public virtual DbSet<ApBanks> ApBanks { get; set; }
        public virtual DbSet<ApBankAccounts> ApBankAccounts { get; set; }
        public virtual DbSet<ApUserBankAccess> ApUserBankAccess { get; set; }
        public virtual DbSet<GlMainAccounts> GlMainAccounts { get; set; }
        public virtual DbSet<ApPdcInterface> ApPdcInterface { get; set; }
        public virtual DbSet<ArPdcInterface> ArPdcInterface { get; set; }
        public virtual DbSet<ArMiscReceiptHeaders> ArMiscReceiptHeaders { get; set; }
        public virtual DbSet<ArMiscReceiptLines> ArMiscReceiptLines { get; set; }
        public virtual DbSet<ArMiscReceiptDetails> ArMiscReceiptDetails { get; set; }
        public virtual DbSet<ApMiscPaymentHeaders> ApMiscPaymentHeaders { get; set; }
        public virtual DbSet<ApMiscPaymentLines> ApMiscPaymentLines { get; set; }
        public virtual DbSet<ApMiscPaymentDetails> ApMiscPaymentDetails { get; set; }
        public virtual DbSet<SpBeneficent> SpBeneficent { get; set; }
        public virtual DbSet<ScFndAidRequestType> ScFndAidRequestType { get; set; }
        public virtual DbSet<ScFndPortalIntervalSetting> ScFndPortalIntervalSetting { get; set; }
        public virtual DbSet<ScFndProtalAttachmentSetting> ScFndProtalAttachmentSetting { get; set; }
        public virtual DbSet<FndSpell> FndSpell { get; set; }
        public virtual DbSet<PortalUserRelatives> PortalUserRelatives { get; set; }
        public virtual DbSet<PortalUser> PortalUsers { get; set; }
        public virtual DbSet<ScCampains> ScCampains { get; set; }
        public virtual DbSet<ScCampainsDetail> ScCampainsDetail { get; set; }
        public virtual DbSet<ScPortalRequest> ScPortalRequests { get; set; }
        public virtual DbSet<ScPortalRequestAttachment> ScPortalRequestAttachments { get; set; }
        public virtual DbSet<ScPortalRequestStudy> ScPortalRequestStudy { get; set; }
        public virtual DbSet<ScPortalRequestStudyAttachment> ScPortalRequestStudyAttachment { get; set; }
        public virtual DbSet<ScPortalRequestMgrDecision> ScPortalRequestMgrDecision { get; set; }

        public virtual DbSet<TenantDetail> TenantDetails { get; set; }
        public virtual DbSet<ScPortalRequestVisited> ScPortalRequestVisited { get; set; }

        public virtual DbSet<ScCommittee> ScCommittees { get; set; }
        public virtual DbSet<ScCommitteeDetail> ScCommitteeDetails { get; set; }
        public virtual DbSet<ScCommitteeMemberDetail> ScCommitteeMemberDetail { get; set; }
        public virtual DbSet<ScCommitteesCheck> ScCommitteesCheck { get; set; }
        public virtual DbSet<ScCommitteesCheckDetails> ScCommitteesCheckDetails { get; set; }
        public virtual DbSet<PmOwners> PmOwners { get; set; }
        public virtual DbSet<PmOwnersTaxDetails> PmOwnersTaxDetails { get; set; }
        public virtual DbSet<PmProperties> PmProperties { get; set; }
        public virtual DbSet<PmPropertiesAttachments> PmPropertiesAttachments { get; set; }
        public virtual DbSet<PmPropertiesUnits> PmPropertiesUnits { get; set; }
        public virtual DbSet<PmPropertiesRevenueAccounts> PmPropertiesRevenueAccounts { get; set; }
        public virtual DbSet<TmCharityBoxReceive> TmCharityBoxReceive { get; set; }
        public virtual DbSet<TmCharityBoxes> TmCharityBoxes { get; set; }
        public virtual DbSet<TmLocations> TmLocations { get; set; }
        public virtual DbSet<TmLocationSub> TmLocationSub { get; set; }
        public virtual DbSet<PoPurchaseOrderHd> PoPurchaseOrderHd { get; set; }
        public virtual DbSet<PoPurchaseOrderTr> PoPurchaseOrderTr { get; set; }

        public virtual DbSet<ScMaintenanceTechnicalReport> ScMaintenanceTechnicalReport { get; set; }
        public virtual DbSet<ScMaintenanceTechnicalReportDetail> ScMaintenanceTechnicalReportDetail { get; set; }
        public virtual DbSet<ScMaintenanceTechnicalReportAttachments> ScMaintenanceTechnicalReportAttachments { get; set; }

        #endregion

        public ERPDbContext(DbContextOptions<ERPDbContext> options) : base(options) { }
    }
}

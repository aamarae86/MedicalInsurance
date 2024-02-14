#region usings
using Abp.Domain.Entities.Auditing;
using ERP._System.__AccountModule._ApInvoiceHd;
using ERP._System.__AccountModule._ArJobCardHd;
using ERP._System.__AccountModule._ArReceipts;
using ERP._System.__AccountModule._GeneralUnPost;
using ERP._System.__AccountModule._GlAccMappingHd._GlAccMappingTrDtl;
using ERP._System.__AccountModuleExtend._ApPaymentsTransactions;
using ERP._System.__AccountModuleExtend._ApPrepaid;
using ERP._System.__AccountModuleExtend._GlJeIntegrationHeaders;
using ERP._System.__AidModule._ScCampains;
using ERP._System.__AidModule._ScCampainsDetail;
using ERP._System.__AidModule._ScCommittee;
using ERP._System.__AidModule._ScCommitteesCheck;
using ERP._System.__AidModule._ScFndAidRequestType;
using ERP._System.__AidModule._ScMaintenanceContract;
using ERP._System.__AidModule._ScMaintenancePayments;
using ERP._System.__AidModule._ScMaintenanceQuotations;
using ERP._System.__AidModule._ScPortalRequestMgrDecision;
using ERP._System.__AidModule._ScPortalRequestStudy;
using ERP._System.__AidModule._ScPortalRequestVisited;
using ERP._System.__CharityBoxes._TmCharityBoxActions._TmCharityBoxActionDetails;
using ERP._System.__CharityBoxes._TmCharityBoxCollect;
using ERP._System.__CharityBoxes._TmCharityBoxCollectMembers;
using ERP._System.__CharityBoxes._TmDamagedCharityBoxs;
using ERP._System.__CharityBoxes._TmRegions;
using ERP._System.__CharityBoxes._TmSupervisors;
using ERP._System.__HR._HrOrganizations;
using ERP._System.__HR._HrPersons;
using ERP._System.__HR._HrPersons._HrPersonPassportDetails;
using ERP._System.__HR._HrPersons._HrPersonVisaDetails;
using ERP._System.__HR._HrPersonsAdditionHd;
using ERP._System.__HR._HrPersonsAdditionHd._HrPersonsAdditionTr;
using ERP._System.__HR._HrPersonsDeduction;
using ERP._System.__HR._HrPersonVacations;
using ERP._System.__HR._PyPayrollOperations;
using ERP._System.__PmPropertiesModule._ArInvoiceHd;
using ERP._System.__PmPropertiesModule._FmEngineers;
using ERP._System.__PmPropertiesModule._PmCancellationContracts;
using ERP._System.__PmPropertiesModule._PmContract;
using ERP._System.__PmPropertiesModule._PmContractPayments;
using ERP._System.__PmPropertiesModule._PmOwners;
using ERP._System.__PmPropertiesModule._PmProperties;
using ERP._System.__PmPropertiesModule._PmPropertiesUnits;
using ERP._System.__PmPropertiesModule._PmTenants;
using ERP._System.__PmPropertiesModule._PmTerminateContracts;
using ERP._System.__SalesModule.ArInvoiceSettlement;
using ERP._System.__SpGuarantees._SpBeneficent;
using ERP._System.__SpGuarantees._SpCaseHistory;
using ERP._System.__SpGuarantees._SpCases;
using ERP._System.__SpGuarantees._SpCases._SpCaseOperations;
using ERP._System.__SpGuarantees._SpContracts;
using ERP._System.__SpGuarantees._SpFamilies;
using ERP._System.__SpGuarantees._SpPayments;
using ERP._System.__SpGuarantees._SpPaymentSetting;
using ERP._System.__Warehouses;
using ERP._System.__Warehouses._IvAdjustmentHd;
using ERP._System.__Warehouses._IvReceiveHd;
using ERP._System.__Warehouses._PyElements;
using ERP._System._ApBanks;
using ERP._System._ApMiscPaymentHeaders;
using ERP._System._ApPdcInterface;
using ERP._System._ApVendors;
using ERP._System._ArCustomers;
using ERP._System._ArDrCrHd;
using ERP._System._ArMiscReceiptDetails;
using ERP._System._ArMiscReceiptHeaders;
using ERP._System._ArMiscReceiptLines;
using ERP._System._ArPdcInterface;
using ERP._System._ArSecurityDepositInterface;
using ERP._System._GlAccHeaders;
using ERP._System._GlAccounts;
using ERP._System._GlJeHeaders;
using ERP._System._GlJeLines;
using ERP._System._GlPeriods;
using ERP._System._ScCampainsAid;
using ERP._System._ScComityMembers;
using ERP.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace ERP._System._FndLookupValues
{
    public class FndLookupValues : AuditedEntity<long>
    {
        #region Props

        [MaxLength(200)]
        public string NameEn { get; protected set; }

        [MaxLength(200)]
        public string NameAr { get; protected set; }

        [Required]
        [MaxLength(100)]
        public string LookupCode { get; protected set; }

        [Required]
        [MaxLength(100)]
        public string LookupType { get; protected set; }

        [Required]
        public bool YesNo { get; protected set; }

        public string AddedValues { get; protected set; }

        public long? ParentId { get; protected set; }

        [ForeignKey(nameof(ParentId))]
        public FndLookupValues Parent { get; protected set; }

        #endregion

        #region Collections  props
        
        public virtual ICollection<FmEngineers> FmEngineers { get; protected set; }

        public virtual ICollection<SpPaymentSetting> SpPaymentSetting { get; protected set; }

        public virtual ICollection<ScMaintenancePayments> ScMaintenancePayments { get; protected set; }

        public virtual ICollection<ScMaintenanceContract> ScMaintenanceContract { get; protected set; }

        public virtual ICollection<ScMaintenanceQuotations> ScMaintenanceQuotations { get; protected set; }

        public virtual ICollection<ScCommitteeDetailsElectronicAid> ScCommitteeDetailsElectronicAid { get; protected set; }

        public virtual ICollection<ScPRMgrDecisionElectronicAid> ScPRMgrDecisionElectronicAid { get; protected set; }

        public virtual ICollection<GlJeIntegrationLines> GlJeIntegrationLines { get; protected set; }

        public virtual ICollection<GeneralUnPost> GeneralUnPost { get; protected set; }

        public virtual ICollection<PyPayrollOperationPersonDetails> PyPayrollOperationPersonDetails { get; protected set; }

        public virtual ICollection<GlAccMappingTrDtl> GlAccMappingTrDtl { get; protected set; }

        public virtual ICollection<PyPayrollOperationPersons> PyPayrollOperationPersons { get; protected set; }

        public virtual ICollection<HrPersonsAdditionHd> HrPersonsAdditionHd { get; protected set; }

        public virtual ICollection<HrPersonsAdditionTr> HrPersonsAdditionTr { get; protected set; }

        public virtual ICollection<HrPersonVacations> HrPersonVacations { get; protected set; }

        public object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public virtual ICollection<HrOrganizations> HrOrganizations { get; protected set; }
        public virtual ICollection<PyElements> PyElements { get; protected set; }
        public virtual ICollection<TmDamagedCharityBoxs> TmDamagedCharityBoxs { get; protected set; }
        public virtual ICollection<ScFndAidRequestType> ScFndAidRequestType { get; protected set; }
        public virtual ICollection<TmSupervisors> TmSupervisors { get; protected set; }
        public virtual ICollection<TmRegions> TmRegions { get; protected set; }
        public virtual ICollection<PmCancellationContracts> PmCancellationContracts { get; protected set; }
        public virtual ICollection<PmTerminateContracts> PmTerminateContracts { get; protected set; }
        public virtual ICollection<ScCampainsAid> ScCampainsAid { get; protected set; }
        public virtual ICollection<GlAccHeaders> GlAccHeaders { get; protected set; }
        public virtual ICollection<GlPeriodsDetails> GlPeriodsDetails { get; protected set; }
        public virtual ICollection<GlAccounts> GlAccounts { get; protected set; }

        [InverseProperty(nameof(SpPayments.FndStatusLkp))]
        public virtual ICollection<SpPayments> SpPaymentsFndStatusLkp { get; protected set; }

        [InverseProperty(nameof(SpCasesPaymentDeserving.FndStatusLkp))]
        public virtual ICollection<SpCasesPaymentDeserving> SpCasesPaymentDeservingFndStatusLkp { get; protected set; }

        [InverseProperty(nameof(SpCasesPaymentDeserving.FndCaseStatusLkp))]
        public virtual ICollection<SpCasesPaymentDeserving> SpCasesPaymentDeservingFndCaseStatusLkp { get; protected set; }

        [InverseProperty(nameof(SpPayments.FndSponsorCategoryLkp))]
        public virtual ICollection<SpPayments> SpPaymentsFndSponsorCategoryLkp { get; protected set; }

        [InverseProperty(nameof(GlJeHeaders.StatusFndLookupValues))]
        public virtual ICollection<GlJeHeaders> StatusGlJeHeaders { get; protected set; }

        [InverseProperty(nameof(GlJeHeaders.JeSourceFndLookupValues))]
        public virtual ICollection<GlJeHeaders> JeSourceGlJeHeaders { get; protected set; }

        [InverseProperty(nameof(ArCustomers.FndLookupValues))]
        public virtual ICollection<ArCustomers> ArCustomersLkp { get; protected set; }

        [InverseProperty(nameof(IvAdjustmentHd.FndLookupValuesAdjustmentTypeLkp))]
        public virtual ICollection<IvAdjustmentHd> FndLookupValuesAdjustmentTypeLkp { get; protected set; }

        [InverseProperty(nameof(IvAdjustmentHd.FndLookupValuesStatusLkpIvAdjustmentHd))]
        public virtual ICollection<IvAdjustmentHd> FndLookupValuesStatusLkpIvAdjustmentHd { get; protected set; }

        [InverseProperty(nameof(ArCustomers.FndLookupValuesSource))]
        public virtual ICollection<ArCustomers> FndLookupValuesSourceCollection { get; protected set; }

        [InverseProperty(nameof(ArCustomers.FndLookupValuesCustType))]
        public virtual ICollection<ArCustomers> ArCustomersCustType { get; protected set; }

        [InverseProperty(nameof(SpContracts.FndDeductedLkp))]
        public virtual ICollection<SpContracts> FndDeductedLkp { get; protected set; }

        [InverseProperty(nameof(SpContracts.FndPaymentTypeLkp))]
        public virtual ICollection<SpContracts> FndPaymentTypeLkp { get; protected set; }

        public virtual ICollection<GlJeLines> GlJeLines { get; protected set; }
        public virtual ICollection<ScComityMembers> GlCodeComDetails { get; protected set; }
        public virtual ICollection<ApBanks> ApBanks { get; protected set; }

        [InverseProperty(nameof(ApVendors.FndStatusLkp))]
        public virtual ICollection<ApVendors> ApVendorsStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(ApVendors.FndVendorCategoryLkp))]
        public virtual ICollection<ApVendors> ApVendorsVendorCategoryLkpCollcetion { get; protected set; }

        [InverseProperty(nameof(ApPdcInterface.FndLookupValuesSourceCodeLkp))]
        public virtual ICollection<ApPdcInterface> ApPdcInterfaceSourceCodeLkp { get; protected set; }
        [InverseProperty(nameof(ApPdcInterface.FndLookupValuesStatusLkp))]
        public virtual ICollection<ApPdcInterface> ApPdcInterfaceStatusLkp { get; protected set; }
        [InverseProperty(nameof(ApPdcInterface.FndLookupValuesChqReturnResonLKP))]
        public virtual ICollection<ApPdcInterface> ApPdcInterfaceChqReturnResonLKP { get; protected set; }
        [InverseProperty(nameof(ArPdcInterface.FndLookupValuesSourceCodeLkp))]
        public virtual ICollection<ArPdcInterface> ArPdcInterfaceSourceCodeLkp { get; protected set; }
        [InverseProperty(nameof(ArPdcInterface.FndLookupValuesStatusLkp))]
        public virtual ICollection<ArPdcInterface> ArPdcInterfaceStatusLkp { get; protected set; }
        [InverseProperty(nameof(ArPdcInterface.FndLookupValuesBankLkp))]
        public virtual ICollection<ArPdcInterface> ArPdcInterfaceBankLkp { get; protected set; }
        [InverseProperty(nameof(ArMiscReceiptHeaders.FndLookupValuesPostedLkp))]
        public virtual ICollection<ArMiscReceiptHeaders> ArMiscReceiptHeadersPostedLkp { get; protected set; }
        [InverseProperty(nameof(ArMiscReceiptHeaders.FndLookupValuesTransactionTypeLkp))]
        public virtual ICollection<ArMiscReceiptHeaders> ArMiscReceiptHeadersTransactionTypeLkp { get; protected set; }

        [InverseProperty(nameof(ArMiscReceiptHeaders.FndLookupValuesSourceCodeLkp))]
        public virtual ICollection<ArMiscReceiptHeaders> ArMiscReceiptHeadersSourceCodeLkp { get; protected set; }

        [InverseProperty(nameof(ArMiscReceiptHeaders.FndReceiptTypeLkp))]
        public virtual ICollection<ArMiscReceiptHeaders> ArMiscReceiptHeadersReceiptTypeLkp { get; protected set; }

        [InverseProperty(nameof(ArMiscReceiptLines.FndLookupValuesReceiptTypeLkp))]
        public virtual ICollection<ArMiscReceiptLines> ArMiscReceiptLinesReceiptTypeLkp { get; protected set; }
        [InverseProperty(nameof(ArMiscReceiptLines.FndLookupValuesSourceCodeLkp))]
        public virtual ICollection<ArMiscReceiptLines> ArMiscReceiptLinesSourceCodeLkp { get; protected set; }

        [InverseProperty(nameof(ApMiscPaymentHeaders.FndLookupValuesSourceCodePaymentLkp))]
        public virtual ICollection<ApMiscPaymentHeaders> ApMiscPaymentHeadersSourceCodeLkp { get; protected set; }

        [InverseProperty(nameof(ApMiscPaymentHeaders.FndLookupValuesPaymentTypeLkp))]
        public virtual ICollection<ApMiscPaymentHeaders> ApMiscPaymentHeadersTypeLkp { get; protected set; }

        [InverseProperty(nameof(ApMiscPaymentHeaders.FndLookupValuesPostedPaymentLkp))]
        public virtual ICollection<ApMiscPaymentHeaders> ApMiscPaymentHeadersPostedLkp { get; protected set; }

        public virtual ICollection<ArMiscReceiptDetails> ArMiscReceiptDetails { get; protected set; }

        [InverseProperty(nameof(ScPortalRequestStudy.FndLookupValuesStatusLkp))]
        public virtual ICollection<ScPortalRequestStudy> FndLookupValuesStatusLkp { get; protected set; }
        [InverseProperty(nameof(ScPortalRequestStudy.FndLookupValuesRefuseLkp))]
        public virtual ICollection<ScPortalRequestStudy> FndLookupValuesRefuseLkp { get; protected set; }
        [InverseProperty(nameof(ScPortalRequestStudy.FndLookupValuesStudyLkp))]
        public virtual ICollection<ScPortalRequestStudy> FndLookupValuesStudyLkp { get; protected set; }


        [InverseProperty(nameof(ScPortalRequestMgrDecision.FndLookupValuesStatusLkpId))]
        public virtual ICollection<ScPortalRequestMgrDecision> FndLookupValuesStatusLkpId { get; protected set; }
        [InverseProperty(nameof(ScPortalRequestMgrDecision.FndLookupValuesRefuseLkpId))]
        public virtual ICollection<ScPortalRequestMgrDecision> FndLookupValuesRefuseLkpId { get; protected set; }


        [InverseProperty(nameof(ArDrCrHd.FndLookupValuesSourceLkp))]
        public virtual ICollection<ArDrCrHd> FndLookupValuesSourceLkpArDrCrHd { get; protected set; }
        [InverseProperty(nameof(ArDrCrHd.FndLookupValuesStatusLkp))]
        public virtual ICollection<ArDrCrHd> FndLookupValuesStatusLkpArDrCrHd { get; protected set; }
        [InverseProperty(nameof(ArDrCrHd.FndLookupValuesHdTypeLkp))]
        public virtual ICollection<ArDrCrHd> FndLookupValuesHdTypeLkpArDrCrHd { get; protected set; }


        public virtual ICollection<ScCampains> ScCampains { get; protected set; }
        public virtual ICollection<ScCampainsDetail> ScCampainsDetail { get; protected set; }
        public virtual ICollection<ScPortalRequestVisited> ScPortalRequestVisited { get; protected set; }


        [InverseProperty(nameof(ScCommittee.FndLookupStatusValues))]
        public virtual ICollection<ScCommittee> ScCommitteeLookupValuesCollection { get; protected set; }
        [InverseProperty(nameof(ScCommitteeDetail.FndStatusLkp))]
        public virtual ICollection<ScCommitteeDetail> ScCommitteeDetailLookupValuesCollection { get; protected set; }
        [InverseProperty(nameof(ScCommitteesCheck.FndLookupValues))]
        public virtual ICollection<ScCommitteesCheck> ScCommitteesCheckLookupValuesCollection { get; protected set; }

        public virtual ICollection<ScCommitteesCheck> ScCommitteesCheckCollection { get; protected set; }

        [InverseProperty(nameof(PmPropertiesUnits.FndFinishesLkp))]
        public virtual ICollection<PmPropertiesUnits> FndFinishesLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmPropertiesUnits.FndStatusLkp))]
        public virtual ICollection<PmPropertiesUnits> FndPmPropertiesUnitsStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmPropertiesUnits.FndUnitTypeLkp))]
        public virtual ICollection<PmPropertiesUnits> FndUnitTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmPropertiesUnits.FndViewLkp))]
        public virtual ICollection<PmPropertiesUnits> FndViewLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmPropertiesUnits.FndPmUnitDescLkp))]
        public virtual ICollection<PmPropertiesUnits> FndPmUnitDescLkp { get; protected set; }

        [InverseProperty(nameof(PmProperties.FndCityLkp))]
        public virtual ICollection<PmProperties> FndCityLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmProperties.FndCommissionTypeLkp))]
        public virtual ICollection<PmProperties> FndCommissionTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmProperties.FndCountryLkp))]
        public virtual ICollection<PmProperties> FndCountryLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmProperties.FndPmPurposeLkp))]
        public virtual ICollection<PmProperties> FndPmPurposeLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmProperties.FndStatusLkp))]
        public virtual ICollection<PmProperties> FndPmPropertiesStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmOwners.FndStatusLkp))]
        public virtual ICollection<PmOwners> StatusFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmOwners.FndNationalityLkp))]
        public virtual ICollection<PmOwners> NationalityFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmOwners.FndCountryLkp))]
        public virtual ICollection<PmOwners> CountryyFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmOwners.FndCityLkp))]
        public virtual ICollection<PmOwners> CityFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmOwnersTaxDetails.FndPmActivityTypeLkp))]
        public virtual ICollection<PmOwnersTaxDetails> PmActivityLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmTenants.FndStatusLkp))]
        public virtual ICollection<PmTenants> PmTenantStatusFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmTenants.FndNationalityLkp))]
        public virtual ICollection<PmTenants> PmTenantNationalityFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmTenants.FndCountryLkp))]
        public virtual ICollection<PmTenants> PmTenantCountryyFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmTenants.FndCityLkp))]
        public virtual ICollection<PmTenants> PmTenantCityFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmTenants.FndPaymentMethodLkp))]
        public virtual ICollection<PmTenants> PmTenantPaymentMethodLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmTenants.FndSpecialGenderLkp))]
        public virtual ICollection<PmTenants> PmTenantSpecialGenderFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmTenants.FndPassportCountryLkp))]
        public virtual ICollection<PmTenants> PmTenantPassportCountryFndLookupValuesCollection { get; protected set; }

        [InverseProperty(nameof(PmTenants.FndMaritalStatusLkp))]
        public virtual ICollection<PmTenants> PmTenantMaritalStatusLookupValuesCollection { get; protected set; }


        [InverseProperty(nameof(PmContract.FndActivityLkp))]
        public virtual ICollection<PmContract> PmActivityLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmContract.FndStatusLkp))]
        public virtual ICollection<PmContract> PmStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmContract.FndUnitTypeLkp))]
        public virtual ICollection<PmContract> PmUnitTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmContract.FndPaymentNoLkp))]
        public virtual ICollection<PmContract> PmPaymentNoLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmContractPayments.FndBankLkp))]
        public virtual ICollection<PmContractPayments> PmBankLkpCollection { get; protected set; }

        [InverseProperty(nameof(PmContractPayments.FndPaymentTypeLkp))]
        public virtual ICollection<PmContractPayments> PmPaymentTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(ArInvoiceHd.FndLookupValuesArInvoiceHdStatusLkp))]
        public virtual ICollection<ArInvoiceHd> FndLookupValuesArInvoiceHdStatusLkp { get; protected set; }

        [InverseProperty(nameof(ArInvoiceHd.FndLookupValuesArInvoiceHdSourceLkp))]
        public virtual ICollection<ArInvoiceHd> FndLookupValuesArInvoiceHdSourceLkp { get; protected set; }

        [InverseProperty(nameof(ArSecurityDepositInterface.FndSourceCodeLkp))]
        public virtual ICollection<ArSecurityDepositInterface> FndSourceCodeLkpCollection { get; protected set; }

        [InverseProperty(nameof(ArSecurityDepositInterface.FndStatusLkp))]
        public virtual ICollection<ArSecurityDepositInterface> FndStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(ArReceipts.FndStatusLkp))]
        public virtual ICollection<ArReceipts> ArReceiptStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(ArReceiptDetails.Bank))]
        public virtual ICollection<ArReceiptDetails> ArReceiptDetailsBanks { get; protected set; }

        [InverseProperty(nameof(ArReceiptsOnAccount.FndReceiptTypeLkp))]
        public virtual ICollection<ArReceiptsOnAccount> ArReceiptsOnAccountReceiptTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(TmCharityBoxActionDetails.FndLookupValuesStatusLkp))]
        public virtual ICollection<TmCharityBoxActionDetails> FndLookupValuesStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(TmCharityBoxActionDetails.FndLookupValuesActionLkp))]
        public virtual ICollection<TmCharityBoxActionDetails> FndLookupValuesActionLkpCollection { get; protected set; }

        public virtual ICollection<TmCharityBoxCollectMembers> TmCharityBoxCollectMembers { get; protected set; }

        public virtual ICollection<TmCharityBoxCollect> TmCharityBoxCollect { get; protected set; }


        [InverseProperty(nameof(SpFamilies.FndBankLkp))]
        public virtual ICollection<SpFamilies> FndBankLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpFamilies.FndCityLkp))]
        public virtual ICollection<SpFamilies> FndCityLkpSpFamiliesCollection { get; protected set; }

        [InverseProperty(nameof(SpFamilies.FndHousingStatusLkp))]
        public virtual ICollection<SpFamilies> FndHousingStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpFamilies.FndHousingTypeLkp))]
        public virtual ICollection<SpFamilies> FndHousingTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpFamilies.FndMaritalStatusLkp))]
        public virtual ICollection<SpFamilies> FndMaritalStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpFamilies.FndNationalityLkp))]
        public virtual ICollection<SpFamilies> FndNationalityLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpFamilies.FndRelativesTypeLkp))]
        public virtual ICollection<SpFamilies> FndRelativesTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpCases.FndLookupValuesNationalityLkp))]
        public virtual ICollection<SpCases> FndLookupValuesNationalityLkp { get; protected set; }

        [InverseProperty(nameof(SpCases.FndLookupValuesMaritalStatusLkp))]
        public virtual ICollection<SpCases> FndLookupValuesMaritalStatusLkp { get; protected set; }

        [InverseProperty(nameof(SpCases.FndLookupValuesHealthStatusLkp))]
        public virtual ICollection<SpCases> FndLookupValuesHealthStatusLkp { get; protected set; }

        [InverseProperty(nameof(SpCases.FndLookupValuesEducationalLevelLkp))]
        public virtual ICollection<SpCases> FndLookupValuesEducationalLevelLkp { get; protected set; }

        [InverseProperty(nameof(SpCases.FndLookupValuesEducationalStageLkp))]
        public virtual ICollection<SpCases> FndLookupValuesEducationalStageLkp { get; protected set; }

        [InverseProperty(nameof(SpCases.FndLookupValuesSponsorCategoryLkp))]
        public virtual ICollection<SpCases> FndLookupValuesSponsorCategoryLkp { get; protected set; }

        [InverseProperty(nameof(SpCases.FndLookupValuesGenderLkp))]
        public virtual ICollection<SpCases> FndLookupValuesGenderLkp { get; protected set; }

        [InverseProperty(nameof(SpCases.FndLookupValuesStatusLkp))]
        public virtual ICollection<SpCases> FndLookupValuesStatusLkpSP { get; protected set; }

        [InverseProperty(nameof(SpCaseOperations.FndReasonLkp))]
        public virtual ICollection<SpCaseOperations> FndReasonLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpCaseOperations.FndOperationTypeLkp))]
        public virtual ICollection<SpCaseOperations> FndOperationTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(ApInvoiceHd.FndStatusLkp))]
        public virtual ICollection<ApInvoiceHd> FndStatusLkpApInvoiceHdCollection { get; protected set; }

        [InverseProperty(nameof(ApInvoiceHd.FndHdTypeLkp))]
        public virtual ICollection<ApInvoiceHd> FndHdTypeLkpApInvoiceHdCollection { get; protected set; }

        [InverseProperty(nameof(ApPrepaid.FndStatusLkp))]
        public virtual ICollection<ApPrepaid> FndStatusLkpApPrepaidCollection { get; protected set; }

        [InverseProperty(nameof(ApPrepaid.FndSourceCodeLkp))]
        public virtual ICollection<ApPrepaid> FndSourceCodeLkpApPrepaidCollection { get; protected set; }

        [InverseProperty(nameof(ApPaymentsTransactions.FndStatusLkp))]
        public virtual ICollection<ApPaymentsTransactions> FndStatusLkpApPaymentsTransactionsCollection { get; protected set; }

        [InverseProperty(nameof(ApPaymentsTransactions.FndPaymentTypeLkp))]
        public virtual ICollection<ApPaymentsTransactions> FndPaymentTypeLkpApPaymentsTransactionsCollection { get; protected set; }
        [InverseProperty(nameof(SpBeneficent.FndLookupCityValues))]
        public virtual ICollection<SpBeneficent> FndBenefCityLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpBeneficent.FndLookupFirstTitleValues))]
        public virtual ICollection<SpBeneficent> FndBenefFirstTitleLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpBeneficent.FndLookupGenderValues))]
        public virtual ICollection<SpBeneficent> FndBenefGenderLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpBeneficent.FndLookupLastTitleValues))]
        public virtual ICollection<SpBeneficent> FndBenefLastTitleLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpBeneficent.FndLookupNationalityValues))]
        public virtual ICollection<SpBeneficent> FndBenefNationalityLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpCaseHistory.FndCaseStatusLkp))]
        public virtual ICollection<SpCaseHistory> FndCaseStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(SpCaseHistory.FndOperationTypeLkp))]
        public virtual ICollection<SpCaseHistory> FndOperationSpCaseHistoryTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(IvReceiveHd.FndStatusLkp))]
        public virtual ICollection<IvReceiveHd> FndStatusIvReceiveHdLkpCollection { get; protected set; }

        //[InverseProperty(nameof(IvReceiveHd.FndReceiveTypeLkp))]
        //public virtual ICollection<IvReceiveHd> FndReceiveTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(PyPayrollOperations.FndJobLkp))]
        public virtual ICollection<PyPayrollOperations> FndJobLkpCollection { get; protected set; }

        [InverseProperty(nameof(PyPayrollOperations.FndStatusLkp))]
        public virtual ICollection<PyPayrollOperations> FndStatusLkpPyPayrollCollection { get; protected set; }

        [InverseProperty(nameof(GlJeIntegrationHeaders.FndStatusLkp))]
        public virtual ICollection<GlJeIntegrationHeaders> FndGlJeIntegrationHeadersStatusLkp { get; protected set; }


        [InverseProperty(nameof(GlJeIntegrationHeaders.FndGlJeIntegrationSourceLkp))]
        public virtual ICollection<GlJeIntegrationHeaders> FndGlJeIntegrationSourceLkp { get; protected set; }

        public virtual ICollection<IvWarehouses> IvWarehouses { get; protected set; }

       

        #endregion

        #region HrPersonsCollections

        [InverseProperty(nameof(HrPersons.FndBankLkp))]
        public virtual ICollection<HrPersons> FndBankLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndCountryOfBrithLkp))]
        public virtual ICollection<HrPersons> FndCountryOfBrithLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndDestinationCountryLkp))]
        public virtual ICollection<HrPersons> FndDestinationCountryLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndFirstTitleLkp))]
        public virtual ICollection<HrPersons> FndFirstTitleLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndGenderLkp))]
        public virtual ICollection<HrPersons> FndGenderLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndJobGradeLkp))]
        public virtual ICollection<HrPersons> FndJobGradeLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndJobLkp))]
        public virtual ICollection<HrPersons> FndJobLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndMaritalStatusLkp))]
        public virtual ICollection<HrPersons> FndMaritalStatusLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndNationalityLkp))]
        public virtual ICollection<HrPersons> FndNationalityLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndNoticeUnitLkp))]
        public virtual ICollection<HrPersons> FndNoticeUnitLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndPaymentTypeLkp))]
        public virtual ICollection<HrPersons> FndPaymentTypeLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndPersonCategoryLkp))]
        public virtual ICollection<HrPersons> FndPersonCategoryLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndPersonTypeLkp))]
        public virtual ICollection<HrPersons> FndPersonTypeLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndProbationUnitLkp))]
        public virtual ICollection<HrPersons> FndProbationUnitLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndSponserLkp))]
        public virtual ICollection<HrPersons> FndSponserLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndStatusLkp))]
        public virtual ICollection<HrPersons> FndStatusLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersons.FndTicketClassLkp))]
        public virtual ICollection<HrPersons> FndTicketClassLkpHrPersonsCollection { get; protected set; }

        [InverseProperty(nameof(HrPersonVisaDetails.FndIssuedByLkp))]
        public virtual ICollection<HrPersonVisaDetails> FndIssuedByLkpCollection { get; protected set; }

        [InverseProperty(nameof(HrPersonVisaDetails.FndPlaceOfIssueLkp))]
        public virtual ICollection<HrPersonVisaDetails> FndPlaceOfIssueLkpCollection { get; protected set; }

        [InverseProperty(nameof(HrPersonVisaDetails.FndVisaTypeLkp))]
        public virtual ICollection<HrPersonVisaDetails> FndVisaTypeLkpCollection { get; protected set; }

        [InverseProperty(nameof(HrPersonPassportDetails.FndCountryOfIssueLkp))]
        public virtual ICollection<HrPersonPassportDetails> FndCountryOfIssueLkpCollection { get; protected set; }

        [InverseProperty(nameof(HrPersonPassportDetails.FndPassportTypeLkp))]
        public virtual ICollection<HrPersonPassportDetails> FndPassportTypeLkpCollection { get; protected set; }

        public virtual ICollection<HrPersonsDeductionHd> HrPersonsDeductionHd { get; protected set; }

        public virtual ICollection<HrPersonsDeductionTr> HrPersonsDeductionTr { get; protected set; }
       // public virtual ICollection<ArJobCardHd> ArJobCardHd { get; protected set; }

        #endregion

        #region ArJobCardHd

        [InverseProperty(nameof(ArJobCardHd.FndJobTypeLkp))]
        public virtual ICollection<ArJobCardHd> JobTypeLkpIdCollection { get; protected set; }

        [InverseProperty(nameof(ArJobCardHd.FndPoliceReportSourceLkp))]
        public virtual ICollection<ArJobCardHd> PoliceReportSourceLkpIdCollection { get; protected set; }


        [InverseProperty(nameof(ArJobCardHd.FndVehicleEmirateLkp))]
        public virtual ICollection<ArJobCardHd> VehicleEmirateLkpIdCollection { get; protected set; }


        [InverseProperty(nameof(ArJobCardHd.FndVehicleMakeLkp))]
        public virtual ICollection<ArJobCardHd> VehicleMakeLkpIdCollection { get; protected set; }


        [InverseProperty(nameof(ArJobCardHd.FndVehicleModelLkp))]
        public virtual ICollection<ArJobCardHd> VehicleModelLkpIdCollection { get; protected set; }


        [InverseProperty(nameof(ArJobCardHd.FndVehicleColorLkp))]
        public virtual ICollection<ArJobCardHd> FndVehicleColorLkpCollection { get; protected set; }


        [InverseProperty(nameof(ArJobCardHd.FndExcessStatusLkp))]
        public virtual ICollection<ArJobCardHd> FndExcessStatusLkpCollection { get; protected set; }

        [InverseProperty(nameof(ArJobCardHd.FndStatusLkp))]
        public virtual ICollection<ArJobCardHd> ArJobCardFndStatusLkpCollection { get; protected set; }
        #endregion

        #region ArInvoiceSettlementHd

        [InverseProperty(nameof(ArInvoiceSettlementHd.FndStatusLkp))]
        public virtual ICollection<ArInvoiceSettlementHd> ArInvoiceSettlementHdCollection { get; protected set; }

        #endregion

        #region AbpKpiRole

        [InverseProperty(nameof(AbpKpiRole.FndKpisLkp))]
        public virtual ICollection<AbpKpiRole> AbpKpiRoleCollection { get; protected set; }

        #endregion
    }
}

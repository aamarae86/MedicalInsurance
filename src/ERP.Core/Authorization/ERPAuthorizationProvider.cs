using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace ERP.Authorization
{
    public class ERPAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_TenantData, L("TenantData"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TenantData_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_Pages, L("Pages"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Pages_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_PagesDocs, L("Pages"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_PagesDocs_Update, L("Update"), multiTenancySides: MultiTenancySides.Host);
             
            
            context.CreatePermission(PermissionNames.Pages_TenantFreeModules, L("TenantFreeModules"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_TenantFreeModules_Update, L("Update"), multiTenancySides: MultiTenancySides.Host);
    
 


        #region Users
        context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Users_Insert, L("Insert"));
            context.CreatePermission(PermissionNames.Pages_Users_Update, L("Update"));
            context.CreatePermission(PermissionNames.Pages_Users_Delete, L("Delete"));
            context.CreatePermission(PermissionNames.Pages_Users_Audit, L("Audit"));
            #endregion

            #region Roles
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Roles_Insert, L("Insert"));
            context.CreatePermission(PermissionNames.Pages_Roles_Update, L("Update"));
            context.CreatePermission(PermissionNames.Pages_Roles_Delete, L("Delete"));
            context.CreatePermission(PermissionNames.Pages_Roles_Audit, L("Audit"));
            #endregion

            #region Tenants
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Tenants_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Tenants_Update, L("Update"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Tenants_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Host);
            #endregion

            #region Currencies
            context.CreatePermission(PermissionNames.Pages_Currencies, L("Currencies"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Currencies_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Currencies_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Currencies_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_Currencies_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PortalUserReg
            context.CreatePermission(PermissionNames.Pages_PortalUserReg, L("PortalUserReg"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUserReg_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUserReg_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUserReg_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUserReg_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ArCustomers
            context.CreatePermission(PermissionNames.Pages_ArCustomers, L("ArCustomers"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArCustomers_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArCustomers_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArCustomers_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArCustomers_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FaAssetCategory
            context.CreatePermission(PermissionNames.Pages_FaAssetCategory, L("FaAssetCategory"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetCategory_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetCategory_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetCategory_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetCategory_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrPersonsAdditionHd
            context.CreatePermission(PermissionNames.Pages_HrPersonsAdditionHd, L("HrPersonsAdditionHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsAdditionHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsAdditionHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsAdditionHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsAdditionHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PyElements
            context.CreatePermission(PermissionNames.Pages_PyElements, L("PyElements"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyElements_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyElements_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyElements_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyElements_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ApPdcInterface
            context.CreatePermission(PermissionNames.Pages_ApPdcInterface, L("ApPdcInterface"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPdcInterface_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPdcInterface_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPdcInterface_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPdcInterface_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ArPdcInterface
            context.CreatePermission(PermissionNames.Pages_ArPdcInterface, L("ArPdcInterface"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArPdcInterface_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArPdcInterface_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArPdcInterface_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArPdcInterface_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion
            #region ArJobSurveyHd
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyHd, L("ArJobSurveyHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion
            #region ArJobSurveyPartsList
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyPartsList, L("ArJobSurveyPartsList"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyPartsList_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyPartsList_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyPartsList_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyPartsList_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobSurveyPartsList_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion
            #region ApUserBankAccess
            context.CreatePermission(PermissionNames.Pages_ApUserBankAccess, L("ApUserBankAccess"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApUserBankAccess_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApUserBankAccess_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApUserBankAccess_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApUserBankAccess_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FndCollectors
            context.CreatePermission(PermissionNames.Pages_FndCollectors, L("FndCollectors"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndCollectors_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndCollectors_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndCollectors_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndCollectors_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FndSalesMen
            context.CreatePermission(PermissionNames.Pages_FndSalesMen, L("FndSalesMen"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndSalesMen_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndSalesMen_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndSalesMen_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndSalesMen_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ApBanks
            context.CreatePermission(PermissionNames.Pages_ApBanks, L("ApBanks"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApBanks_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApBanks_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApBanks_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApBanks_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GlAccounts
            context.CreatePermission(PermissionNames.Pages_GlAccounts, L("GlAccounts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccounts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccounts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccounts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccounts_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GeneralUnPost
            context.CreatePermission(PermissionNames.Pages_GeneralUnPost, L("GeneralUnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GeneralUnPost_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GeneralUnPost_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GeneralUnPost_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GeneralUnPost_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GlJeHeaders
            context.CreatePermission(PermissionNames.Pages_GlJeHeaders, L("GlJeHeaders"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeHeaders_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeHeaders_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeHeaders_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeHeaders_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GlMainAccounts
            context.CreatePermission(PermissionNames.Pages_GlMainAccounts, L("GlMainAccounts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlMainAccounts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlMainAccounts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlMainAccounts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlMainAccounts_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GlAccHeaders
            context.CreatePermission(PermissionNames.Pages_GlAccHeaders, L("GlAccHeaders"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccHeaders_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccHeaders_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccHeaders_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccHeaders_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GlAccDetails
            context.CreatePermission(PermissionNames.Pages_GlAccDetails, L("GlAccDetails"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccDetails_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccDetails_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccDetails_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccDetails_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ArMiscReceiptHeaders
            context.CreatePermission(PermissionNames.Pages_ArMiscReceiptHeaders, L("ArMiscReceiptHeaders"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArMiscReceiptHeaders_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArMiscReceiptHeaders_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArMiscReceiptHeaders_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArMiscReceiptHeaders_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ArReceipts
            context.CreatePermission(PermissionNames.Pages_ArReceipts, L("ArReceipts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArReceipts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArReceipts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArReceipts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArReceipts_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ApMiscPaymentHeaders
            context.CreatePermission(PermissionNames.Pages_ApMiscPaymentHeaders, L("ApMiscPaymentHeaders"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApMiscPaymentHeaders_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApMiscPaymentHeaders_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApMiscPaymentHeaders_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApMiscPaymentHeaders_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GlPeriodsYears
            context.CreatePermission(PermissionNames.Pages_GlPeriodsYears, L("GlPeriodsYears"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlPeriodsYears_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlPeriodsYears_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlPeriodsYears_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlPeriodsYears_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScFndAidRequestType
            context.CreatePermission(PermissionNames.Pages_ScFndAidRequestType, L("ScFndAidRequestType"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndAidRequestType_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndAidRequestType_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndAidRequestType_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndAidRequestType_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScMaintenanceTechnicalReport
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceTechnicalReport, L("ScMaintenanceTechnicalReport"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceTechnicalReport_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceTechnicalReport_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceTechnicalReport_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceTechnicalReport_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceTechnicalReport_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceTechnicalReport_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScFndPortalIntervalSetting
            context.CreatePermission(PermissionNames.Pages_ScFndPortalIntervalSetting, L("ScFndPortalIntervalSetting"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndPortalIntervalSetting_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndPortalIntervalSetting_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndPortalIntervalSetting_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndPortalIntervalSetting_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScFndProtalAttachmentSetting
            context.CreatePermission(PermissionNames.Pages_ScFndProtalAttachmentSetting, L("ScFndProtalAttachmentSetting"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndProtalAttachmentSetting_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndProtalAttachmentSetting_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndProtalAttachmentSetting_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScFndProtalAttachmentSetting_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScComityMembers
            context.CreatePermission(PermissionNames.Pages_ScComityMembers, L("ScComityMembers"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScComityMembers_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScComityMembers_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScComityMembers_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScComityMembers_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PortalUsers
            context.CreatePermission(PermissionNames.Pages_PortalUser, L("PortalUsers"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUser_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUser_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUser_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUser_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScCampainsAid
            context.CreatePermission(PermissionNames.Pages_ScCampainsAid, L("ScCampainsAid"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampainsAid_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampainsAid_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampainsAid_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampainsAid_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScCampains
            context.CreatePermission(PermissionNames.Pages_ScCampains, L("ScCampains"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampains_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampains_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampains_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampains_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScCampainsDetailDeliver
            context.CreatePermission(PermissionNames.Pages_ScCampainsDetailDeliver, L("ScCampainsDetailDeliver"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampainsDetailDeliver_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScPortalRequestStudy
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestStudy, L("ScPortalRequestStudy"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestStudy_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestStudy_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestStudy_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestStudy_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestStudy_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScPortalRequestMgrDecision
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestMgrDecision, L("ScPortalRequestMgrDecision"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestMgrDecision_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestMgrDecision_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestMgrDecision_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestMgrDecision_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrVacationsTypes
            context.CreatePermission(PermissionNames.Pages_HrVacationsTypes, L("HrVacationsTypes"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrVacationsTypes_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrVacationsTypes_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrVacationsTypes_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrVacationsTypes_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScPortalRequest
            context.CreatePermission(PermissionNames.Pages_ScPortalRequests, L("ScPortalRequest"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequests_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequests_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequests_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequests_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScCommittee
            context.CreatePermission(PermissionNames.Pages_ScCommittee, L("ScCommittee"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommittee_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommittee_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommittee_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommittee_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScCommittee_Detail

            context.CreatePermission(PermissionNames.ActionPages_ScCommittee, L("ScCommittee"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommittee_Detail_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommittee_Detail_Postpone, L("Postpone"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommittee_Detail_Reject, L("Reject"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScCommitteesCheck
            context.CreatePermission(PermissionNames.Pages_ScCommitteesCheck, L("ScCommitteesCheck"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommitteesCheck_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommitteesCheck_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommitteesCheck_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommitteesCheck_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ArDrCrHd
            context.CreatePermission(PermissionNames.Pages_ArDrCrHd, L("ArDrCrHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArDrCrHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArDrCrHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArDrCrHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArDrCrHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArDrCrHd_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PmOwners
            context.CreatePermission(PermissionNames.Pages_PmOwners, L("PmOwners"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmOwners_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmOwners_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmOwners_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmOwners_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PmTenants
            context.CreatePermission(PermissionNames.Pages_PmTenants, L("PmTenants"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTenants_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTenants_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTenants_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTenants_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PmProperties
            context.CreatePermission(PermissionNames.Pages_PmProperties, L("PmProperties"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmProperties_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmProperties_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmProperties_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmProperties_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PmContract
            context.CreatePermission(PermissionNames.Pages_PmContract, L("PmContract"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmContract_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmContract_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmContract_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmContract_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PmOtherPaymentTypes
            context.CreatePermission(PermissionNames.Pages_PmOtherPaymentTypes, L("PmOtherPaymentTypes"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmOtherPaymentTypes_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmOtherPaymentTypes_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmOtherPaymentTypes_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmOtherPaymentTypes_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ArInvoiceHd
            context.CreatePermission(PermissionNames.Pages_ArInvoiceHd, L("ArInvoiceHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PmTerminateContracts
            context.CreatePermission(PermissionNames.Pages_PmTerminateContracts, L("PmTerminateContracts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTerminateContracts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTerminateContracts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTerminateContracts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTerminateContracts_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PmCancellationContracts
            context.CreatePermission(PermissionNames.Pages_PmCancellationContracts, L("PmCancellationContracts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmCancellationContracts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmCancellationContracts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmCancellationContracts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmCancellationContracts_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ArSecurityDepositInterface
            context.CreatePermission(PermissionNames.Pages_ArSecurityDepositInterface, L("ArSecurityDepositInterface"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArSecurityDepositInterface_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArSecurityDepositInterface_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArSecurityDepositInterface_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArSecurityDepositInterface_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArSecurityDepositInterface_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArSecurityDepositInterface_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmCharityBoxesType
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxesType, L("TmCharityBoxesType"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxesType_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxesType_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxesType_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxesType_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmRegions
            context.CreatePermission(PermissionNames.Pages_TmRegions, L("TmRegions"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmRegions_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmRegions_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmRegions_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmRegions_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmLocations
            context.CreatePermission(PermissionNames.Pages_TmLocations, L("TmLocations"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmLocations_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmLocations_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmLocations_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmLocations_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmCharityBoxReceive
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxReceive, L("TmCharityBoxReceive"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxReceive_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxReceive_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxReceive_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxReceive_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmCharityBoxes
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxes, L("TmCharityBoxes"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxes_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmSupervisors
            context.CreatePermission(PermissionNames.Pages_TmSupervisors, L("TmSupervisors"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmSupervisors_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmSupervisors_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmSupervisors_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmSupervisors_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmCharityBoxActions
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxActions, L("TmCharityBoxActions"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxActions_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxActions_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxActions_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxActions_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmDamagedCharityBoxs
            context.CreatePermission(PermissionNames.Pages_TmDamagedCharityBoxs, L("TmDamagedCharityBoxs"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmDamagedCharityBoxs_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmDamagedCharityBoxs_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmDamagedCharityBoxs_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmDamagedCharityBoxs_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmCharityBoxCollectMembers
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollectMembers, L("TmCharityBoxCollectMembers"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollectMembers_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollectMembers_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollectMembers_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollectMembers_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TmCharityBoxCollect
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollect, L("TmCharityBoxCollect"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollect_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollect_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollect_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollect_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region SpFamilies
            context.CreatePermission(PermissionNames.Pages_SpFamilies, L("SpFamilies"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpFamilies_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpFamilies_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpFamilies_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpFamilies_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region SpBeneficent
            context.CreatePermission(PermissionNames.Pages_SpBeneficent, L("SpBeneficent"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpBeneficent_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpBeneficent_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpBeneficent_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpBeneficent_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region SpCases
            context.CreatePermission(PermissionNames.Pages_SpCases, L("SpCases"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCases_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCases_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCases_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCases_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region SpCaseEditData
            context.CreatePermission(PermissionNames.Pages_SpCaseEditData, L("SpCaseEditData"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseEditData_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseEditData_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseEditData_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseEditData_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region SpContracts
            context.CreatePermission(PermissionNames.Pages_SpContracts, L("SpContracts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpContracts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpContracts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpContracts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpContracts_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PoPurchaseOrder
            context.CreatePermission(PermissionNames.Pages_PoPurchaseOrder, L("PoPurchaseOrder"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PoPurchaseOrder_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PoPurchaseOrder_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PoPurchaseOrder_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PoPurchaseOrder_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PoPurchaseOrder_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvStoreIssue
            context.CreatePermission(PermissionNames.Pages_IvStoreIssue, L("IvStoreIssue"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvStoreIssue_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvStoreIssue_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvStoreIssue_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvStoreIssue_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvStoreIssue_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FaAssetDeprnHd
            context.CreatePermission(PermissionNames.Pages_FaAssetDeprnHd, L("FaAssetDeprnHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetDeprnHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetDeprnHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetDeprnHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetDeprnHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetDeprnHd_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetDeprnHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FaAsset
            context.CreatePermission(PermissionNames.Pages_FaAsset, L("FaAsset"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAsset_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAsset_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAsset_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAsset_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAsset_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAsset_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvWarehouses
            context.CreatePermission(PermissionNames.Pages_IvWarehouses, L("IvWarehouses"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvWarehouses_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvWarehouses_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvWarehouses_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvWarehouses_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvUnits
            context.CreatePermission(PermissionNames.Pages_IvUnits, L("IvUnits"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvUnits_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvUnits_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvUnits_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvUnits_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvItemsTypesConfigure
            context.CreatePermission(PermissionNames.Pages_IvItemsTypesConfigure, L("IvItemsTypesConfigure"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvItemsTypesConfigure_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvItemsTypesConfigure_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvItemsTypesConfigure_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvItemsTypesConfigure_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrOrganizations
            context.CreatePermission(PermissionNames.Pages_HrOrganizations, L("HrOrganizations"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrOrganizations_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrOrganizations_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrOrganizations_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrOrganizations_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PyPayrollTypes
            context.CreatePermission(PermissionNames.Pages_PyPayrollTypes, L("PyPayrollTypes"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollTypes_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollTypes_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollTypes_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollTypes_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrPersons
            context.CreatePermission(PermissionNames.Pages_HrPersons, L("HrPersons"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersons_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersons_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersons_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersons_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrPersonsDeductionHd
            context.CreatePermission(PermissionNames.Pages_HrPersonsDeductionHd, L("HrPersonsDeductionHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsDeductionHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsDeductionHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsDeductionHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsDeductionHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrPersonVacations
            context.CreatePermission(PermissionNames.Pages_HrPersonVacations, L("HrPersonVacations"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonVacations_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonVacations_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonVacations_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonVacations_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonVacations_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion


            #region IvPriceListHd
            context.CreatePermission(PermissionNames.Pages_IvPriceListHd, L("IvPriceListHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPriceListHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPriceListHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPriceListHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPriceListHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPriceListHd_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPriceListHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvSaleHd
            context.CreatePermission(PermissionNames.Pages_IvSaleHd, L("IvSaleHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvSaleHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvSaleHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvSaleHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvSaleHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvSaleHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrPaperRequest
            context.CreatePermission(PermissionNames.Pages_HrPaperRequest, L("HrPaperRequest"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPaperRequest_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPaperRequest_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPaperRequest_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPaperRequest_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPaperRequest_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PaperReqType
            context.CreatePermission(PermissionNames.Pages_PaperReqType, L("PaperReqType"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PaperReqType_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PaperReqType_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PaperReqType_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PaperReqType_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PaperReqType_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrPersonPermission
            context.CreatePermission(PermissionNames.Pages_HrPersonPermission, L("HrPersonPermission"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonPermission_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonPermission_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonPermission_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonPermission_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonPermission_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion
            #region HrPermissionType
            context.CreatePermission(PermissionNames.Pages_HrPermissionType, L("HrPermissionType"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPermissionType_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPermissionType_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPermissionType_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPermissionType_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPermissionType_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrPersonRequestDocument
            context.CreatePermission(PermissionNames.Pages_HrPersonRequestDocument, L("HrPersonRequestDocument"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonRequestDocument_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonRequestDocument_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonRequestDocument_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonRequestDocument_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonRequestDocument_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrPersonTimeSheet
            context.CreatePermission(PermissionNames.Pages_HrPersonTimeSheet, L("HrPersonTimeSheet"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonTimeSheet_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonTimeSheet_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonTimeSheet_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonTimeSheet_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonTimeSheet_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion
            

            #region IvSaleHdInQuery
            context.CreatePermission(PermissionNames.Pages_IvSaleHdInQuery, L("IvSaleHdQuery"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvSaleHdInQuery_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion


            #region IvReturnSaleHd
            context.CreatePermission(PermissionNames.Pages_IvReturnSaleHd, L("IvReturnSaleHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReturnSaleHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReturnSaleHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvReturnReceiveHd
            context.CreatePermission(PermissionNames.Pages_IvReturnReceiveHd, L("IvReturnReceiveHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReturnReceiveHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReturnReceiveHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReturnReceiveHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FndTaxType
            context.CreatePermission(PermissionNames.Pages_FndTaxType, L("FndTaxType"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndTaxType_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndTaxType_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndTaxType_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FndTaxType_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion




            #region IvInventorySetting
            context.CreatePermission(PermissionNames.Pages_IvInventorySetting, L("IvInventorySetting"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvInventorySetting_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvInventorySetting_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvInventorySetting_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvInventorySetting_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvInventorySetting_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvInventorySetting_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PyPayrollOperations
            context.CreatePermission(PermissionNames.Pages_PyPayrollOperations, L("PyPayrollOperations"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollOperations_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollOperations_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollOperations_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollOperations_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollOperations_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvReceiveHd
            context.CreatePermission(PermissionNames.Pages_IvReceiveHd, L("IvReceiveHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReceiveHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReceiveHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReceiveHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReceiveHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReceiveHd_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvAdjustmentHd
            context.CreatePermission(PermissionNames.Pages_IvAdjustmentHd, L("IvAdjustmentHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvAdjustmentHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvAdjustmentHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvAdjustmentHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvAdjustmentHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvItems
            context.CreatePermission(PermissionNames.Pages_IvItems, L("IvItems"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvItems_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvItems_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvItems_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvItems_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region IvUserWarehousesPrivileges
            context.CreatePermission(PermissionNames.Pages_IvUserWarehousesPrivileges, L("IvUserWarehousesPrivileges"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvUserWarehousesPrivileges_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvUserWarehousesPrivileges_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvUserWarehousesPrivileges_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvUserWarehousesPrivileges_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ApVendors
            context.CreatePermission(PermissionNames.Pages_ApVendors, L("ApVendors"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApVendors_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApVendors_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApVendors_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApVendors_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ApInvoiceHd
            context.CreatePermission(PermissionNames.Pages_ApInvoiceHd, L("ApInvoiceHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApInvoiceHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApInvoiceHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApInvoiceHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApInvoiceHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScDeliveryOtherAids
            context.CreatePermission(PermissionNames.Pages_ScDeliveryOtherAids, L("ScDeliveryOtherAids"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScDeliveryOtherAids_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScDeliveryOtherAids_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScDeliveryOtherAids_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScDeliveryOtherAids_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScDeliveryOtherAids_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ApPaymentsTransactions
            context.CreatePermission(PermissionNames.Pages_ApPaymentsTransactions, L("ApPaymentsTransactions"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPaymentsTransactions_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPaymentsTransactions_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPaymentsTransactions_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPaymentsTransactions_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GlAccMappingHd
            context.CreatePermission(PermissionNames.Pages_GlAccMappingHd, L("GlAccMappingHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccMappingHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccMappingHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccMappingHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccMappingHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region GlJeIntegrationHeaders
            context.CreatePermission(PermissionNames.Pages_GlJeIntegrationHeaders, L("GlJeIntegrationHeaders"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeIntegrationHeaders_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeIntegrationHeaders_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeIntegrationHeaders_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeIntegrationHeaders_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeIntegrationHeaders_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeIntegrationHeaders_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScMaintenanceQuotations
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceQuotations, L("ScMaintenanceQuotations"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceQuotations_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceQuotations_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceQuotations_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceQuotations_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceQuotations_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceQuotations_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScMaintenanceContract
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceContract, L("ScMaintenanceContract"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceContract_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceContract_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceContract_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceContract_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceContract_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenanceContract_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ScMaintenancePayments
            context.CreatePermission(PermissionNames.Pages_ScMaintenancePayments, L("ScMaintenancePayments"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenancePayments_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenancePayments_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenancePayments_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenancePayments_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenancePayments_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScMaintenancePayments_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region SpPaymentSetting
            context.CreatePermission(PermissionNames.Pages_SpPaymentSetting, L("SpPaymentSetting"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPaymentSetting_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPaymentSetting_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPaymentSetting_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPaymentSetting_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region SpPayments
            context.CreatePermission(PermissionNames.Pages_SpPayments, L("SpPayments"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPayments_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPayments_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPayments_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPayments_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPayments_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpPayments_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region PortalUserData
            context.CreatePermission(PermissionNames.Pages_PortalUserData, L("PortalUserData"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUserData_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUserData_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUserData_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PortalUserData_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region HrReports
            context.CreatePermission(PermissionNames.Pages_RptPyPayrollOperationPersons, L("RptPyPayrollOperationPersons"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region TaxReports
            context.CreatePermission(PermissionNames.Pages_TaxReports, L("TaxReports"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region Tax2Reports
            context.CreatePermission(PermissionNames.Pages_TaxReports2, L("TaxReports2"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion


            #region CrmLeadsPersons
            context.CreatePermission(PermissionNames.Pages_CrmLeadsPersons, L("CrmLeadsPersons"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmLeadsPersons_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmLeadsPersons_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmLeadsPersons_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmLeadsPersons_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion



            #region CrmDeals
            context.CreatePermission(PermissionNames.Pages_CrmDeals, L("CrmDeals"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmDeals_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmDeals_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmDeals_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmDeals_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion


            #region ActivityCall
            context.CreatePermission(PermissionNames.Pages_ActivityCall, L("ActivityCall"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityCall_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityCall_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityCall_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityCall_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);


            #endregion


            #region ActivityTasks
            context.CreatePermission(PermissionNames.Pages_ActivityTasks, L("ActivityTasks"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityTasks_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityTasks_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityTasks_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityTasks_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityTasks_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ActivityMeeting
            context.CreatePermission(PermissionNames.Pages_ActivityMeeting, L("ActivityMeeting"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityMeeting_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityMeeting_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityMeeting_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityMeeting_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ActivityMeeting_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region CrmLeadsPersons
            context.CreatePermission(PermissionNames.Pages_CrmContacts, L("CrmContacts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmContacts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmContacts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmContacts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion

            #region CrmContactUs
            context.CreatePermission(PermissionNames.Pages_CrmContactUs, L("CrmContactUs"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmContactUs_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmContactUs_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmContactUs_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmContactUs_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FmEngineers
            context.CreatePermission(PermissionNames.Pages_FmEngineers, L("FmEngineers"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmEngineers_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmEngineers_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmEngineers_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmEngineers_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmEngineers_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmEngineers_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region CrmProjects
            context.CreatePermission(PermissionNames.Pages_CrmProjects, L("CrmProjects"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmProjects_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmProjects_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmProjects_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission(PermissionNames.Pages_CrmProjects_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission(PermissionNames.Pages_CrmProjects_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmProjects_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region CrmProducts
            context.CreatePermission(PermissionNames.Pages_CrmProducts, L("CrmProducts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmProducts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmProducts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmProducts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission(PermissionNames.Pages_CrmProducts_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission(PermissionNames.Pages_CrmProducts_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmProducts_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region CrmServices
            context.CreatePermission(PermissionNames.Pages_CrmServices, L("CrmServices"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmServices_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmServices_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmServices_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission(PermissionNames.Pages_CrmServices_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission(PermissionNames.Pages_CrmServices_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmServices_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region CrmAboutUs
            context.CreatePermission(PermissionNames.Pages_CrmAboutUs, L("CrmAboutUs"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmAboutUs_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmAboutUs_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmAboutUs_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmAboutUs_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FmMaintRequisitionsExe
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsExe, L("FmMaintRequisitionsExe"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsExe_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsExe_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsExe_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsExe_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsExe_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsExe_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FmContracts
            context.CreatePermission(PermissionNames.Pages_FmContracts, L("FmContracts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmContracts_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmContracts_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmContracts_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmContracts_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmContracts_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmContracts_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region FmMaintRequisitionsHdr
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsHdr, L("FmMaintRequisitionsHdr"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsHdr_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsHdr_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsHdr_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsHdr_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsHdr_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FmMaintRequisitionsHdr_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region CrmQueries
            context.CreatePermission(PermissionNames.Pages_CrmQueries, L("CrmQueries"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_CrmQueries_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);

            #endregion

            #region ArJobCardHd
            context.CreatePermission(PermissionNames.Pages_ArJobCardHd, L("ArJobCardHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardHd_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ArInvoiceSettlementHd
            context.CreatePermission(PermissionNames.Pages_ArInvoiceSettlementHd, L("ArInvoiceSettlementHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceSettlementHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceSettlementHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceSettlementHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceSettlementHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceSettlementHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceSettlementHd_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion
			
			 #region ArJobCardPaymentHd
            context.CreatePermission(PermissionNames.Pages_ArJobCardPaymentHd, L("ArJobCardPaymentHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardPaymentHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardPaymentHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardPaymentHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardPaymentHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region Audit
            context.CreatePermission(PermissionNames.Pages_ApInvoiceHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApMiscPaymentHeaders_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPaymentsTransactions_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPdcInterface_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPrepaid_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArInvoiceHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArMiscReceiptHeaders_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArPdcInterface_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArReceipts_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlJeHeaders_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsAdditionHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonsDeductionHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_HrPersonVacations_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvAdjustmentHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvReceiveHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvStoreIssue_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmCancellationContracts_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmContract_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmTerminateContracts_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PoPurchaseOrder_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PyPayrollOperations_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampainsDetailDeliver_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommitteesCheck_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCommittee_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestMgrDecision_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequestStudy_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScPortalRequests_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCases_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpContracts_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxActions_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxCollect_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmCharityBoxReceive_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TmDamagedCharityBoxs_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseOperationsReplace_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseOperations_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArDrCrHd_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampains_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ScCampainsAid_Audit, L("Audit"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ApDrCrHd
            context.CreatePermission(PermissionNames.Pages_ApDrCrHd, L("ApDrCrHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApDrCrHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApDrCrHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApDrCrHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApDrCrHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApDrCrHd_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion


            #region IvPosHd
            context.CreatePermission(PermissionNames.Pages_IvPosHd, L("IvPosHd"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPosHd_Insert, L("Insert"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPosHd_Update, L("Update"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPosHd_Delete, L("Delete"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_IvPosHd_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);
            //context.CreatePermission(PermissionNames.Pages_IvPosHd_UnPost, L("UnPost"), multiTenancySides: MultiTenancySides.Tenant);
            #endregion

            #region ....
            context.CreatePermission(PermissionNames.Pages_SpCaseOperations, L("SpCaseOperations"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseOperations_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_SpCaseOperationsReplace, L("SpCaseOperationsReplace"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseOperationsReplace_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_spCaseList, L("SpCaseList"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_Sponsoredare18, L("Sponsoredare18"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_ReportsAccounts, L("ReportsAccounts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_GlAccSelection, L("GlAccSelection"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_BudgetPerformance, L("BudgetPerformance"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_TenantAccount, L("TenantAccount"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PropertiesRevenue, L("PropertiesRevenue"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ReportsAids, L("ReportsAids"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_FaAssetList, L("FaAssetList"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SCCasesList, L("SCCasesList"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SecurityDetailsList, L("SecurityDetailsList"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPdcInterfaceReport, L("ApPdcInterfaceReport"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArPdcInterfaceReport, L("ArPdcInterfaceReport"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_ApPrepaid, L("ApPrepaid"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ApPrepaid_Post, L("Post"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_TmCharityBoxList, L("TmCharityBoxList"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_SpCaseReplaceOperationReport, L("SpCaseReplaceOperationReport"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseCancelOperationReport, L("SpCaseCancelOperationReport"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_SpCaseTurnOffOperationReport, L("SpCaseTurnOffOperationReport"), multiTenancySides: MultiTenancySides.Tenant);

            context.CreatePermission(PermissionNames.Pages_EmptyPms, L("EmptyPms"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmContracts, L("PmContracts"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_PmContractNotRenewed, L("PmContractNotRenewed"), multiTenancySides: MultiTenancySides.Tenant);


            context.CreatePermission(PermissionNames.Pages_ReportsSales, L("ReportsSales"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardReport, L("ArJobCard"), multiTenancySides: MultiTenancySides.Tenant);
            context.CreatePermission(PermissionNames.Pages_ArJobCardDetailsReport, L("ArJobCardDetails"), multiTenancySides: MultiTenancySides.Tenant);


            //context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            /*
              var administration = context.CreatePermission("Administration");
              var userManagement = administration.CreateChildPermission("Administration.UserManagement");
              userManagement.CreateChildPermission("Administration.UserManagement.CreateUser");

              var roleManagement = administration.CreateChildPermission("Administration.RoleManagement");
            */
            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ERPConsts.LocalizationSourceName);
        }
    }
}

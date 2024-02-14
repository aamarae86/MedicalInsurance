using ERP.Front.Helpers.Core;

namespace ERP.Front.Helpers.Enums
{
    public class Common
    {
        public static string EncInsert => CipherStringController.Encrypt(FormTriggers.Insert.ToString());
        public static string EncUpdate => CipherStringController.Encrypt(FormTriggers.Update.ToString());
        public static string EncShow => CipherStringController.Encrypt(FormTriggers.Show.ToString());

        public enum FormTriggers
        {
            Insert, Update, Show, Post
        }

        public enum FndLkpsTypes
        {
            AccAttributes, GlJeHeadersStatues, GlJeHeadersReferenceType, BankType, HrPersonVisaDetailsVisaType,
            ArMiscReceiptHeadersSourceCode, ArMiscReceiptHeadersPost, HrPersonsPersonStatues, ScOtherAid,
            ArMiscReceiptHeadersTransType, ArMiscReceiptLinesReceiptType, ApMiscPaymentHeadersType, ScPRMgrDecisionElectronicAidType,
            ApMiscPaymentHeadersSourceCode, ApMiscPaymentHeadersPost, HrPersonsPersonType, GlAccMappingTrDtlType,
            FndAidRequestType, Gender, City, Country, Banks, Nationality, Qualification, MaritalStatus, RelativesType,
            ScCampainsStatues, ScCampainsDetailStatues, ScPortalRequestSource, ScPortalRequestStatues,
            ScPortalRequestVisitedStatues, ScCommityStatues, ScPortalRequestStudyRefuseReason, ScMaintenanceContractStatus,
            PmPropertiesStatues, PmPropertiesCommissionType, PmPropertiesPurpose, HrPersonPassportDetailsPassportType,
            PmPropertiesUnitsUnitType, PmPropertiesUnitsView, PmPropertiesUnitsFinishes, HrPersonVacationsStatues,
            PmOwners, PmOwnersStatues, PmOwnersTaxDetailsType, PmTenantsStatues, PmTenantsPaymentMethod,
            SpecialGender, ArReceiptsStatues, ArReceiptsOnAccountType, ArReceiptsSource, HrPersonsPersonPaymentType,
            TmCharityBoxReceiveStatues, PmContractPost, PmContractPaymentNo, IvReceiveHdReceiveType, TaxVal,
            PmContractUnitType, PmContractPaymentsPaymentType, PmContractPaymentsPaymentSource, HrTitle,
            ArSecurityDepositInterfacePost, ArSecurityDepositInterfaceSource, ApPdcInterfaceReversedReason,
            ArCustomersType, ArCustomersStatues, GlAccounts, CampainsAidCategory, ScComityMembersMemberCategory,
            TmSupervisorsStatus, ApPdcInterfaceStatues, ArDrCrHdStatues, ArDrCrHdType, ArInvoiceHdPost, ScDeliveryOtherAidsStatues,
            ArPdcInterfaceStatues, ScCommitteesCheckStatues, ScPortalRequestMgrDecisionStatues, HrPersonsPersonProbationUnit,
            ScPortalRequestMgrDecisionRefuseReason, ScPortalRequestStudyStatues, PmCancellationContractsPost,
            PmTerminateContractsPost, TmCharityBoxesStatus, ScPortalRequestStudyLkpId, TmCharityBoxActionsStatues,
            TmCharityBoxActionDetailsAction, TmMemberCategory, TmCharityBoxCollectStatus, TmDamagedCharityBoxsStatus,
            HealthStatus, EducationalLevel, EducationalStage, StatusLkpId, IvReceiveHdStatues, HrOrganizationsOrganizationType,
            HousingType, HousingStatus, SponsorCategory, SpContractsStatues, SpCaseOperationsReason, ApVendorsStatues,
            ApVendorsType, ApInvoiceHdStatues, ApInvoiceHdHdType, ApPrepaidStaues, ApPrepaidSource, ApPaymentsTransactionsStatues,
            ApPaymentsTransactionsPaymentType, FirstTitle, LastTitle, PortalUsersCaseCategory, PoPurchaseOrderHdStatues,
            HrPersonVisaDetailsIssuedBy, HrPersonsPersonJobGrade, HrPersonsPersonPersonCategory, Job, HrPersonsPersonPersonSponser,
            HrPersonsPersonTicketClass, IvStoreIssueHdStatues, IvStoreIssueHdBeneficiaryType, IvStoreIssueHdIssueType,
            HrPersonsDeductionStatus, HrDeductionType, FaAssetsAssetTypeLkpId, FaAssetsOwnershipLkpId, FaAssetsBoughtLkpId,
            FaAssetsBookingTypeLkpId, FaAssetsSalvageValueTypeLkpId, FaAssetsDeprenMethodLkpId, FaAssetsStatusLkpId,
            GlJeIntegrationHeadersStatues, GlJeIntegrationHeadersSource, PmUnitDescLkp, ScMaintenanceQuotationStatus, Language,
            ScMaintenanceTechnicalReportStatues, MaintenancePaymentStatus, SpPaymentStatusLkp, Industries, FmEngineersStatues,
            FmMaintRequisitionsHdrStatues, FmMaintRequisitionsHdrComplaintType, FmMaintRequisitionsExeStatues, FmMaintRequisitionsExeExecuteType,
            CrmLeadsPersonsStatues, CrmLeadsPersonsSource, CrmLeadsPersonsindustry, CrmLeadsPersonsRating, CrmLeadsPersonsAccount, CrmLeadsPersonsVendor,
            CrmDealsType, CrmDealsStage, CrmActivitiesActivity, CrmContactActionType, ArJobCardJobType , ArJobCardVehicleEmirate, ArJobCardVehicleMake,
            ArJobCardVehicleModel, ArJobCardVehicleColor, ArJobCardExcessStatus , ArJobCardStatus  , ArInvoiceSettlementDrSource , ArInvoiceSettlementCrSource,
            ArInvoiceSettlementHdStatus, ArJobCardPaymentHdStatus, ArJobCardPaymentTrSource, KpiModules , Kpi, ApDrCrHdStatues, ApDrCrHdType, IvSaleHdStatus, CustomerPaymentTerms,
            IvReturnSaleHdStatus, IvReturnReceiveHdStatus, JobCardPoliceReport


        }

        public enum ArJobCardPaymentHd
        {
            Posted = 11568,
            New = 11567 
        }

        public enum ApDrCrHd
        {
            Posted = 31607,
            New = 31606          
        }

        public enum IvSaleHd
        {
            
            New = 31615,
            Posted = 31614
        }

        public enum IvReturnSaleHd
        {

            New = 31624,
            Posted = 31625
        }
        public enum IvReturnReceiveHd
        {

            New = 31627,
            Posted = 31626
        }

        public enum SpContracts
        {
            New = 691
        }

        public enum TmCharityBoxActionDetailsAction
        {
            New = 619,
            Replace = 620,
            Broken = 621,
            Missed = 622,
            Gain = 623
        }


        public enum TmCharityBoxesStatus
        {
            NotActive = 596,
            Active = 597
        }

        public enum FndBankLkpsTypes
        {
            Bank = 35,
            Box = 36
        }

        public enum FndArPdcInterfaceStatues
        {
            Delivered = 28,
            e = 29,
            f = 30
        }

        public enum FndApPdcInterfaceStatues
        {
            Delivered = 45,
            e = 46,
            f = 47
        }

        public enum ArMiscReceiptHeadersPost
        {
            New = 52,
            Posted = 53
        }

        public enum ArReceiptsPost
        {
            Posted = 279,
            Settled = 11578,
            Canceled = 11120
        }

        public enum ArInvoiceHd
        {
            Posted = 252,
            New = 251
        }

       

        public enum ArReceiptsTypes
        {
            Cheques = 282,
            Cash = 281
        }

        public enum ApMiscPaymentHeadersPost
        {
            Posted = 61
        }

        public enum GlJeHeadersStatues
        {
            Posted = 11
        }

        public enum ScCampains
        {
            Posted = 144
        }

        public enum ScCampainsDetail
        {
            New = 145,
            Posted = 146,
            Delivered = 147
        }

        public enum ScCommitteeDetail
        {
            New = 290,
            Posted = 291,
            Rejected = 292,
            Postponed_to_study = 293
        }

        public enum ScPortalRequests
        {
            New = 149,
            Posted = 150,
            Refused = 151
        }

        public enum ScPortalRequestsSource
        {
            Manual = 152,
            Portal = 153
        }

        public enum ScPortalRequestMgrDecision
        {
            New = 172
        }

        public enum ScCommittee
        {
            New = 156,
            Posted = 157,
            Refused = 171
        }

        public enum ScPortalRequestStudy
        {
            New = 148,
            Committee = 166,
            Manger = 167,
            Posted,
            postponed = 629
        }

        public enum ApMiscPaymentHeadersType
        {
            Cash = 65,
            Check = 66
        }

        public enum BankType
        {
            Bank = 35,
            Box = 36
        }

        public enum ScCommitteesCheckStatues
        {
            Posted = 183
        }

        public enum PmContractPost
        {
            Posted = 230,
            New = 231
        }

        public enum PmContractPaymentsPaymentSource
        {
            Rent = 250,
            Inusurance = 248,
            Tax = 249
        }

        public enum PmContractPaymentsPaymentType
        {
            Check = 247,
            Cash = 246
        }

        public enum ArSecurityDepositInterfacePost
        {
            New = 224,
            Paided = 225,
            Transferred = 287
        }

        public enum PmCancellationContracts
        {
            New = 228
        }

        public enum PmTerminateContracts
        {
            New = 227
        }

        public enum TmCharityBoxReceive
        {
            New = 606,
            Posted = 607
        }

        public enum TmCharityBoxActions
        {
            New = 617,
            Posted = 618
        }

        public enum TmCharityBoxCollectStatus
        {
            New = 633,
            Posted = 632
        }


        public enum TmDamagedCharityBoxs
        {
            New = 637,
            Posted = 640
        }

        public enum SpCaseOperations
        {
            TurnOff = 710,
            Cancel = 711,
            Replace /**/
        }

        public enum ApInvoiceHd
        {
            New = 716,
            Posted = 717
        }

        public enum ApPrepaid
        {
            New = 721,
            Posted = 722,
            VendorInvoices = 723
        }

        public enum ApPaymentsTransactions
        {
            New = 712,
            Posted = 713
        }

        public enum IvReceiveHd
        {
            New = 763,
            Posted = 764
        }

        public enum HrPersonsDeductionHd
        {
            New = 835,
            Posted = 837
        }

        public enum HrPersonVacationsStatues
        {
            New = 842,
            Posted = 843
        }

        public enum ArMiscReceiptLinesReceiptType
        {
            Cash = 58,
            CheQ = 59,
            BankTransfare = 872
        }

        public enum FaAssetDeprnHd
        {
            New = 898,
            Posted = 899
        }

        public enum ScDeliveryOtherAidsStatues
        {
            New = 917,
            Posted = 918
        }

        public enum GlJeIntegrationHeaders
        {
            New = 922,
            Posted = 10977            
        }

        public enum ScMaintenanceTechnicalReport
        {
            New = 940,
            Posted = 941
        }

        public enum ScMaintenanceQuotationStatus
        {
            New = 942,
            Posted = 943
        }

        public enum ScMaintenanceContractStatus
        {
            New = 947,
            Posted = 948
        }

        public enum MaintenancePaymentStatus
        {
            New = 10947,
            Posted = 10948
        }

        public enum SpPayments
        {
            New = 10985,
            Approved = 10986,
            Posted = 10987
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ERP._System._FndLookupValues.Dto
{
    public class FndEnum
    {
        public enum FndLkps
        {
            New_ApMiscPaymentHeadersPost = 60,
            Posted_ApMiscPaymentHeadersPost = 61,

            ApMiscPaymentHeadersSourceCode = 64,

            New_ArMiscReceiptHeadersPost = 52,
            Posted_ArMiscReceiptHeadersPost = 53,

            ArMiscReceiptHeadersSourceCode = 56,

            New_GlJeHeadersStatues = 10,
            Posted_GlJeHeadersStatues = 11,

            Manual_GlJeHeadersReferenceType = 13,

            Opened_GlPeriodsDetailsStatues = 50,
            Pending_GlPeriodsDetailsStatues = 51,

            New_ScCampainsStatues = 143,

            New_ScCampainsDetailStatues = 145,
            Posted_ScCampainsDetailStatues = 146,
            Received_ScCampainsDetailStatues = 147,

            New_ScPortalRequest = 149,

            Manual_ScPortalRequestSource = 152,
            Portal_ScPortalRequestSource = 153,

            New_ScPortalRequestVisited = 154,

            New_ScCommittee = 156,
            Posted_ScCommittee = 157,
            Refused_ScCommittee = 171,

            ScPortalRequestStudy_TransferedToCommittee = 166,

            New_ScPortalRequestStudyStatus = 148,
            Manager_ScPortalRequestStudy = 167,
            Committee_ScPortalRequestStudy = 166,
            Postponed_ScPortalRequestStudy = 629,
            RefuseForUpdateReason_ScPortalRequestStudy = 912,

            New_ScCommitteesCheckStatues = 182,

            Vacant_PmPropertiesUnitsStatues = 205,

            New_PmContractPost = 231,

            Manual_ArCustomersSource = 284,

            New_ArSecurityDepositInterfaceStatus = 224,

            Posted_ScCommitteeDetailsStatus = 291,
            PostponedToStudy_ScCommitteeDetailsStatus = 293,

            New_TmCharityBoxActionsStatues = 617,
            New_TmCharityBoxActionsDetailStatues = 624,

            New_TmCharityBoxActionDetailsAction = 619,
            Replace_TmCharityBoxActionDetailsAction = 620,
            Broken_TmCharityBoxActionDetailsAction = 621,
            Missed_TmCharityBoxActionDetailsAction = 622,
            Gain_TmCharityBoxActionDetailsAction = 623,

            Posted_ScPortalRequestMgrDecision = 173,

            New_TmCharityBoxCollectStatus = 633,

            New_TmDamagedCharityBoxsStatues = 637,
            Posted_TmDamagedCharityBoxsStatues = 640,

            New_SpContract = 691,
            New_ApInvoiceHdStatues = 716,

            New_ApPaymentsTransactions = 712,

            New_IvReceiveHd = 763,

            New_HrPersonsDeductionHd = 835,

            New_HrPersonVacationsStatues = 842,

            New_PyPayrollOperationsStatues = 844,
            New_IvSaleHdStatus= 31615,
            New_IvReturnSaleHdStatus= 31624,

            New_IvReturnReceiveHdStatus = 31627,

            New_HrPersonPermissionStatus = 31635

        }

    }
}

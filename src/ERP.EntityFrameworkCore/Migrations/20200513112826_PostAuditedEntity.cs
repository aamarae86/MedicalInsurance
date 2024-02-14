using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PostAuditedEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "TmDamagedCharityBoxs",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "TmDamagedCharityBoxs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "TmDamagedCharityBoxs",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "TmDamagedCharityBoxs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "TmCharityBoxReceive",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "TmCharityBoxReceive",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "TmCharityBoxReceive",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "TmCharityBoxReceive",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "TmCharityBoxCollect",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "TmCharityBoxCollect",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "TmCharityBoxCollect",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "TmCharityBoxCollect",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "TmCharityBoxActions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "TmCharityBoxActions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "TmCharityBoxActions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "TmCharityBoxActions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "SpContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "SpContracts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "SpContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "SpContracts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "SpCases",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "SpCases",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "SpCases",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "SpCases",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ScPortalRequestStudy",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ScPortalRequestStudy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ScPortalRequestStudy",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ScPortalRequestStudy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ScPortalRequests",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ScPortalRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ScPortalRequests",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ScPortalRequests",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ScPortalRequestMgrDecision",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ScPortalRequestMgrDecision",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ScPortalRequestMgrDecision",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ScPortalRequestMgrDecision",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ScCommitteesCheck",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ScCommitteesCheck",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ScCommitteesCheck",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ScCommitteesCheck",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ScCommittees",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ScCommittees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ScCommittees",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ScCommittees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ScCommitteeDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ScCommitteeDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ScCommitteeDetails",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ScCommitteeDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ScCampainsDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ScCampainsDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ScCampainsDetail",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ScCampainsDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "PyPayrollOperations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "PyPayrollOperations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "PyPayrollOperations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "PyPayrollOperations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "PoPurchaseOrderHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "PoPurchaseOrderHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "PoPurchaseOrderHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "PoPurchaseOrderHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "PmTerminateContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "PmTerminateContracts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "PmTerminateContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "PmTerminateContracts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "PmContract",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "PmContract",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "PmContract",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "PmContract",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "PmCancellationContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "PmCancellationContracts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "PmCancellationContracts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "PmCancellationContracts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "IvStoreIssueHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "IvStoreIssueHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "IvStoreIssueHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "IvStoreIssueHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "IvReceiveHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "IvReceiveHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "IvReceiveHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "IvReceiveHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "IvAdjustmentHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "IvAdjustmentHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "IvAdjustmentHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "IvAdjustmentHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "HrPersonVacations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "HrPersonVacations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "HrPersonVacations",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "HrPersonVacations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "HrPersonsDeductionHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "HrPersonsDeductionHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "HrPersonsDeductionHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "HrPersonsDeductionHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "HrPersonsAdditionHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "HrPersonsAdditionHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "HrPersonsAdditionHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "HrPersonsAdditionHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ArReceipts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ArReceipts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ArReceipts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ArReceipts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ArPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ArMiscReceiptHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ArMiscReceiptHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ArMiscReceiptHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ArMiscReceiptHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ArInvoiceHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ArInvoiceHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ArInvoiceHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ArInvoiceHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ApPrepaid",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ApPrepaid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ApPrepaid",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ApPrepaid",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ApPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ApPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ApPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ApPdcInterface",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ApPaymentsTransactions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ApPaymentsTransactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ApPaymentsTransactions",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ApPaymentsTransactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ApMiscPaymentHeaders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostTime",
                table: "ApInvoiceHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PostUserId",
                table: "ApInvoiceHd",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UnPostTime",
                table: "ApInvoiceHd",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UnPostUserId",
                table: "ApInvoiceHd",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "TmDamagedCharityBoxs");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "TmDamagedCharityBoxs");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "TmDamagedCharityBoxs");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "TmDamagedCharityBoxs");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "TmCharityBoxReceive");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "TmCharityBoxReceive");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "TmCharityBoxReceive");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "TmCharityBoxReceive");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "TmCharityBoxCollect");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "TmCharityBoxCollect");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "TmCharityBoxCollect");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "TmCharityBoxCollect");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "TmCharityBoxActions");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "TmCharityBoxActions");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "TmCharityBoxActions");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "TmCharityBoxActions");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "SpContracts");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "SpContracts");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "SpContracts");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "SpContracts");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ScPortalRequestStudy");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ScPortalRequestMgrDecision");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ScCommitteesCheck");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ScCommitteesCheck");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ScCommitteesCheck");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ScCommitteesCheck");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ScCommittees");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ScCommittees");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ScCommittees");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ScCommittees");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ScCommitteeDetails");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ScCommitteeDetails");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ScCommitteeDetails");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ScCommitteeDetails");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ScCampainsDetail");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ScCampainsDetail");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ScCampainsDetail");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ScCampainsDetail");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "PyPayrollOperations");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "PyPayrollOperations");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "PyPayrollOperations");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "PyPayrollOperations");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "PoPurchaseOrderHd");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "PmTerminateContracts");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "PmTerminateContracts");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "PmTerminateContracts");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "PmTerminateContracts");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "PmContract");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "PmContract");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "PmContract");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "PmContract");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "PmCancellationContracts");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "PmCancellationContracts");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "PmCancellationContracts");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "PmCancellationContracts");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "IvStoreIssueHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "IvStoreIssueHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "IvStoreIssueHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "IvStoreIssueHd");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "IvReceiveHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "IvReceiveHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "IvReceiveHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "IvReceiveHd");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "IvAdjustmentHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "IvAdjustmentHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "IvAdjustmentHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "IvAdjustmentHd");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "HrPersonVacations");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "HrPersonVacations");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "HrPersonVacations");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "HrPersonVacations");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "HrPersonsDeductionHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "HrPersonsDeductionHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "HrPersonsDeductionHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "HrPersonsDeductionHd");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "HrPersonsAdditionHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "HrPersonsAdditionHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "HrPersonsAdditionHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "HrPersonsAdditionHd");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ArReceipts");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ArReceipts");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ArReceipts");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ArReceipts");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ArPdcInterface");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ArMiscReceiptHeaders");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ArInvoiceHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ArInvoiceHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ArInvoiceHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ArInvoiceHd");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ApPrepaid");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ApPrepaid");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ApPrepaid");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ApPrepaid");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ApPaymentsTransactions");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ApPaymentsTransactions");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ApPaymentsTransactions");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ApPaymentsTransactions");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ApMiscPaymentHeaders");

            migrationBuilder.DropColumn(
                name: "PostTime",
                table: "ApInvoiceHd");

            migrationBuilder.DropColumn(
                name: "PostUserId",
                table: "ApInvoiceHd");

            migrationBuilder.DropColumn(
                name: "UnPostTime",
                table: "ApInvoiceHd");

            migrationBuilder.DropColumn(
                name: "UnPostUserId",
                table: "ApInvoiceHd");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_check_constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE ApPrepaid ADD CONSTRAINT CK_ApPrepaid_Amount_Check CHECK (Amount >= 0)"); //ApPrepaid.Amount
            migrationBuilder.Sql("ALTER TABLE ApPdcInterface ADD CONSTRAINT CK_ApPdcInterface_Amount_Check CHECK (Amount >= 0)");//ApPdcInterface.Amount
            migrationBuilder.Sql("ALTER TABLE ApPaymentsTransactions ADD CONSTRAINT CK_ApPaymentsTransactions_Amount_Check CHECK (PaymentAmount >= 0)");//ApPaymentsTransactions.PaymentAmount
            migrationBuilder.Sql("ALTER TABLE ApMiscPaymentLines ADD CONSTRAINT CK_Amount_ApMiscPaymentLinesM_Check CHECK (MiscPaymentAmount >= 0)");//ApMiscPaymentLines.MiscPaymentAmount
            migrationBuilder.Sql("ALTER TABLE ApMiscPaymentLines ADD CONSTRAINT CK_Amount_ApMiscPaymentLines_Check CHECK (TaxPercent >= 0)");//ApMiscPaymentLines.TaxPercent
            migrationBuilder.Sql("ALTER TABLE ApMiscPaymentHeaders ADD CONSTRAINT CK_Amount_ApMiscPaymentHeaders_Check CHECK (Amount >= 0)");//ApMiscPaymentHeaders.Amount
            migrationBuilder.Sql("ALTER TABLE ApMiscPaymentDetails ADD CONSTRAINT CK_ApMiscPaymentHeaders_Amount_Check CHECK (Amount >= 0)");//ApMiscPaymentDetails.Amount
            migrationBuilder.Sql("ALTER TABLE ApInvoiceTr ADD CONSTRAINT CK_ApInvoiceTrT_Amount_Check CHECK (TaxAmount >= 0)");//ApInvoiceTr.TaxAmount
            migrationBuilder.Sql("ALTER TABLE ApInvoiceTr ADD CONSTRAINT CK_ApInvoiceTr_Amount_Check CHECK (Amount >= 0)");//ApInvoiceTr.Amount
            migrationBuilder.Sql("ALTER TABLE HrPersonSalaryElements ADD CONSTRAINT CK_HrPersonSalaryElements_Amount_Check CHECK (Amount >= 0)");//HrPersonSalaryElements.Amount
            migrationBuilder.Sql("ALTER TABLE ArSecurityDepositInterface ADD CONSTRAINT CK_ArSecurityDepositInterface_Amount_Check CHECK (Amount >= 0)");//ArSecurityDepositInterface.Amount
            migrationBuilder.Sql("ALTER TABLE ArReceiptsOnAccount ADD CONSTRAINT CK_ArReceiptsOnAccount_Amount_Check CHECK (Amount >= 0)");//ArReceiptsOnAccount.Amount
            migrationBuilder.Sql("ALTER TABLE ArReceiptDetails ADD CONSTRAINT CK_ArReceiptDetails_Amount_Check CHECK (Amount >= 0)");//ArReceiptDetails.Amount
         
            migrationBuilder.Sql("ALTER TABLE ArPdcInterface ADD CONSTRAINT CK_ArPdcInterface_Amount_Check CHECK (Amount >= 0)");//ArPdcInterface.Amount
            migrationBuilder.Sql("ALTER TABLE ArMiscReceiptLines ADD CONSTRAINT CK_ArMiscReceiptLines_Amount_Check CHECK (MiscReceiptAmount >= 0)");//ArMiscReceiptLines.MiscReceiptAmount

            migrationBuilder.Sql("ALTER TABLE ArMiscReceiptLines ADD CONSTRAINT CK_ArMiscReceiptLinesA_Amount_Check CHECK (AdministrativePercent >= 0)");//ArMiscReceiptLines.AdministrativePercent
            migrationBuilder.Sql("ALTER TABLE ArMiscReceiptDetails ADD CONSTRAINT CK_ArMiscReceiptDetails_Amount_Check CHECK (Amount >= 0)");//ArMiscReceiptDetails.Amount
            
            migrationBuilder.Sql("ALTER TABLE ArMiscReceiptHeaders ADD CONSTRAINT CK_ArMiscReceiptHeaders_Amount_Check CHECK (Amount >= 0)");//ArMiscReceiptHeaders.Amount
            migrationBuilder.Sql("ALTER TABLE ArInvoiceTr WITH NOCHECK ADD CONSTRAINT CK_ArInvoiceTr_Amount_Check CHECK (Amount >= 0)");//ArInvoiceTr.Amount

            migrationBuilder.Sql("ALTER TABLE ArDrCrTr ADD CONSTRAINT CK_ArDrCrTr_Amount_Check CHECK (Amount >= 0)");//ArDrCrTr.Amount
            migrationBuilder.Sql("ALTER TABLE GlJeIntegrationLines ADD CONSTRAINT CK_GlJeIntegrationLinesC_Amount_Check CHECK (CreditAmount >= 0)");//GlJeIntegrationLines.CreditAmount

            migrationBuilder.Sql("ALTER TABLE GlJeIntegrationLines ADD CONSTRAINT CK_GlJeIntegrationLinesD_Amount_Check CHECK (DebitAmount >= 0)");//GlJeIntegrationLines.DebitAmount
            migrationBuilder.Sql("ALTER TABLE GlJeLines WITH NOCHECK ADD CONSTRAINT CK_GlJeLinesC_Amount_Check CHECK (CreditAmount >= 0)");//GlJeLines.CreditAmount
            migrationBuilder.Sql("ALTER TABLE GlJeLines ADD CONSTRAINT CK_GlJeLinesD_Amount_Check CHECK (DebitAmount >= 0)");//GlJeLines.DebitAmount
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class updateCRMContact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_AccountLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_VendorLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropIndex(
                name: "IX_CrmLeadsPersons_AccountLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropIndex(
                name: "IX_CrmLeadsPersons_VendorLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "AccountLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "VendorLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                table: "CrmLeadsPersons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "VendorName",
                table: "CrmLeadsPersons");

            migrationBuilder.AddColumn<long>(
                name: "AccountLkpId",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VendorLkpId",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_AccountLkpId",
                table: "CrmLeadsPersons",
                column: "AccountLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_VendorLkpId",
                table: "CrmLeadsPersons",
                column: "VendorLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_AccountLkpId",
                table: "CrmLeadsPersons",
                column: "AccountLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_VendorLkpId",
                table: "CrmLeadsPersons",
                column: "VendorLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

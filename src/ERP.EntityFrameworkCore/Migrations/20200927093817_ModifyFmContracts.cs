using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ModifyFmContracts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdvAccountCode",
                table: "FmContracts",
                newName: "AdvAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountCode",
                table: "FmContracts",
                newName: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FmContracts_AccountId",
                table: "FmContracts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FmContracts_AdvAccountId",
                table: "FmContracts",
                column: "AdvAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_FmContracts_VendorId",
                table: "FmContracts",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_FmContracts_GlCodeComDetails_AccountId",
                table: "FmContracts",
                column: "AccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FmContracts_GlCodeComDetails_AdvAccountId",
                table: "FmContracts",
                column: "AdvAccountId",
                principalTable: "GlCodeComDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_FmContracts_ApVendors_VendorId",
                table: "FmContracts",
                column: "VendorId",
                principalTable: "ApVendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FmContracts_GlCodeComDetails_AccountId",
                table: "FmContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_FmContracts_GlCodeComDetails_AdvAccountId",
                table: "FmContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_FmContracts_ApVendors_VendorId",
                table: "FmContracts");

            migrationBuilder.DropIndex(
                name: "IX_FmContracts_AccountId",
                table: "FmContracts");

            migrationBuilder.DropIndex(
                name: "IX_FmContracts_AdvAccountId",
                table: "FmContracts");

            migrationBuilder.DropIndex(
                name: "IX_FmContracts_VendorId",
                table: "FmContracts");

            migrationBuilder.RenameColumn(
                name: "AdvAccountId",
                table: "FmContracts",
                newName: "AdvAccountCode");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "FmContracts",
                newName: "AccountCode");
        }
    }
}

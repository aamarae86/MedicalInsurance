using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ApVendorsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApVendors_FndLookupValues_StatusLkpId",
                table: "ApVendors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ApVendors");

            migrationBuilder.AlterColumn<string>(
                name: "VendorNumber",
                table: "ApVendors",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "ApVendors",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ApVendors_FndLookupValues_StatusLkpId",
                table: "ApVendors",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApVendors_FndLookupValues_StatusLkpId",
                table: "ApVendors");

            migrationBuilder.AlterColumn<string>(
                name: "VendorNumber",
                table: "ApVendors",
                type: "nvarchar(20)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "ApVendors",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ApVendors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ApVendors_FndLookupValues_StatusLkpId",
                table: "ApVendors",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPmProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmProperties_FndLookupValues_CityLkpId",
                table: "PmProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PmProperties_FndLookupValues_CommissionTypeLkpId",
                table: "PmProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PmProperties_FndLookupValues_CountryLkpId",
                table: "PmProperties");

            migrationBuilder.AlterColumn<long>(
                name: "CountryLkpId",
                table: "PmProperties",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CommissionTypeLkpId",
                table: "PmProperties",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "CommissionPercentage",
                table: "PmProperties",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<long>(
                name: "CityLkpId",
                table: "PmProperties",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_PmProperties_FndLookupValues_CityLkpId",
                table: "PmProperties",
                column: "CityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmProperties_FndLookupValues_CommissionTypeLkpId",
                table: "PmProperties",
                column: "CommissionTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmProperties_FndLookupValues_CountryLkpId",
                table: "PmProperties",
                column: "CountryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmProperties_FndLookupValues_CityLkpId",
                table: "PmProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PmProperties_FndLookupValues_CommissionTypeLkpId",
                table: "PmProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PmProperties_FndLookupValues_CountryLkpId",
                table: "PmProperties");

            migrationBuilder.AlterColumn<long>(
                name: "CountryLkpId",
                table: "PmProperties",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CommissionTypeLkpId",
                table: "PmProperties",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "CommissionPercentage",
                table: "PmProperties",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CityLkpId",
                table: "PmProperties",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PmProperties_FndLookupValues_CityLkpId",
                table: "PmProperties",
                column: "CityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmProperties_FndLookupValues_CommissionTypeLkpId",
                table: "PmProperties",
                column: "CommissionTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmProperties_FndLookupValues_CountryLkpId",
                table: "PmProperties",
                column: "CountryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

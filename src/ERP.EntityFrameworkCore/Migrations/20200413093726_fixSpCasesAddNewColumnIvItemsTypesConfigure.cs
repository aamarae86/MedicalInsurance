using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fixSpCasesAddNewColumnIvItemsTypesConfigure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_SpFamilies_SpFamilyId",
                table: "SpCases");

            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_FndLookupValues_SponsorCategoryLkpId",
                table: "SpCases");

            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_FndLookupValues_StatusLkpId",
                table: "SpCases");

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "SpCases",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SponsorCategoryLkpId",
                table: "SpCases",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "SpFamilyId",
                table: "SpCases",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CaseName",
                table: "SpCases",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfigureCode",
                table: "IvItemsTypesConfigure",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_SpFamilies_SpFamilyId",
                table: "SpCases",
                column: "SpFamilyId",
                principalTable: "SpFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_FndLookupValues_SponsorCategoryLkpId",
                table: "SpCases",
                column: "SponsorCategoryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_FndLookupValues_StatusLkpId",
                table: "SpCases",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_SpFamilies_SpFamilyId",
                table: "SpCases");

            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_FndLookupValues_SponsorCategoryLkpId",
                table: "SpCases");

            migrationBuilder.DropForeignKey(
                name: "FK_SpCases_FndLookupValues_StatusLkpId",
                table: "SpCases");

            migrationBuilder.DropColumn(
                name: "ConfigureCode",
                table: "IvItemsTypesConfigure");

            migrationBuilder.AlterColumn<long>(
                name: "StatusLkpId",
                table: "SpCases",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "SponsorCategoryLkpId",
                table: "SpCases",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "SpFamilyId",
                table: "SpCases",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "CaseName",
                table: "SpCases",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_SpFamilies_SpFamilyId",
                table: "SpCases",
                column: "SpFamilyId",
                principalTable: "SpFamilies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_FndLookupValues_SponsorCategoryLkpId",
                table: "SpCases",
                column: "SponsorCategoryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_SpCases_FndLookupValues_StatusLkpId",
                table: "SpCases",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

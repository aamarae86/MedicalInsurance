using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class SpBeneficents_nullable_firstTitle_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_FirstTitleLkpId",
                table: "SpBeneficent");

            migrationBuilder.AlterColumn<long>(
                name: "FirstTitleLkpId",
                table: "SpBeneficent",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_FirstTitleLkpId",
                table: "SpBeneficent",
                column: "FirstTitleLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_FirstTitleLkpId",
                table: "SpBeneficent");

            migrationBuilder.AlterColumn<long>(
                name: "FirstTitleLkpId",
                table: "SpBeneficent",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_FirstTitleLkpId",
                table: "SpBeneficent",
                column: "FirstTitleLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

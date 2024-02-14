using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class test1234234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_StatusLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropIndex(
                name: "IX_SpBeneficent_StatusLkpId",
                table: "SpBeneficent"
                );

            migrationBuilder.DropColumn(
                name: "StatusLkpId",
                table: "SpBeneficent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusLkpId",
                table: "SpBeneficent",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_StatusLkpId",
                table: "SpBeneficent",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

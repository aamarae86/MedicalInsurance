using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fixSpCaseHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCaseHistory_SpBeneficent_BeneficentId",
                table: "SpCaseHistory");

            migrationBuilder.AlterColumn<long>(
                name: "BeneficentId",
                table: "SpCaseHistory",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_SpCaseHistory_SpBeneficent_BeneficentId",
                table: "SpCaseHistory",
                column: "BeneficentId",
                principalTable: "SpBeneficent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpCaseHistory_SpBeneficent_BeneficentId",
                table: "SpCaseHistory");

            migrationBuilder.AlterColumn<long>(
                name: "BeneficentId",
                table: "SpCaseHistory",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpCaseHistory_SpBeneficent_BeneficentId",
                table: "SpCaseHistory",
                column: "BeneficentId",
                principalTable: "SpBeneficent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

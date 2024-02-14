using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Add_Statusrcolumn_HrpersonPermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "StatusLkpId",
                table: "HrPersonPermission",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_HrPersonPermission_StatusLkpId",
                table: "HrPersonPermission",
                column: "StatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_HrPersonPermission_FndLookupValues_StatusLkpId",
                table: "HrPersonPermission",
                column: "StatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HrPersonPermission_FndLookupValues_StatusLkpId",
                table: "HrPersonPermission");

            migrationBuilder.DropIndex(
                name: "IX_HrPersonPermission_StatusLkpId",
                table: "HrPersonPermission");

            migrationBuilder.DropColumn(
                name: "StatusLkpId",
                table: "HrPersonPermission");
        }
    }
}

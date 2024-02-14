using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class remove_Required_Field_in_ScPortalRequests_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScPortalRequests_FndLookupValues_HealthstatusLkpId",
                table: "ScPortalRequests");

            migrationBuilder.DropIndex(
                name: "IX_ScPortalRequests_HealthstatusLkpId",
                table: "ScPortalRequests");

            migrationBuilder.DropColumn(
                name: "HealthstatusLkpId",
                table: "ScPortalRequests");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "ScPortalRequests",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "ScPortalRequests",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "HealthstatusLkpId",
                table: "ScPortalRequests",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ScPortalRequests_HealthstatusLkpId",
                table: "ScPortalRequests",
                column: "HealthstatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScPortalRequests_FndLookupValues_HealthstatusLkpId",
                table: "ScPortalRequests",
                column: "HealthstatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

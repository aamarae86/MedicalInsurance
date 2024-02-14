using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class fixPmPropertiesUnitsAttachments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmPropertiesUnitsAttachments_PmPropertiesUnits_PmPropertiesUnitsId",
                table: "PmPropertiesUnitsAttachments");

            migrationBuilder.DropIndex(
                name: "IX_PmPropertiesUnitsAttachments_PmPropertiesUnitsId",
                table: "PmPropertiesUnitsAttachments");

            migrationBuilder.DropColumn(
                name: "PmPropertiesUnitsId",
                table: "PmPropertiesUnitsAttachments");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "ScPortalRequestAttachments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesUnitsAttachments_PmPropertiesUnitstId",
                table: "PmPropertiesUnitsAttachments",
                column: "PmPropertiesUnitstId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmPropertiesUnitsAttachments_PmPropertiesUnits_PmPropertiesUnitstId",
                table: "PmPropertiesUnitsAttachments",
                column: "PmPropertiesUnitstId",
                principalTable: "PmPropertiesUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmPropertiesUnitsAttachments_PmPropertiesUnits_PmPropertiesUnitstId",
                table: "PmPropertiesUnitsAttachments");

            migrationBuilder.DropIndex(
                name: "IX_PmPropertiesUnitsAttachments_PmPropertiesUnitstId",
                table: "PmPropertiesUnitsAttachments");

            migrationBuilder.AlterColumn<string>(
                name: "FilePath",
                table: "ScPortalRequestAttachments",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "PmPropertiesUnitsId",
                table: "PmPropertiesUnitsAttachments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PmPropertiesUnitsAttachments_PmPropertiesUnitsId",
                table: "PmPropertiesUnitsAttachments",
                column: "PmPropertiesUnitsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmPropertiesUnitsAttachments_PmPropertiesUnits_PmPropertiesUnitsId",
                table: "PmPropertiesUnitsAttachments",
                column: "PmPropertiesUnitsId",
                principalTable: "PmPropertiesUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

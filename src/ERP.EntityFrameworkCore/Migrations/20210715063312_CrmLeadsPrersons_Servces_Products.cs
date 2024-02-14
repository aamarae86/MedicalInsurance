using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class CrmLeadsPrersons_Servces_Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CrmProductId",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CrmServiceId",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_CrmProductId",
                table: "CrmLeadsPersons",
                column: "CrmProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_CrmServiceId",
                table: "CrmLeadsPersons",
                column: "CrmServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_CrmProducts_CrmProductId",
                table: "CrmLeadsPersons",
                column: "CrmProductId",
                principalTable: "CrmProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_CrmServices_CrmServiceId",
                table: "CrmLeadsPersons",
                column: "CrmServiceId",
                principalTable: "CrmServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_CrmProducts_CrmProductId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_CrmServices_CrmServiceId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropIndex(
                name: "IX_CrmLeadsPersons_CrmProductId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropIndex(
                name: "IX_CrmLeadsPersons_CrmServiceId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "CrmProductId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "CrmServiceId",
                table: "CrmLeadsPersons");
        }
    }
}

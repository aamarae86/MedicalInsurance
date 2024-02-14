using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ExtendCRMLEAD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TypeLkpId",
                table: "CrmLeadsPersons",
                nullable: true,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_TypeLkpId",
                table: "CrmLeadsPersons",
                column: "TypeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_TypeLkpId",
                table: "CrmLeadsPersons",
                column: "TypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_TypeLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropIndex(
                name: "IX_CrmLeadsPersons_TypeLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "TypeLkpId",
                table: "CrmLeadsPersons");
        }
    }
}

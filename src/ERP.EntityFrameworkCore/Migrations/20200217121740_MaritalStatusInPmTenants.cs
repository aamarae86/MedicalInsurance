using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class MaritalStatusInPmTenants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PmTenants_MaritalStatusLkpId",
                table: "PmTenants",
                column: "MaritalStatusLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PmTenants_FndLookupValues_MaritalStatusLkpId",
                table: "PmTenants",
                column: "MaritalStatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmTenants_FndLookupValues_MaritalStatusLkpId",
                table: "PmTenants");

            migrationBuilder.DropIndex(
                name: "IX_PmTenants_MaritalStatusLkpId",
                table: "PmTenants");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Remove_ReceiveTypeLkpId_IvReceiveHd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IvReceiveHd_FndLookupValues_ReceiveTypeLkpId",
                table: "IvReceiveHd");

            migrationBuilder.DropIndex(
                name: "IX_IvReceiveHd_ReceiveTypeLkpId",
                table: "IvReceiveHd");

            migrationBuilder.DropColumn(
                name: "ReceiveTypeLkpId",
                table: "IvReceiveHd");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ReceiveTypeLkpId",
                table: "IvReceiveHd",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_IvReceiveHd_ReceiveTypeLkpId",
                table: "IvReceiveHd",
                column: "ReceiveTypeLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_IvReceiveHd_FndLookupValues_ReceiveTypeLkpId",
                table: "IvReceiveHd",
                column: "ReceiveTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

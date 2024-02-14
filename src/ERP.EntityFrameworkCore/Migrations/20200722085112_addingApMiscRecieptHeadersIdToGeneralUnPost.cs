using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addingApMiscRecieptHeadersIdToGeneralUnPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "GeneralUnPost");

            migrationBuilder.AddColumn<long>(
                name: "ApMiscPaymentHeadersId",
                table: "GeneralUnPost",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GeneralUnPost_ApMiscPaymentHeadersId",
                table: "GeneralUnPost",
                column: "ApMiscPaymentHeadersId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralUnPost_ApMiscPaymentHeaders_ApMiscPaymentHeadersId",
                table: "GeneralUnPost",
                column: "ApMiscPaymentHeadersId",
                principalTable: "ApMiscPaymentHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralUnPost_ApMiscPaymentHeaders_ApMiscPaymentHeadersId",
                table: "GeneralUnPost");

            migrationBuilder.DropIndex(
                name: "IX_GeneralUnPost_ApMiscPaymentHeadersId",
                table: "GeneralUnPost");

            migrationBuilder.DropColumn(
                name: "ApMiscPaymentHeadersId",
                table: "GeneralUnPost");

            migrationBuilder.AddColumn<long>(
                name: "SourceId",
                table: "GeneralUnPost",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

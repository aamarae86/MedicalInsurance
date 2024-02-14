using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class newFieldsForTmCharityBoxesNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TmCharityBoxes_TmCharityBoxReceive_TmCharityBoxReceiveId",
                table: "TmCharityBoxes");

            migrationBuilder.AlterColumn<long>(
                name: "TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "InternalCounterPerType",
                table: "TmCharityBoxes",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TmCharityBoxes_TmCharityBoxReceive_TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                column: "TmCharityBoxReceiveId",
                principalTable: "TmCharityBoxReceive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TmCharityBoxes_TmCharityBoxReceive_TmCharityBoxReceiveId",
                table: "TmCharityBoxes");

            migrationBuilder.AlterColumn<long>(
                name: "TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "InternalCounterPerType",
                table: "TmCharityBoxes",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_TmCharityBoxes_TmCharityBoxReceive_TmCharityBoxReceiveId",
                table: "TmCharityBoxes",
                column: "TmCharityBoxReceiveId",
                principalTable: "TmCharityBoxReceive",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

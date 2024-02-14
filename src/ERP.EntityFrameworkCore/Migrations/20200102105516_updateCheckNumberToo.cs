using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class updateCheckNumberToo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CheckNumber",
                table: "ApPdcInterface",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceNumber",
                table: "ApPdcInterface",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VendorId",
                table: "ApPdcInterface",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SourceNumber",
                table: "ApPdcInterface");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "ApPdcInterface");

            migrationBuilder.AlterColumn<long>(
                name: "CheckNumber",
                table: "ApPdcInterface",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}

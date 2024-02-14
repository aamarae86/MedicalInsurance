using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class FaAssetBoolNotLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsAmortizeAdjustment",
                table: "FaAssets",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "IsAmortizeAdjustment",
                table: "FaAssets",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}

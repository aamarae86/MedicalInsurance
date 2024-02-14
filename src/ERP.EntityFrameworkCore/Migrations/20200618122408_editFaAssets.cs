using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editFaAssets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAmortizeAdjustment",
                table: "FaAssets");

            migrationBuilder.DropColumn(
                name: "RecoverableCost",
                table: "FaAssets");

            migrationBuilder.DropColumn(
                name: "RevaluationCeiling",
                table: "FaAssets");

            migrationBuilder.DropColumn(
                name: "RevaluationReserve",
                table: "FaAssets");

            migrationBuilder.DropColumn(
                name: "YtdProceeds",
                table: "FaAssets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAmortizeAdjustment",
                table: "FaAssets",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RecoverableCost",
                table: "FaAssets",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RevaluationCeiling",
                table: "FaAssets",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RevaluationReserve",
                table: "FaAssets",
                type: "decimal(18,6)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "YtdProceeds",
                table: "FaAssets",
                type: "decimal(18,6)",
                nullable: true);
        }
    }
}

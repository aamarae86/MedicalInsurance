using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class addnewcolumnsCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AndNameAr",
                table: "Currencies",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AndNameEn",
                table: "Currencies",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastWordAr",
                table: "Currencies",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastWordEn",
                table: "Currencies",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainCurrencyNameAr",
                table: "Currencies",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainCurrencyNameEn",
                table: "Currencies",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCurrencyNameAr",
                table: "Currencies",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCurrencyNameEn",
                table: "Currencies",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AndNameAr",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "AndNameEn",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LastWordAr",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "LastWordEn",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "MainCurrencyNameAr",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "MainCurrencyNameEn",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "SubCurrencyNameAr",
                table: "Currencies");

            migrationBuilder.DropColumn(
                name: "SubCurrencyNameEn",
                table: "Currencies");
        }
    }
}

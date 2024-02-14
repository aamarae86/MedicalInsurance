using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class ArJobCardPaymentHdTr_AddCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
                table: "ArJobCardHd");

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArJobCardPaymentTr",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TenxMigrationId",
                table: "ArJobCardPaymentHd",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VehicleEmirateLkpId",
                table: "ArJobCardHd",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
                table: "ArJobCardHd",
                column: "VehicleEmirateLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
                table: "ArJobCardHd");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArJobCardPaymentTr");

            migrationBuilder.DropColumn(
                name: "TenxMigrationId",
                table: "ArJobCardPaymentHd");

            migrationBuilder.AlterColumn<long>(
                name: "VehicleEmirateLkpId",
                table: "ArJobCardHd",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ArJobCardHd_FndLookupValues_VehicleEmirateLkpId",
                table: "ArJobCardHd",
                column: "VehicleEmirateLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class pmeditpropsunits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmPropertiesUnits_FndLookupValues_FinishesLkpId",
                table: "PmPropertiesUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_PmPropertiesUnits_FndLookupValues_ViewLkpId",
                table: "PmPropertiesUnits");

            migrationBuilder.AlterColumn<long>(
                name: "ViewLkpId",
                table: "PmPropertiesUnits",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "FloorLevel",
                table: "PmPropertiesUnits",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "FinishesLkpId",
                table: "PmPropertiesUnits",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<decimal>(
                name: "AreaSize",
                table: "PmPropertiesUnits",
                type: "decimal(18, 6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AddForeignKey(
                name: "FK_PmPropertiesUnits_FndLookupValues_FinishesLkpId",
                table: "PmPropertiesUnits",
                column: "FinishesLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PmPropertiesUnits_FndLookupValues_ViewLkpId",
                table: "PmPropertiesUnits",
                column: "ViewLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PmPropertiesUnits_FndLookupValues_FinishesLkpId",
                table: "PmPropertiesUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_PmPropertiesUnits_FndLookupValues_ViewLkpId",
                table: "PmPropertiesUnits");

            migrationBuilder.AlterColumn<long>(
                name: "ViewLkpId",
                table: "PmPropertiesUnits",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FloorLevel",
                table: "PmPropertiesUnits",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FinishesLkpId",
                table: "PmPropertiesUnits",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "AreaSize",
                table: "PmPropertiesUnits",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PmPropertiesUnits_FndLookupValues_FinishesLkpId",
                table: "PmPropertiesUnits",
                column: "FinishesLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PmPropertiesUnits_FndLookupValues_ViewLkpId",
                table: "PmPropertiesUnits",
                column: "ViewLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

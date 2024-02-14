using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class Update_GlJeLinesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlJeLines_FndLookupValues_JeDtlSourceLkpId",
                table: "GlJeLines");

            migrationBuilder.AlterColumn<long>(
                name: "JeSourceId",
                table: "GlJeLines",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "JeDtlSourceLkpId",
                table: "GlJeLines",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_GlJeLines_FndLookupValues_JeDtlSourceLkpId",
                table: "GlJeLines",
                column: "JeDtlSourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GlJeLines_FndLookupValues_JeDtlSourceLkpId",
                table: "GlJeLines");

            migrationBuilder.AlterColumn<long>(
                name: "JeSourceId",
                table: "GlJeLines",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "JeDtlSourceLkpId",
                table: "GlJeLines",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GlJeLines_FndLookupValues_JeDtlSourceLkpId",
                table: "GlJeLines",
                column: "JeDtlSourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

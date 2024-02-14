using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class editPortalRelatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_NationalityLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_QualificationLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_RelativesTypeLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.AlterColumn<long>(
                name: "RelativesTypeLkpId",
                table: "PortalUserRelatives",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "QualificationLkpId",
                table: "PortalUserRelatives",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "NationalityLkpId",
                table: "PortalUserRelatives",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_NationalityLkpId",
                table: "PortalUserRelatives",
                column: "NationalityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_QualificationLkpId",
                table: "PortalUserRelatives",
                column: "QualificationLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_RelativesTypeLkpId",
                table: "PortalUserRelatives",
                column: "RelativesTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_NationalityLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_QualificationLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_RelativesTypeLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.AlterColumn<long>(
                name: "RelativesTypeLkpId",
                table: "PortalUserRelatives",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "QualificationLkpId",
                table: "PortalUserRelatives",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NationalityLkpId",
                table: "PortalUserRelatives",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_NationalityLkpId",
                table: "PortalUserRelatives",
                column: "NationalityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_QualificationLkpId",
                table: "PortalUserRelatives",
                column: "QualificationLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_RelativesTypeLkpId",
                table: "PortalUserRelatives",
                column: "RelativesTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

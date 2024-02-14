using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class updateCRMLead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_CountryLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_IndustryLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_LeadSourceLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_LeadStatusIdLkp",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_RatingLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "CrmLeadsPersons",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<long>(
                name: "RatingLkpId",
                table: "CrmLeadsPersons",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "NoOfEmployees",
                table: "CrmLeadsPersons",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "LeadStatusIdLkp",
                table: "CrmLeadsPersons",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "LeadSourceLkpId",
                table: "CrmLeadsPersons",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "IndustryLkpId",
                table: "CrmLeadsPersons",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CountryLkpId",
                table: "CrmLeadsPersons",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_CountryLkpId",
                table: "CrmLeadsPersons",
                column: "CountryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_IndustryLkpId",
                table: "CrmLeadsPersons",
                column: "IndustryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_LeadSourceLkpId",
                table: "CrmLeadsPersons",
                column: "LeadSourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_LeadStatusIdLkp",
                table: "CrmLeadsPersons",
                column: "LeadStatusIdLkp",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_RatingLkpId",
                table: "CrmLeadsPersons",
                column: "RatingLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_CountryLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_IndustryLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_LeadSourceLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_LeadStatusIdLkp",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_RatingLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "CrmLeadsPersons",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RatingLkpId",
                table: "CrmLeadsPersons",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NoOfEmployees",
                table: "CrmLeadsPersons",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LeadStatusIdLkp",
                table: "CrmLeadsPersons",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "LeadSourceLkpId",
                table: "CrmLeadsPersons",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "IndustryLkpId",
                table: "CrmLeadsPersons",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CountryLkpId",
                table: "CrmLeadsPersons",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_CountryLkpId",
                table: "CrmLeadsPersons",
                column: "CountryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_IndustryLkpId",
                table: "CrmLeadsPersons",
                column: "IndustryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_LeadSourceLkpId",
                table: "CrmLeadsPersons",
                column: "LeadSourceLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_LeadStatusIdLkp",
                table: "CrmLeadsPersons",
                column: "LeadStatusIdLkp",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_RatingLkpId",
                table: "CrmLeadsPersons",
                column: "RatingLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

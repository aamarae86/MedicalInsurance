using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class extLeads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_TypeLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.AlterColumn<long>(
                name: "TypeLkpId",
                table: "CrmLeadsPersons",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "AccountLkpId",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Assistant",
                table: "CrmLeadsPersons",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssistantPhone",
                table: "CrmLeadsPersons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "CrmLeadsPersons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone",
                table: "CrmLeadsPersons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherCity",
                table: "CrmLeadsPersons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OtherCountryLkpId",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherPhone",
                table: "CrmLeadsPersons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherState",
                table: "CrmLeadsPersons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherStreet",
                table: "CrmLeadsPersons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherZipCode",
                table: "CrmLeadsPersons",
                maxLength: 30,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "VendorLkpId",
                table: "CrmLeadsPersons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_AccountLkpId",
                table: "CrmLeadsPersons",
                column: "AccountLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_OtherCountryLkpId",
                table: "CrmLeadsPersons",
                column: "OtherCountryLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_CrmLeadsPersons_VendorLkpId",
                table: "CrmLeadsPersons",
                column: "VendorLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_AccountLkpId",
                table: "CrmLeadsPersons",
                column: "AccountLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_OtherCountryLkpId",
                table: "CrmLeadsPersons",
                column: "OtherCountryLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_TypeLkpId",
                table: "CrmLeadsPersons",
                column: "TypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_VendorLkpId",
                table: "CrmLeadsPersons",
                column: "VendorLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_AccountLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_OtherCountryLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_TypeLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_VendorLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropIndex(
                name: "IX_CrmLeadsPersons_AccountLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropIndex(
                name: "IX_CrmLeadsPersons_OtherCountryLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropIndex(
                name: "IX_CrmLeadsPersons_VendorLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "AccountLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "Assistant",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "AssistantPhone",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "HomePhone",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "OtherCity",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "OtherCountryLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "OtherPhone",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "OtherState",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "OtherStreet",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "OtherZipCode",
                table: "CrmLeadsPersons");

            migrationBuilder.DropColumn(
                name: "VendorLkpId",
                table: "CrmLeadsPersons");

            migrationBuilder.AlterColumn<long>(
                name: "TypeLkpId",
                table: "CrmLeadsPersons",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CrmLeadsPersons_FndLookupValues_TypeLkpId",
                table: "CrmLeadsPersons",
                column: "TypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

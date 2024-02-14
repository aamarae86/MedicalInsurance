using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class SpBeneficents_nullable_firstTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BeneficentNameEN",
                table: "SpBeneficent",
                newName: "BeneficentNameEn");

            migrationBuilder.AlterColumn<string>(
                name: "BeneficentNumber",
                table: "SpBeneficent",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "BeneficentNameEn",
                table: "SpBeneficent",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "BeneficentNameAr",
                table: "SpBeneficent",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "SpBeneficent",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CityLkpId",
                table: "SpBeneficent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "SpBeneficent",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fax",
                table: "SpBeneficent",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FirstTitleLkpId",
                table: "SpBeneficent",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GenderLkpId",
                table: "SpBeneficent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "SpBeneficent",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobDescription",
                table: "SpBeneficent",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastTitleLkpId",
                table: "SpBeneficent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber1",
                table: "SpBeneficent",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber2",
                table: "SpBeneficent",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NationalityLkpId",
                table: "SpBeneficent",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoBox",
                table: "SpBeneficent",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpBeneficentAttachments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SpBeneficentId = table.Column<long>(nullable: false),
                    AttachmentName = table.Column<string>(maxLength: 200, nullable: false),
                    FilePath = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpBeneficentAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpBeneficentAttachments_SpBeneficent_SpBeneficentId",
                        column: x => x.SpBeneficentId,
                        principalTable: "SpBeneficent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpBeneficentBanks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
                    SpBeneficentId = table.Column<long>(nullable: false),
                    BankLkpId = table.Column<long>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 50, nullable: false),
                    AccountOwnerName = table.Column<string>(maxLength: 200, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpBeneficentBanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpBeneficentBanks_FndLookupValues_BankLkpId",
                        column: x => x.BankLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpBeneficentBanks_SpBeneficent_SpBeneficentId",
                        column: x => x.SpBeneficentId,
                        principalTable: "SpBeneficent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficent_CityLkpId",
                table: "SpBeneficent",
                column: "CityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficent_FirstTitleLkpId",
                table: "SpBeneficent",
                column: "FirstTitleLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficent_GenderLkpId",
                table: "SpBeneficent",
                column: "GenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficent_LastTitleLkpId",
                table: "SpBeneficent",
                column: "LastTitleLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficent_NationalityLkpId",
                table: "SpBeneficent",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficentAttachments_SpBeneficentId",
                table: "SpBeneficentAttachments",
                column: "SpBeneficentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficentBanks_BankLkpId",
                table: "SpBeneficentBanks",
                column: "BankLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_SpBeneficentBanks_SpBeneficentId",
                table: "SpBeneficentBanks",
                column: "SpBeneficentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_CityLkpId",
                table: "SpBeneficent",
                column: "CityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_FirstTitleLkpId",
                table: "SpBeneficent",
                column: "FirstTitleLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_GenderLkpId",
                table: "SpBeneficent",
                column: "GenderLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_LastTitleLkpId",
                table: "SpBeneficent",
                column: "LastTitleLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_NationalityLkpId",
                table: "SpBeneficent",
                column: "NationalityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_CityLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_FirstTitleLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_GenderLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_LastTitleLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropForeignKey(
                name: "FK_SpBeneficent_FndLookupValues_NationalityLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropTable(
                name: "SpBeneficentAttachments");

            migrationBuilder.DropTable(
                name: "SpBeneficentBanks");

            migrationBuilder.DropIndex(
                name: "IX_SpBeneficent_CityLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropIndex(
                name: "IX_SpBeneficent_FirstTitleLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropIndex(
                name: "IX_SpBeneficent_GenderLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropIndex(
                name: "IX_SpBeneficent_LastTitleLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropIndex(
                name: "IX_SpBeneficent_NationalityLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "CityLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "Fax",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "FirstTitleLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "GenderLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "Job",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "JobDescription",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "LastTitleLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "MobileNumber1",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "MobileNumber2",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "NationalityLkpId",
                table: "SpBeneficent");

            migrationBuilder.DropColumn(
                name: "PoBox",
                table: "SpBeneficent");

            migrationBuilder.RenameColumn(
                name: "BeneficentNameEn",
                table: "SpBeneficent",
                newName: "BeneficentNameEN");

            migrationBuilder.AlterColumn<string>(
                name: "BeneficentNumber",
                table: "SpBeneficent",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "BeneficentNameEN",
                table: "SpBeneficent",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "BeneficentNameAr",
                table: "SpBeneficent",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);
        }
    }
}

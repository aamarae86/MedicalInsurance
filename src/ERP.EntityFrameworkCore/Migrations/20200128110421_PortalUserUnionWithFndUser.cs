using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class PortalUserUnionWithFndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_PortalUserRelatives_FndLookupValues_CampainsAidCategoryLkpId",
            //    table: "PortalUserRelatives");

            //migrationBuilder.DropIndex(
            //    name: "IX_PortalUserRelatives_CampainsAidCategoryLkpId",
            //    table: "PortalUserRelatives");

            //migrationBuilder.DropColumn(
            //    name: "AidAmount",
            //    table: "PortalUserRelatives");

            //migrationBuilder.DropColumn(
            //    name: "AidName",
            //    table: "PortalUserRelatives");

            //migrationBuilder.DropColumn(
            //    name: "CampainsAidCategoryLkpId",
            //    table: "PortalUserRelatives");

            //migrationBuilder.DropColumn(
            //    name: "IsActive",
            //    table: "PortalUserRelatives");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "PortalUsers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MaritalStatusLkpId",
                table: "PortalUsers",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "QualificationLkpId",
                table: "PortalUsers",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "ScCampainsAid",
            //    columns: table => new
            //    {
            //        Id = table.Column<long>(nullable: false)
            //            .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
            //        CreationTime = table.Column<DateTime>(nullable: false),
            //        CreatorUserId = table.Column<long>(nullable: true),
            //        LastModificationTime = table.Column<DateTime>(nullable: true),
            //        LastModifierUserId = table.Column<long>(nullable: true),
            //        CampainsAidCategoryLkpId = table.Column<long>(nullable: false),
            //        AidName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
            //        AidAmount = table.Column<decimal>(type: "decimal(18, 6)", nullable: false),
            //        IsActive = table.Column<bool>(nullable: false),
            //        TenantId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ScCampainsAid", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_ScCampainsAid_FndLookupValues_CampainsAidCategoryLkpId",
            //            column: x => x.CampainsAidCategoryLkpId,
            //            principalTable: "FndLookupValues",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_PortalUsers_CityLkpId",
                table: "PortalUsers",
                column: "CityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUsers_GenderLkpId",
                table: "PortalUsers",
                column: "GenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUsers_MaritalStatusLkpId",
                table: "PortalUsers",
                column: "MaritalStatusLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUsers_NationalityLkpId",
                table: "PortalUsers",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUsers_QualificationLkpId",
                table: "PortalUsers",
                column: "QualificationLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserRelatives_GenderLkpId",
                table: "PortalUserRelatives",
                column: "GenderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserRelatives_NationalityLkpId",
                table: "PortalUserRelatives",
                column: "NationalityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserRelatives_QualificationLkpId",
                table: "PortalUserRelatives",
                column: "QualificationLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_PortalUserRelatives_RelativesTypeLkpId",
                table: "PortalUserRelatives",
                column: "RelativesTypeLkpId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_ScCampainsAid_CampainsAidCategoryLkpId",
            //    table: "ScCampainsAid",
            //    column: "CampainsAidCategoryLkpId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_GenderLkpId",
                table: "PortalUserRelatives",
                column: "GenderLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_NationalityLkpId",
                table: "PortalUserRelatives",
                column: "NationalityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_QualificationLkpId",
                table: "PortalUserRelatives",
                column: "QualificationLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_RelativesTypeLkpId",
                table: "PortalUserRelatives",
                column: "RelativesTypeLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_FndLookupValues_CityLkpId",
                table: "PortalUsers",
                column: "CityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_FndLookupValues_GenderLkpId",
                table: "PortalUsers",
                column: "GenderLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_FndLookupValues_MaritalStatusLkpId",
                table: "PortalUsers",
                column: "MaritalStatusLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_FndLookupValues_NationalityLkpId",
                table: "PortalUsers",
                column: "NationalityLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PortalUsers_FndLookupValues_QualificationLkpId",
                table: "PortalUsers",
                column: "QualificationLkpId",
                principalTable: "FndLookupValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_GenderLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_NationalityLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_QualificationLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUserRelatives_FndLookupValues_RelativesTypeLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_FndLookupValues_CityLkpId",
                table: "PortalUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_FndLookupValues_GenderLkpId",
                table: "PortalUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_FndLookupValues_MaritalStatusLkpId",
                table: "PortalUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_FndLookupValues_NationalityLkpId",
                table: "PortalUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PortalUsers_FndLookupValues_QualificationLkpId",
                table: "PortalUsers");

            //migrationBuilder.DropTable(
            //    name: "ScCampainsAid");

            migrationBuilder.DropIndex(
                name: "IX_PortalUsers_CityLkpId",
                table: "PortalUsers");

            migrationBuilder.DropIndex(
                name: "IX_PortalUsers_GenderLkpId",
                table: "PortalUsers");

            migrationBuilder.DropIndex(
                name: "IX_PortalUsers_MaritalStatusLkpId",
                table: "PortalUsers");

            migrationBuilder.DropIndex(
                name: "IX_PortalUsers_NationalityLkpId",
                table: "PortalUsers");

            migrationBuilder.DropIndex(
                name: "IX_PortalUsers_QualificationLkpId",
                table: "PortalUsers");

            migrationBuilder.DropIndex(
                name: "IX_PortalUserRelatives_GenderLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropIndex(
                name: "IX_PortalUserRelatives_NationalityLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropIndex(
                name: "IX_PortalUserRelatives_QualificationLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropIndex(
                name: "IX_PortalUserRelatives_RelativesTypeLkpId",
                table: "PortalUserRelatives");

            migrationBuilder.DropColumn(
                name: "MaritalStatusLkpId",
                table: "PortalUsers");

            migrationBuilder.DropColumn(
                name: "QualificationLkpId",
                table: "PortalUsers");

            migrationBuilder.AlterColumn<string>(
                name: "IdNumber",
                table: "PortalUsers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            //migrationBuilder.AddColumn<decimal>(
            //    name: "AidAmount",
            //    table: "PortalUserRelatives",
            //    type: "decimal(18, 6)",
            //    nullable: false,
            //    defaultValue: 0m);

            //migrationBuilder.AddColumn<string>(
            //    name: "AidName",
            //    table: "PortalUserRelatives",
            //    type: "nvarchar(200)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<long>(
            //    name: "CampainsAidCategoryLkpId",
            //    table: "PortalUserRelatives",
            //    nullable: false,
            //    defaultValue: 0L);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsActive",
            //    table: "PortalUserRelatives",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.CreateIndex(
            //    name: "IX_PortalUserRelatives_CampainsAidCategoryLkpId",
            //    table: "PortalUserRelatives",
            //    column: "CampainsAidCategoryLkpId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_PortalUserRelatives_FndLookupValues_CampainsAidCategoryLkpId",
            //    table: "PortalUserRelatives",
            //    column: "CampainsAidCategoryLkpId",
            //    principalTable: "FndLookupValues",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}

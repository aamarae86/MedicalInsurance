using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddActivCall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityCall",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    PostUserId = table.Column<long>(nullable: true),
                    PostTime = table.Column<DateTime>(nullable: true),
                    UnPostUserId = table.Column<long>(nullable: true),
                    UnPostTime = table.Column<DateTime>(nullable: true),
                    RelatedToLkpId = table.Column<long>(nullable: false),
                    CrmLeadsPersonsId = table.Column<long>(nullable: false),
                    Subject = table.Column<string>(maxLength: 200, nullable: true),
                    CallPurposeLkpId = table.Column<long>(nullable: false),
                    CallTypeLkpId = table.Column<long>(nullable: false),
                    CallDetailsLkpId = table.Column<long>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    CallResultLkpId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityCall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityCall_FndLookupValues_CallDetailsLkpId",
                        column: x => x.CallDetailsLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActivityCall_FndLookupValues_CallPurposeLkpId",
                        column: x => x.CallPurposeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActivityCall_FndLookupValues_CallResultLkpId",
                        column: x => x.CallResultLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActivityCall_FndLookupValues_CallTypeLkpId",
                        column: x => x.CallTypeLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActivityCall_CrmLeadsPersons_CrmLeadsPersonsId",
                        column: x => x.CrmLeadsPersonsId,
                        principalTable: "CrmLeadsPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityCall_FndLookupValues_RelatedToLkpId",
                        column: x => x.RelatedToLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCall_CallDetailsLkpId",
                table: "ActivityCall",
                column: "CallDetailsLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCall_CallPurposeLkpId",
                table: "ActivityCall",
                column: "CallPurposeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCall_CallResultLkpId",
                table: "ActivityCall",
                column: "CallResultLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCall_CallTypeLkpId",
                table: "ActivityCall",
                column: "CallTypeLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCall_CrmLeadsPersonsId",
                table: "ActivityCall",
                column: "CrmLeadsPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCall_RelatedToLkpId",
                table: "ActivityCall",
                column: "RelatedToLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityCall");
        }
    }
}

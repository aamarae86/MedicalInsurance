using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddActivitytask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTasks",
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
                    StatuesLkpId = table.Column<long>(nullable: false),
                    PriorityLkpId = table.Column<long>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    ReminderDate = table.Column<DateTime>(nullable: false),
                    ReminderTime = table.Column<DateTime>(nullable: false),
                    Reminder = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityTasks_CrmLeadsPersons_CrmLeadsPersonsId",
                        column: x => x.CrmLeadsPersonsId,
                        principalTable: "CrmLeadsPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityTasks_FndLookupValues_PriorityLkpId",
                        column: x => x.PriorityLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActivityTasks_FndLookupValues_RelatedToLkpId",
                        column: x => x.RelatedToLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActivityTasks_FndLookupValues_StatuesLkpId",
                        column: x => x.StatuesLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTasks_CrmLeadsPersonsId",
                table: "ActivityTasks",
                column: "CrmLeadsPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTasks_PriorityLkpId",
                table: "ActivityTasks",
                column: "PriorityLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTasks_RelatedToLkpId",
                table: "ActivityTasks",
                column: "RelatedToLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTasks_StatuesLkpId",
                table: "ActivityTasks",
                column: "StatuesLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityTasks");
        }
    }
}

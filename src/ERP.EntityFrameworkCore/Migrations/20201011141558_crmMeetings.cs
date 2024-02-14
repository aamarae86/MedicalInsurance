using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class crmMeetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityMeeting",
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
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    Location = table.Column<string>(maxLength: 200, nullable: true),
                    AllDay = table.Column<bool>(nullable: false),
                    FromDay = table.Column<DateTime>(nullable: false),
                    FromTime = table.Column<DateTime>(nullable: false),
                    ToDay = table.Column<DateTime>(nullable: false),
                    ToTime = table.Column<DateTime>(nullable: false),
                    RelatedToLkpId = table.Column<long>(nullable: false),
                    CrmLeadsPersonsId = table.Column<long>(nullable: false),
                    PartiReminderLkpId = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 4000, nullable: true),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityMeeting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityMeeting_CrmLeadsPersons_CrmLeadsPersonsId",
                        column: x => x.CrmLeadsPersonsId,
                        principalTable: "CrmLeadsPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityMeeting_FndLookupValues_PartiReminderLkpId",
                        column: x => x.PartiReminderLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActivityMeeting_FndLookupValues_RelatedToLkpId",
                        column: x => x.RelatedToLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ActivityMeetingParticipant",
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
                    ActivityMeetingId = table.Column<long>(nullable: false),
                    RelatedToLkpId = table.Column<long>(nullable: false),
                    CrmLeadsPersonsId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityMeetingParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityMeetingParticipant_ActivityMeeting_ActivityMeetingId",
                        column: x => x.ActivityMeetingId,
                        principalTable: "ActivityMeeting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityMeetingParticipant_CrmLeadsPersons_CrmLeadsPersonsId",
                        column: x => x.CrmLeadsPersonsId,
                        principalTable: "CrmLeadsPersons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ActivityMeetingParticipant_FndLookupValues_RelatedToLkpId",
                        column: x => x.RelatedToLkpId,
                        principalTable: "FndLookupValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMeeting_CrmLeadsPersonsId",
                table: "ActivityMeeting",
                column: "CrmLeadsPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMeeting_PartiReminderLkpId",
                table: "ActivityMeeting",
                column: "PartiReminderLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMeeting_RelatedToLkpId",
                table: "ActivityMeeting",
                column: "RelatedToLkpId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMeetingParticipant_ActivityMeetingId",
                table: "ActivityMeetingParticipant",
                column: "ActivityMeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMeetingParticipant_CrmLeadsPersonsId",
                table: "ActivityMeetingParticipant",
                column: "CrmLeadsPersonsId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMeetingParticipant_RelatedToLkpId",
                table: "ActivityMeetingParticipant",
                column: "RelatedToLkpId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityMeetingParticipant");

            migrationBuilder.DropTable(
                name: "ActivityMeeting");
        }
    }
}

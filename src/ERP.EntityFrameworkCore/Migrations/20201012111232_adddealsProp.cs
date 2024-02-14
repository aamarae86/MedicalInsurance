using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class adddealsProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CrmDealsId",
                table: "ActivityTasks",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CrmDealsId",
                table: "ActivityMeeting",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CrmDealsId",
                table: "ActivityCall",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTasks_CrmDealsId",
                table: "ActivityTasks",
                column: "CrmDealsId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMeeting_CrmDealsId",
                table: "ActivityMeeting",
                column: "CrmDealsId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCall_CrmDealsId",
                table: "ActivityCall",
                column: "CrmDealsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityCall_CrmDeals_CrmDealsId",
                table: "ActivityCall",
                column: "CrmDealsId",
                principalTable: "CrmDeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityMeeting_CrmDeals_CrmDealsId",
                table: "ActivityMeeting",
                column: "CrmDealsId",
                principalTable: "CrmDeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityTasks_CrmDeals_CrmDealsId",
                table: "ActivityTasks",
                column: "CrmDealsId",
                principalTable: "CrmDeals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityCall_CrmDeals_CrmDealsId",
                table: "ActivityCall");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityMeeting_CrmDeals_CrmDealsId",
                table: "ActivityMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityTasks_CrmDeals_CrmDealsId",
                table: "ActivityTasks");

            migrationBuilder.DropIndex(
                name: "IX_ActivityTasks_CrmDealsId",
                table: "ActivityTasks");

            migrationBuilder.DropIndex(
                name: "IX_ActivityMeeting_CrmDealsId",
                table: "ActivityMeeting");

            migrationBuilder.DropIndex(
                name: "IX_ActivityCall_CrmDealsId",
                table: "ActivityCall");

            migrationBuilder.DropColumn(
                name: "CrmDealsId",
                table: "ActivityTasks");

            migrationBuilder.DropColumn(
                name: "CrmDealsId",
                table: "ActivityMeeting");

            migrationBuilder.DropColumn(
                name: "CrmDealsId",
                table: "ActivityCall");
        }
    }
}

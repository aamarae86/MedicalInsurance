using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations
{
    public partial class AddAbpTenants_MobilenoColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "AbpTenants",
                maxLength: 100,
                nullable: true);
                        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "AbpTenants");
           
        }
    }
}

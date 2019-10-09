using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yibi.Repositories.MySql.SGroupMigrations
{
    public partial class SGroupMigrations002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ResourceGroupAccount",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedDate",
                table: "ResourceGroupAccount",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ResourceGroupAccount");

            migrationBuilder.DropColumn(
                name: "LastUpdatedDate",
                table: "ResourceGroupAccount");
        }
    }
}

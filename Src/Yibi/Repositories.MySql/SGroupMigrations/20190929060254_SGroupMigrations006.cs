using Microsoft.EntityFrameworkCore.Migrations;

namespace Yibi.Repositories.MySql.SGroupMigrations
{
    public partial class SGroupMigrations006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MessageTemplates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MessageTemplates");
        }
    }
}

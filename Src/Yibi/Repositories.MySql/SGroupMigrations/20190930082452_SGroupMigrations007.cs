using Microsoft.EntityFrameworkCore.Migrations;

namespace Yibi.Repositories.MySql.SGroupMigrations
{
    public partial class SGroupMigrations007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TemplateIds",
                table: "Contacts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TemplateIds",
                table: "Contacts");
        }
    }
}

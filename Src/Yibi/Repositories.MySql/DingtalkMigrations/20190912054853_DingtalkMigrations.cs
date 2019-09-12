using Microsoft.EntityFrameworkCore.Migrations;

namespace Yibi.Repositories.MySql.DingtalkMigrations
{
    public partial class DingtalkMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    StaffNumber = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DepmtId = table.Column<string>(nullable: true),
                    DepmtName = table.Column<string>(nullable: true),
                    IsLeader = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Id",
                table: "Staff",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}

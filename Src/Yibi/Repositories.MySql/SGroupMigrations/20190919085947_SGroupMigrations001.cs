using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yibi.Repositories.MySql.SGroupMigrations
{
    public partial class SGroupMigrations001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceGroupAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Environment = table.Column<string>(nullable: true),
                    TypeName = table.Column<string>(nullable: true),
                    EntryPoint = table.Column<string>(nullable: true),
                    AccountPassword = table.Column<string>(nullable: true),
                    AllowUsers = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceGroupAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeNames",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeNames", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceGroupAccount_Id",
                table: "ResourceGroupAccount",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TypeNames_Id",
                table: "TypeNames",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResourceGroupAccount");

            migrationBuilder.DropTable(
                name: "TypeNames");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yibi.Repositories.MySql.SGroupMigrations
{
    public partial class SGroupMigrations008 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMessageNotices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false),
                    DingtalkUserId = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    EmailContent = table.Column<string>(nullable: true),
                    SmsContent = table.Column<string>(nullable: true),
                    DingtalkContent = table.Column<string>(nullable: true),
                    IsSendDingtalk = table.Column<bool>(nullable: false),
                    IsSendEmail = table.Column<bool>(nullable: false),
                    IsSendSms = table.Column<bool>(nullable: false),
                    IsFinish = table.Column<bool>(nullable: false),
                    TotalOperation = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessageNotices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactMessageNotices_ContactId",
                table: "ContactMessageNotices",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactMessageNotices_Id",
                table: "ContactMessageNotices",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMessageNotices");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TM.Infrastracture.Efcore.Migrations
{
    public partial class chnageUserIdToUsername : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "messages");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "tickets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "messages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "tickets");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "messages");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}

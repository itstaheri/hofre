using Microsoft.EntityFrameworkCore.Migrations;

namespace AM.Infrastracture.Efcore.Migrations
{
    public partial class BuildArticleComment2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "articleComments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "articleComments");
        }
    }
}

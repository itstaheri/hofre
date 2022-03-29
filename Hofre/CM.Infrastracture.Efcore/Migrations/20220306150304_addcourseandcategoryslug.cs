using Microsoft.EntityFrameworkCore.Migrations;

namespace CM.Infrastracture.Efcore.Migrations
{
    public partial class addcourseandcategoryslug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "courses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "courseCategories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "courseCategories");
        }
    }
}

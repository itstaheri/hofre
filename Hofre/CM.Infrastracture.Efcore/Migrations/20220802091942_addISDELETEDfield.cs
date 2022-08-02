using Microsoft.EntityFrameworkCore.Migrations;

namespace CM.Infrastracture.Efcore.Migrations
{
    public partial class addISDELETEDfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "courses");
        }
    }
}

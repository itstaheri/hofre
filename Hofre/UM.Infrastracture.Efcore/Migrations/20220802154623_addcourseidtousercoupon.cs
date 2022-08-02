using Microsoft.EntityFrameworkCore.Migrations;

namespace UM.Infrastracture.Efcore.Migrations
{
    public partial class addcourseidtousercoupon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseId",
                table: "UserCouponModel",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "UserCouponModel");
        }
    }
}

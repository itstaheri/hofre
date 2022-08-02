using Microsoft.EntityFrameworkCore.Migrations;

namespace UM.Infrastracture.Efcore.Migrations
{
    public partial class setproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCouponModel_users_UserId",
                table: "UserCouponModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCouponModel",
                table: "UserCouponModel");

            migrationBuilder.RenameTable(
                name: "UserCouponModel",
                newName: "userCoupons");

            migrationBuilder.RenameIndex(
                name: "IX_UserCouponModel_UserId",
                table: "userCoupons",
                newName: "IX_userCoupons_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCoupons",
                table: "userCoupons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userCoupons_users_UserId",
                table: "userCoupons",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCoupons_users_UserId",
                table: "userCoupons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userCoupons",
                table: "userCoupons");

            migrationBuilder.RenameTable(
                name: "userCoupons",
                newName: "UserCouponModel");

            migrationBuilder.RenameIndex(
                name: "IX_userCoupons_UserId",
                table: "UserCouponModel",
                newName: "IX_UserCouponModel_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCouponModel",
                table: "UserCouponModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCouponModel_users_UserId",
                table: "UserCouponModel",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

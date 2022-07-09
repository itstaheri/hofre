using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OM.Infrastracture.Efcore.Migrations
{
    public partial class removeorderdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ordersDetail");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "orders");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Isfinaly",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "Isfinaly",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ordersDetail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordersDetail_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ordersDetail_OrderId",
                table: "ordersDetail",
                column: "OrderId");
        }
    }
}

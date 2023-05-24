using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DriverOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Order",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DriverId",
                table: "Order",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Driver_DriverId",
                table: "Order",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Driver_DriverId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DriverId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Order");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DriverUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_DriversId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DriversId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DriversId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "DriverId",
                table: "Orders",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriverId",
                table: "Orders",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_DriverId",
                table: "Orders",
                column: "DriverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_DriverId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DriverId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriversId",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriversId",
                table: "Orders",
                column: "DriversId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_DriversId",
                table: "Orders",
                column: "DriversId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

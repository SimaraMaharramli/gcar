using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class changesOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_AppUserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Driver_DriverId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Location_LocationId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_SubLocation_SubLocationId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Driver",
                table: "Driver");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Driver",
                newName: "Drivers");

            migrationBuilder.RenameIndex(
                name: "IX_Order_SubLocationId",
                table: "Orders",
                newName: "IX_Orders_SubLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_LocationId",
                table: "Orders",
                newName: "IX_Orders_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DriverId",
                table: "Orders",
                newName: "IX_Orders_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AppUserId",
                table: "Orders",
                newName: "IX_Orders_AppUserId");

            migrationBuilder.AlterColumn<bool>(
                name: "SoftDelete",
                table: "Orders",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "SoftDelete",
                table: "Drivers",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserId",
                table: "Orders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Drivers_DriverId",
                table: "Orders",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Location_LocationId",
                table: "Orders",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SubLocation_SubLocationId",
                table: "Orders",
                column: "SubLocationId",
                principalTable: "SubLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_AppUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Drivers_DriverId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Location_LocationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SubLocation_SubLocationId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "Driver");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_SubLocationId",
                table: "Order",
                newName: "IX_Order_SubLocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_LocationId",
                table: "Order",
                newName: "IX_Order_LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DriverId",
                table: "Order",
                newName: "IX_Order_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AppUserId",
                table: "Order",
                newName: "IX_Order_AppUserId");

            migrationBuilder.AlterColumn<bool>(
                name: "SoftDelete",
                table: "Order",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<bool>(
                name: "SoftDelete",
                table: "Driver",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Driver",
                table: "Driver",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_AppUserId",
                table: "Order",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Driver_DriverId",
                table: "Order",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Location_LocationId",
                table: "Order",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_SubLocation_SubLocationId",
                table: "Order",
                column: "SubLocationId",
                principalTable: "SubLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class OrderTableUpdateDestinationColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DestinationId",
                table: "Orders",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Location_DestinationId",
                table: "Orders",
                column: "DestinationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Location_DestinationId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DestinationId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Orders");
        }
    }
}

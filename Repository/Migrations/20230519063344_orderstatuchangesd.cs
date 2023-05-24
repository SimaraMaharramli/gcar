using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repository.Migrations
{
    public partial class orderstatuchangesd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderStatus_Status_StatusId",
                table: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_OrderStatus_StatusId",
                table: "OrderStatus");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "OrderStatus",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PickupLocation",
                table: "Order",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "PickupLocation",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    SoftDelete = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatus_StatusId",
                table: "OrderStatus",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderStatus_Status_StatusId",
                table: "OrderStatus",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDesk.Infrastructure.Migrations
{
    public partial class AddGeometryToDesk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Desks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "Desks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XCoordinate",
                table: "Desks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YCoordinate",
                table: "Desks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "XCoordinate",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "YCoordinate",
                table: "Desks");
        }
    }
}

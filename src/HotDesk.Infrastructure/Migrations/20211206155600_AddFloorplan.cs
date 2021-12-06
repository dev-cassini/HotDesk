using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDesk.Infrastructure.Migrations
{
    public partial class AddFloorplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_LocationDepartments_LocationDepartmentId",
                table: "Desks");

            migrationBuilder.RenameColumn(
                name: "LocationDepartmentId",
                table: "Desks",
                newName: "FloorplanId");

            migrationBuilder.RenameIndex(
                name: "IX_Desks_LocationDepartmentId",
                table: "Desks",
                newName: "IX_Desks_FloorplanId");

            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Desks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Floorplan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastUpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floorplan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Floorplan_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desks_DepartmentId",
                table: "Desks",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Floorplan_LocationId",
                table: "Floorplan",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Floorplan_Name",
                table: "Floorplan",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_Departments_DepartmentId",
                table: "Desks",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_Floorplan_FloorplanId",
                table: "Desks",
                column: "FloorplanId",
                principalTable: "Floorplan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desks_Departments_DepartmentId",
                table: "Desks");

            migrationBuilder.DropForeignKey(
                name: "FK_Desks_Floorplan_FloorplanId",
                table: "Desks");

            migrationBuilder.DropTable(
                name: "Floorplan");

            migrationBuilder.DropIndex(
                name: "IX_Desks_DepartmentId",
                table: "Desks");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Desks");

            migrationBuilder.RenameColumn(
                name: "FloorplanId",
                table: "Desks",
                newName: "LocationDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Desks_FloorplanId",
                table: "Desks",
                newName: "IX_Desks_LocationDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desks_LocationDepartments_LocationDepartmentId",
                table: "Desks",
                column: "LocationDepartmentId",
                principalTable: "LocationDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

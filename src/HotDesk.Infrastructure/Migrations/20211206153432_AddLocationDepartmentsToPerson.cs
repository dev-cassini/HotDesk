using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotDesk.Infrastructure.Migrations
{
    public partial class AddLocationDepartmentsToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonLocationDeparmentMappings",
                columns: table => new
                {
                    LocationDepartmentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLocationDeparmentMappings", x => new { x.LocationDepartmentsId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_PersonLocationDeparmentMappings_LocationDepartments_LocationDepartmentsId",
                        column: x => x.LocationDepartmentsId,
                        principalTable: "LocationDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLocationDeparmentMappings_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonLocationDeparmentMappings_PersonsId",
                table: "PersonLocationDeparmentMappings",
                column: "PersonsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLocationDeparmentMappings");
        }
    }
}

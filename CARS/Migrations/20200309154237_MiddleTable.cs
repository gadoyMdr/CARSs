using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CARS.Migrations
{
    public partial class MiddleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehiculeType_Steps_StepId",
                table: "VehiculeType");

            migrationBuilder.DropIndex(
                name: "IX_VehiculeType_StepId",
                table: "VehiculeType");

            migrationBuilder.DropColumn(
                name: "StepId",
                table: "VehiculeType");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "TechnicalControls",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TechnicalControls",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StepVehiculeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculeTypeId = table.Column<int>(nullable: false),
                    StepId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StepVehiculeType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StepVehiculeType_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StepVehiculeType_VehiculeType_VehiculeTypeId",
                        column: x => x.VehiculeTypeId,
                        principalTable: "VehiculeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StepVehiculeType_StepId",
                table: "StepVehiculeType",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_StepVehiculeType_VehiculeTypeId",
                table: "StepVehiculeType",
                column: "VehiculeTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StepVehiculeType");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "TechnicalControls");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TechnicalControls");

            migrationBuilder.AddColumn<int>(
                name: "StepId",
                table: "VehiculeType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehiculeType_StepId",
                table: "VehiculeType",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehiculeType_Steps_StepId",
                table: "VehiculeType",
                column: "StepId",
                principalTable: "Steps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

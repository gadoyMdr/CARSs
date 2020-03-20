using Microsoft.EntityFrameworkCore.Migrations;

namespace CARS.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalControls_Cars_IdCar",
                table: "TechnicalControls");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalControls_IdCar",
                table: "TechnicalControls");

            migrationBuilder.DropColumn(
                name: "IdCar",
                table: "TechnicalControls");

            migrationBuilder.AddColumn<int>(
                name: "IdVehicule",
                table: "TechnicalControls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehiculeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    StepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiculeType_Steps_StepId",
                        column: x => x.StepId,
                        principalTable: "Steps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    VehiculeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicules_VehiculeType_VehiculeTypeId",
                        column: x => x.VehiculeTypeId,
                        principalTable: "VehiculeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalControls_IdVehicule",
                table: "TechnicalControls",
                column: "IdVehicule");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicules_VehiculeTypeId",
                table: "Vehicules",
                column: "VehiculeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiculeType_StepId",
                table: "VehiculeType",
                column: "StepId");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalControls_Vehicules_IdVehicule",
                table: "TechnicalControls",
                column: "IdVehicule",
                principalTable: "Vehicules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalControls_Vehicules_IdVehicule",
                table: "TechnicalControls");

            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "VehiculeType");

            migrationBuilder.DropIndex(
                name: "IX_TechnicalControls_IdVehicule",
                table: "TechnicalControls");

            migrationBuilder.DropColumn(
                name: "IdVehicule",
                table: "TechnicalControls");

            migrationBuilder.AddColumn<int>(
                name: "IdCar",
                table: "TechnicalControls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalControls_IdCar",
                table: "TechnicalControls",
                column: "IdCar");

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalControls_Cars_IdCar",
                table: "TechnicalControls",
                column: "IdCar",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

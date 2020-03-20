using Microsoft.EntityFrameworkCore.Migrations;

namespace CARS.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCar = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalControls_Cars_IdCar",
                        column: x => x.IdCar,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Steps",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCompleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Part = table.Column<string>(nullable: false),
                    TechnicalControlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_TechnicalControls_TechnicalControlId",
                        column: x => x.TechnicalControlId,
                        principalTable: "TechnicalControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TechnicalControlId",
                table: "Steps",
                column: "TechnicalControlId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalControls_IdCar",
                table: "TechnicalControls",
                column: "IdCar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "TechnicalControls");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}

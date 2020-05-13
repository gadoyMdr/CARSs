using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CARS.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehiculeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiculeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    VehiculeTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModel_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModel_VehiculeType_VehiculeTypeId",
                        column: x => x.VehiculeTypeId,
                        principalTable: "VehiculeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalControl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    IdModel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalControl_CarModel_IdModel",
                        column: x => x.IdModel,
                        principalTable: "CarModel",
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
                    Observations = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    TechnicalControlId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Steps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Steps_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Steps_TechnicalControl_TechnicalControlId",
                        column: x => x.TechnicalControlId,
                        principalTable: "TechnicalControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_CarModel_BrandId",
                table: "CarModel",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModel_VehiculeTypeId",
                table: "CarModel",
                column: "VehiculeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_CategoryId",
                table: "Steps",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Steps_TechnicalControlId",
                table: "Steps",
                column: "TechnicalControlId");

            migrationBuilder.CreateIndex(
                name: "IX_StepVehiculeType_StepId",
                table: "StepVehiculeType",
                column: "StepId");

            migrationBuilder.CreateIndex(
                name: "IX_StepVehiculeType_VehiculeTypeId",
                table: "StepVehiculeType",
                column: "VehiculeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalControl_IdModel",
                table: "TechnicalControl",
                column: "IdModel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StepVehiculeType");

            migrationBuilder.DropTable(
                name: "Steps");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "TechnicalControl");

            migrationBuilder.DropTable(
                name: "CarModel");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "VehiculeType");
        }
    }
}

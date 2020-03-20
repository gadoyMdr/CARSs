using Microsoft.EntityFrameworkCore.Migrations;

namespace CARS.Migrations
{
    public partial class removedRequiredFieldsInSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_TechnicalControls_TechnicalControlId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalControls_Vehicules_IdVehicule",
                table: "TechnicalControls");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicules_VehiculeType_VehiculeTypeId",
                table: "Vehicules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicules",
                table: "Vehicules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicalControls",
                table: "TechnicalControls");

            migrationBuilder.RenameTable(
                name: "Vehicules",
                newName: "Vehicule");

            migrationBuilder.RenameTable(
                name: "TechnicalControls",
                newName: "TechnicalControl");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicules_VehiculeTypeId",
                table: "Vehicule",
                newName: "IX_Vehicule_VehiculeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicalControls_IdVehicule",
                table: "TechnicalControl",
                newName: "IX_TechnicalControl_IdVehicule");

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "Steps",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicule",
                table: "Vehicule",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicalControl",
                table: "TechnicalControl",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_TechnicalControl_TechnicalControlId",
                table: "Steps",
                column: "TechnicalControlId",
                principalTable: "TechnicalControl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalControl_Vehicule_IdVehicule",
                table: "TechnicalControl",
                column: "IdVehicule",
                principalTable: "Vehicule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicule_VehiculeType_VehiculeTypeId",
                table: "Vehicule",
                column: "VehiculeTypeId",
                principalTable: "VehiculeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_TechnicalControl_TechnicalControlId",
                table: "Steps");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicalControl_Vehicule_IdVehicule",
                table: "TechnicalControl");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicule_VehiculeType_VehiculeTypeId",
                table: "Vehicule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicule",
                table: "Vehicule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TechnicalControl",
                table: "TechnicalControl");

            migrationBuilder.RenameTable(
                name: "Vehicule",
                newName: "Vehicules");

            migrationBuilder.RenameTable(
                name: "TechnicalControl",
                newName: "TechnicalControls");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicule_VehiculeTypeId",
                table: "Vehicules",
                newName: "IX_Vehicules_VehiculeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_TechnicalControl_IdVehicule",
                table: "TechnicalControls",
                newName: "IX_TechnicalControls_IdVehicule");

            migrationBuilder.AlterColumn<string>(
                name: "Observations",
                table: "Steps",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicules",
                table: "Vehicules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TechnicalControls",
                table: "TechnicalControls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_TechnicalControls_TechnicalControlId",
                table: "Steps",
                column: "TechnicalControlId",
                principalTable: "TechnicalControls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicalControls_Vehicules_IdVehicule",
                table: "TechnicalControls",
                column: "IdVehicule",
                principalTable: "Vehicules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicules_VehiculeType_VehiculeTypeId",
                table: "Vehicules",
                column: "VehiculeTypeId",
                principalTable: "VehiculeType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

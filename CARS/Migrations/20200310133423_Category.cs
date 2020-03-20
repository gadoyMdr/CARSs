using Microsoft.EntityFrameworkCore.Migrations;

namespace CARS.Migrations
{
    public partial class Category : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Part",
                table: "Steps");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Steps",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observations",
                table: "Steps",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Steps_CategoryId",
                table: "Steps",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Steps_Category_CategoryId",
                table: "Steps",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Steps_Category_CategoryId",
                table: "Steps");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Steps_CategoryId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Steps");

            migrationBuilder.DropColumn(
                name: "Observations",
                table: "Steps");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Steps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Part",
                table: "Steps",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project_BenjaminGamrekeli.Migrations
{
    public partial class updatedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DierHabitat_Dieren_DierId",
                table: "DierHabitat");

            migrationBuilder.DropForeignKey(
                name: "FK_DierHabitat_Habitats_HabitatId",
                table: "DierHabitat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DierHabitat",
                table: "DierHabitat");

            migrationBuilder.RenameTable(
                name: "DierHabitat",
                newName: "DierHabitats");

            migrationBuilder.RenameIndex(
                name: "IX_DierHabitat_HabitatId",
                table: "DierHabitats",
                newName: "IX_DierHabitats_HabitatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DierHabitats",
                table: "DierHabitats",
                columns: new[] { "DierId", "HabitatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DierHabitats_Dieren_DierId",
                table: "DierHabitats",
                column: "DierId",
                principalTable: "Dieren",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DierHabitats_Habitats_HabitatId",
                table: "DierHabitats",
                column: "HabitatId",
                principalTable: "Habitats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DierHabitats_Dieren_DierId",
                table: "DierHabitats");

            migrationBuilder.DropForeignKey(
                name: "FK_DierHabitats_Habitats_HabitatId",
                table: "DierHabitats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DierHabitats",
                table: "DierHabitats");

            migrationBuilder.RenameTable(
                name: "DierHabitats",
                newName: "DierHabitat");

            migrationBuilder.RenameIndex(
                name: "IX_DierHabitats_HabitatId",
                table: "DierHabitat",
                newName: "IX_DierHabitat_HabitatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DierHabitat",
                table: "DierHabitat",
                columns: new[] { "DierId", "HabitatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DierHabitat_Dieren_DierId",
                table: "DierHabitat",
                column: "DierId",
                principalTable: "Dieren",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DierHabitat_Habitats_HabitatId",
                table: "DierHabitat",
                column: "HabitatId",
                principalTable: "Habitats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

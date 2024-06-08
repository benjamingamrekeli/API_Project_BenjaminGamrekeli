using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Project_BenjaminGamrekeli.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_Habitats_HabitatId",
                table: "Habitats");

            migrationBuilder.DropForeignKey(
                name: "FK_Habitats_Klassen_KlasseId",
                table: "Habitats");

            migrationBuilder.DropIndex(
                name: "IX_Habitats_HabitatId",
                table: "Habitats");

            migrationBuilder.DropIndex(
                name: "IX_Habitats_KlasseId",
                table: "Habitats");

            migrationBuilder.DropColumn(
                name: "Dieet",
                table: "Habitats");

            migrationBuilder.DropColumn(
                name: "HabitatId",
                table: "Habitats");

            migrationBuilder.DropColumn(
                name: "KlasseId",
                table: "Habitats");

            migrationBuilder.DropColumn(
                name: "LevensVerwachting",
                table: "Habitats");

            migrationBuilder.DropColumn(
                name: "Naam",
                table: "Habitats");

            migrationBuilder.CreateTable(
                name: "Dieren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KlasseId = table.Column<int>(type: "int", nullable: false),
                    Dieet = table.Column<int>(type: "int", nullable: false),
                    LevensVerwachting = table.Column<int>(type: "int", nullable: false),
                    HabitatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dieren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dieren_Habitats_HabitatId",
                        column: x => x.HabitatId,
                        principalTable: "Habitats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dieren_Klassen_KlasseId",
                        column: x => x.KlasseId,
                        principalTable: "Klassen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Dieren_HabitatId",
                table: "Dieren",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_Dieren_KlasseId",
                table: "Dieren",
                column: "KlasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_DierHabitats_Dieren_DierId",
                table: "DierHabitats",
                column: "DierId",
                principalTable: "Dieren",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DierHabitats_Dieren_DierId",
                table: "DierHabitats");

            migrationBuilder.DropTable(
                name: "Dieren");

            migrationBuilder.AddColumn<int>(
                name: "Dieet",
                table: "Habitats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HabitatId",
                table: "Habitats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlasseId",
                table: "Habitats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LevensVerwachting",
                table: "Habitats",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Naam",
                table: "Habitats",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Habitats_HabitatId",
                table: "Habitats",
                column: "HabitatId");

            migrationBuilder.CreateIndex(
                name: "IX_Habitats_KlasseId",
                table: "Habitats",
                column: "KlasseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_Habitats_HabitatId",
                table: "Habitats",
                column: "HabitatId",
                principalTable: "Habitats",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Habitats_Klassen_KlasseId",
                table: "Habitats",
                column: "KlasseId",
                principalTable: "Klassen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

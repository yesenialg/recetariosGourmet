using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gourmet.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recetarios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecetasRecetario",
                columns: table => new
                {
                    RecetariosId = table.Column<long>(type: "INTEGER", nullable: false),
                    RecetasId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetasRecetario", x => new { x.RecetariosId, x.RecetasId });
                    table.ForeignKey(
                        name: "FK_RecetasRecetario_Recetarios_RecetariosId",
                        column: x => x.RecetariosId,
                        principalTable: "Recetarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecetasRecetario_Recetas_RecetasId",
                        column: x => x.RecetasId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecetasRecetario_RecetasId",
                table: "RecetasRecetario",
                column: "RecetasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecetasRecetario");

            migrationBuilder.DropTable(
                name: "Recetarios");

            migrationBuilder.DropTable(
                name: "Recetas");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauranteprueba.Migrations
{
    /// <inheritdoc />
    public partial class migracion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaMenu",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlatillo = table.Column<int>(type: "int", nullable: false),
                    NombreCategoria = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaMenu", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_CategoriaMenu_Menu_IdPlatillo",
                        column: x => x.IdPlatillo,
                        principalTable: "Menu",
                        principalColumn: "IdPlatillo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaMenu_IdPlatillo",
                table: "CategoriaMenu",
                column: "IdPlatillo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaMenu");
        }
    }
}

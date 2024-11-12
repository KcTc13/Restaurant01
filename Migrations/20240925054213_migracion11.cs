using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauranteprueba.Migrations
{
    /// <inheritdoc />
    public partial class migracion11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Valoracion",
                columns: table => new
                {
                    IdValoracion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Puntuacion = table.Column<int>(type: "int", nullable: false),
                    FechaValoracion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoracion", x => x.IdValoracion);
                    table.ForeignKey(
                        name: "FK_Valoracion_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Valoracion_IdCliente",
                table: "Valoracion",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Valoracion");
        }
    }
}

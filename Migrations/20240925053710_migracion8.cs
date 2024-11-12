using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restauranteprueba.Migrations
{
    /// <inheritdoc />
    public partial class migracion8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    IdDetalleOrden = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrden = table.Column<int>(type: "int", nullable: false),
                    IdPlatillo = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrden", x => x.IdDetalleOrden);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Menu_IdPlatillo",
                        column: x => x.IdPlatillo,
                        principalTable: "Menu",
                        principalColumn: "IdPlatillo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden_IdOrden",
                        column: x => x.IdOrden,
                        principalTable: "Orden",
                        principalColumn: "IdOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdOrden",
                table: "DetalleOrden",
                column: "IdOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_IdPlatillo",
                table: "DetalleOrden",
                column: "IdPlatillo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrden");
        }
    }
}

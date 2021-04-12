using Microsoft.EntityFrameworkCore.Migrations;

namespace Mi_Primer_API.Migrations
{
    public partial class Tiendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ubicacion",
                table: "Tiendas",
                newName: "Ubicacion");

            migrationBuilder.CreateTable(
                name: "ControlInventario",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProducto = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadVenta = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadCompra = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalVenta = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalCompra = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<int>(type: "INTEGER", nullable: false),
                    TiendaID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlInventario", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ControlInventario_Tiendas_TiendaID",
                        column: x => x.TiendaID,
                        principalTable: "Tiendas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdFactura = table.Column<int>(type: "INTEGER", nullable: false),
                    NombreCliente = table.Column<string>(type: "TEXT", nullable: true),
                    TotalPagar = table.Column<int>(type: "INTEGER", nullable: false),
                    Fecha = table.Column<int>(type: "INTEGER", nullable: false),
                    TiendaID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Factura_Tiendas_TiendaID",
                        column: x => x.TiendaID,
                        principalTable: "Tiendas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    PrecioVenta = table.Column<int>(type: "INTEGER", nullable: false),
                    PrecioCompra = table.Column<int>(type: "INTEGER", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    FacturaID = table.Column<int>(type: "INTEGER", nullable: true),
                    TiendaID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Producto_Factura_FacturaID",
                        column: x => x.FacturaID,
                        principalTable: "Factura",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Producto_Tiendas_TiendaID",
                        column: x => x.TiendaID,
                        principalTable: "Tiendas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ControlInventario_TiendaID",
                table: "ControlInventario",
                column: "TiendaID");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_TiendaID",
                table: "Factura",
                column: "TiendaID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_FacturaID",
                table: "Producto",
                column: "FacturaID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_TiendaID",
                table: "Producto",
                column: "TiendaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ControlInventario");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.RenameColumn(
                name: "Ubicacion",
                table: "Tiendas",
                newName: "ubicacion");
        }
    }
}

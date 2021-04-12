using Microsoft.EntityFrameworkCore.Migrations;

namespace Mi_Primer_API.Migrations
{
    public partial class AgregandoTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Tiendas_TiendaID",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Factura_FacturaID",
                table: "Producto");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Tiendas_TiendaID",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Producto_FacturaID",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factura",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "FacturaID",
                table: "Producto");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Productos");

            migrationBuilder.RenameTable(
                name: "Factura",
                newName: "Facturas");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_TiendaID",
                table: "Productos",
                newName: "IX_Productos_TiendaID");

            migrationBuilder.RenameIndex(
                name: "IX_Factura_TiendaID",
                table: "Facturas",
                newName: "IX_Facturas_TiendaID");

            migrationBuilder.AddColumn<string>(
                name: "Productos",
                table: "Facturas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Tiendas_TiendaID",
                table: "Facturas",
                column: "TiendaID",
                principalTable: "Tiendas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Tiendas_TiendaID",
                table: "Productos",
                column: "TiendaID",
                principalTable: "Tiendas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Tiendas_TiendaID",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Tiendas_TiendaID",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturas",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Productos",
                table: "Facturas");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.RenameTable(
                name: "Facturas",
                newName: "Factura");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_TiendaID",
                table: "Producto",
                newName: "IX_Producto_TiendaID");

            migrationBuilder.RenameIndex(
                name: "IX_Facturas_TiendaID",
                table: "Factura",
                newName: "IX_Factura_TiendaID");

            migrationBuilder.AddColumn<int>(
                name: "FacturaID",
                table: "Producto",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factura",
                table: "Factura",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_FacturaID",
                table: "Producto",
                column: "FacturaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Tiendas_TiendaID",
                table: "Factura",
                column: "TiendaID",
                principalTable: "Tiendas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Factura_FacturaID",
                table: "Producto",
                column: "FacturaID",
                principalTable: "Factura",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Tiendas_TiendaID",
                table: "Producto",
                column: "TiendaID",
                principalTable: "Tiendas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

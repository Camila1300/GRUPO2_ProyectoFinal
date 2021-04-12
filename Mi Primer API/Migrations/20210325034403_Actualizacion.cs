using Microsoft.EntityFrameworkCore.Migrations;

namespace Mi_Primer_API.Migrations
{
    public partial class Actualizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "Productos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Productos");
        }
    }
}

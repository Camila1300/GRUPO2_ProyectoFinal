using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace Mi_Primer_API.Controllers
{
    
    public class Carrito
    {
        [Key]
        public int IdCompra {get; set;}

        public int IdProducto {get; set; }
        public string NameProducto {get; set; }
        public int PrecioProducto {get; set; }
        public int Cantidad {get; set; }
        public string UsuarioCompra {get; set; }
        public decimal Total {get; set; }

        public Carrito(int NuevoIdProducto, decimal NuevoTotal, string NuevoNameProducto, int NuevoPrecioProducto, int NuevaCantidad, string NuevoUsuarioCompra, int NuevoIdCompra)
        {
            IdProducto = NuevoIdProducto;
            NameProducto = NuevoNameProducto;
            PrecioProducto = NuevoPrecioProducto;
            Cantidad = NuevaCantidad;
            UsuarioCompra = NuevoUsuarioCompra;
            IdCompra = NuevoIdCompra;
            Total = NuevoTotal;
        }
        public Carrito()
        {
        }
    }
}
    

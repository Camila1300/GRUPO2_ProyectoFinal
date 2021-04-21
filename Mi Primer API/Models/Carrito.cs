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
        public string Descripcion {get; set; }
        public string UsuarioCompra {get; set; }
        public string ImagenUrl {get; set;}

        public Carrito(int NuevoIdProducto, string NuevoNameProducto, int NuevoPrecioProducto, int NuevaCantidad, string NuevaDescripcion, string NuevoUsuarioCompra, int NuevoIdCompra, string NuevaImagenUrl)
        {
            IdProducto = NuevoIdProducto;
            NameProducto = NuevoNameProducto;
            PrecioProducto = NuevoPrecioProducto;
            Cantidad = NuevaCantidad;
            Descripcion = NuevaDescripcion;
            UsuarioCompra = NuevoUsuarioCompra;
            IdCompra = NuevoIdCompra;
            ImagenUrl = NuevaImagenUrl;
        }
        public Carrito()
        {
        }
    }
}
    

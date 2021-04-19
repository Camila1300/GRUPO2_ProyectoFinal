
using System;
namespace Mi_Primer_API.Controllers
{
    public class Carrito
    {
        public int IdProducto {get; set; }
        public string NameProducto {get; set; }
        public int PrecioProducto {get; set; }
        public int Cantidad {get; set; }
        public string Descripcion {get; set; }
        public string UsuarioCompra {get; set; }

        public Carrito(int NuevoIdProducto, string NuevoNameProducto, int NuevoPrecioProducto, int NuevaCantidad, string NuevaDescripcion, string NuevoUsuarioCompra)
        {
            IdProducto = NuevoIdProducto;
            NameProducto = NuevoNameProducto;
            PrecioProducto = NuevoPrecioProducto;
            Cantidad = NuevaCantidad;
            Descripcion = NuevaDescripcion;
            UsuarioCompra = NuevoUsuarioCompra;
        }
        public Carrito()
        {
        }
    }
}
    

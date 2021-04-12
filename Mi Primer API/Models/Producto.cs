
using System;
namespace Mi_Primer_API.Controllers
    {      
    public class Producto
    {
        public int ID {get; set;}
        public int IdProducto{get;set;}
        public string Nombre {get; set;}
        public int PrecioVenta {get; set;}
        public int PrecioCompra {get; set;}
        public string Descripcion {get; set;}
 
        public Producto(int NuevoID, string NuevoNombre, int NuevoPrecioVenta, int NuevoPrecioCompra, string NuevaDescripcion)
        {
            ID = NuevoID;
            Nombre = NuevoNombre;
            PrecioVenta = NuevoPrecioVenta;
            PrecioCompra = NuevoPrecioCompra;
            Descripcion = NuevaDescripcion;
        }
         public Producto()
        {
        }
    }




}      
        
        

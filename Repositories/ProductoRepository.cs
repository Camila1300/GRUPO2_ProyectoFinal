using System.Collections.Generic;
using Mi_Primer_API;
using Mi_Primer_API.Controllers;
namespace Mi_Primer_API
{
    public class ProductoRepository
    {
         static List<Producto> Productos = new List<Producto>();   

         public List<Producto> ObtenerProductos()
         {
             return Productos;
         }

         public void agregarProducto(Producto nuevo)
         {
            Productos.Add(nuevo);
         }
         public void ActualizarProducto(Producto nuevo)
         {
              Producto productoViejo= Productos.Find((t=> t.ID==nuevo.ID));
            
            Productos.Remove(productoViejo);

            Productos.Add(nuevo);
         }
        public void BorrarProducto(int id)
        {
            Producto productoViejo= Productos.Find((t=> t.ID==id));
            Productos.Remove(productoViejo); 
        }

    }
}
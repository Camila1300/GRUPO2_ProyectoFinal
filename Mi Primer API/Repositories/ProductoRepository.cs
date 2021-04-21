using System;
using System.Collections.Generic;
using System.Linq;
using Mi_Primer_API;
using Mi_Primer_API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace Mi_Primer_API
{
    public class ProductoRepository
    {

        private readonly Tiendas2Context _context;

        public ProductoRepository()
        {
            _context = new Tiendas2Context();
        }

         public List<Producto> ObtenerProductos()
         {
             return _context.Productos.ToList();
         }

         public void agregarProducto(Producto nuevo)
         {
            _context.Productos.Add(nuevo);
         }
         
         /*
         public void ActualizarProducto(Producto nuevo)
         {
              Producto productoViejo= _context.Productos.Find((t=> t.ID==nuevo.ID));
            
            _context.Productos.Remove(productoViejo);

            _context.Productos.Add(nuevo);
         }
        public void BorrarProducto(int id)
        {
            Producto productoViejo= _context.Productos.Find((t=> t.ID==id));
            _context.Productos.Remove(productoViejo); 
        }*/

    }
}
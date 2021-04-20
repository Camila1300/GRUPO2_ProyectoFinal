using System.Collections.Generic;
using System.Linq;
using Mi_Primer_API;
using Mi_Primer_API.Controllers;
using Microsoft.EntityFrameworkCore;


namespace Mi_Primer_API
{
    public class CarritoRepository
    {
        private Tiendas2Context bd;

        public CarritoRepository()
        {
            bd = new Tiendas2Context();
        }

        public List<Carrito> ObtenerCarritos()
        {
            return bd.Carrito.ToList();
        }
        public string AgregarCarrito(Carrito NuevoCarrito)
        {
            var result = bd.Carrito.Add(NuevoCarrito);
            bd.SaveChanges();
            return "CARRITO agregado ";
        }

       public Carrito ActualizarCantidad(int id, Carrito nCantidad)
       {
           var carrito = bd.Carrito.Where(x => x.IdCompra == id).FirstOrDefault();
           if(carrito == null)
           {
               return null;
           }
           else
           {
               carrito.Cantidad = nCantidad.Cantidad;
               bd.SaveChanges();
               return nCantidad;
           }
       }
       public string EliminarDeCarrito(int IdCompra)
       {
           bd.Carrito.Remove(bd.Carrito.Find(IdCompra));
           bd.SaveChanges();
           return "Producto eliminado del carrito. Id Compra: " + IdCompra;
       }
    }
}
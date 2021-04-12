
using System.Collections.Generic;
using System.Linq;
using Mi_Primer_API;
using Mi_Primer_API.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Mi_Primer_API
{
    public class TiendaResository
    {
        private Tiendas2Context db;

        public TiendaResository()
        {
            db = new Tiendas2Context();
        }

        public List<Tienda> ObtenerTiendas()
        {
            return db.Tiendas.Include(x => x.Facturas).ToList();
        }
        public string AgregarTienda(Tienda nTienda)
        {
            var result = db.Tiendas.Add(nTienda);
            db.SaveChanges();
            return "Tienda agregada  " + result.Entity.Nombre;
        }

        public string BorrarTienda(string id)
        {
            db.Tiendas.Remove(db.Tiendas.Find(id));
            db.SaveChanges();
            return "Tienda borrada con el id " + id;
        }
        //Use el FirstOrDefault ya que el include para imprimir las facturas y los productos no funciona con el find
        public Tienda ObtenerTienda(string id)
        {
            return db.Tiendas.Include(x => x.Facturas).Include(x => x.Productos).FirstOrDefault(e => e.ID == id);
        }

        //Método para agregar una factura a  una tienda - Kevin
        /*public string AgregarFactura(Factura nuevaFactura)
        {
            var result = db.Facturas.Add(nuevaFactura);
            db.SaveChanges();
            return "Factura agregada  " + result.Entity.IdFactura;
        }
        */
        public string AgregarFactura(Factura nuevaFactura)
        {
            db.Tiendas.Find(nuevaFactura.TiendaID).Facturas.Add(nuevaFactura);
            db.SaveChanges();
            return "Factura agregada ";
        }
    }
}
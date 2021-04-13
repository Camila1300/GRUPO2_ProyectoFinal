using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Mi_Primer_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class TiendaController : ControllerBase
    {
        private TiendaResository tiendaResository;

        public TiendaController()
        {
            tiendaResository = new TiendaResository();
        }
        [HttpGet]
        public List<Tienda> ObtenerTienda()
        {
            return tiendaResository.ObtenerTiendas();
        }
        //--------------------------------------------------------------------------------------------      
        // Metodos creados por Ricardo
        //--------------------------------------------------------------------------------------------      
        [HttpGet]
        [Route("Ventas")]
        public float ObtenerVentasDeTienda([FromRoute] string id)
        {
            return tiendaResository.ObtenerTienda(id).TotalVentas();
        }
        [HttpGet]
        [Route("Compras")]
        public float ObtenerComprasDeTienda([FromRoute] string id)
        {
            return tiendaResository.ObtenerTienda(id).TotalCompras();
        }
        [HttpGet]
        [Route("Estado")]
        public bool ObtenerEstado([FromRoute] string id)
        {
            return tiendaResository.ObtenerTienda(id).Estado();
        }
        //--------------------------------------------------------------------------------------------
        [HttpGet]
        [Route("{id}")]
        public Tienda ObtenerTienda([FromRoute] string id)
        {
            return tiendaResository.ObtenerTienda(id);
        }
        [HttpPost]
        public string AgregarTienda([FromBody] Tienda nueva)
        {
            return tiendaResository.AgregarTienda(nueva);
        }

        //Put Nueva Factura - Kevin
        [HttpPost]
        [Route("{AgregarFactura}")]
        public string AgregarFactura([FromBody] Factura nuevaFactura)
        {
            return tiendaResository.AgregarFactura(nuevaFactura);
        }

      


        [HttpPut]
        public string AcutalizarTienda([FromQuery] string id, [FromQuery] string nombre, [FromQuery] string ubicacion,
        [FromQuery] List<Factura> facturas, [FromQuery] List<ControlInventario> controlinventario)
        {
            var tienda = tiendaResository.ObtenerTienda(id);
            tienda.Nombre = nombre;
            tienda.Ubicacion = ubicacion;
            tienda.Facturas = facturas;
            tienda.ControlInventario = controlinventario;
            tiendaResository.BorrarTienda(tienda.ID);
            tiendaResository.AgregarTienda(tienda);
            return "Tienda editada " + tienda.Nombre;
        }

         [HttpPut]
         [Route("{Actualizar tienda}")]
           public string ActualizarTienda([FromQuery] string id, [FromQuery] string nombre, [FromQuery] string ubicacion)
        {
            var tienda = tiendaResository.ObtenerTienda(id);
            tienda.Nombre = nombre;
            tienda.Ubicacion = ubicacion;
            return "Tienda Actualizada"+tienda.Nombre;
            
        }

        [HttpDelete]
        public string BorrarTienda([FromQuery] string id)
        {
            return tiendaResository.BorrarTienda(id);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Mi_Primer_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CarritoController: ControllerBase
    {
        
        private CarritoRepository carritoRepository;

        public CarritoController(){
           carritoRepository = new CarritoRepository();
        }
        [HttpGet]
        public List<Carrito> ObtenerCarrito()
        {
            return carritoRepository.ObtenerCarritos();
        }

        [HttpPost]
        public string AgregarCarrito([FromBody] Carrito NuevoCarrito)
        {
            return carritoRepository.AgregarCarrito(NuevoCarrito);
        }

        [HttpPut]
           public string ActualizarCarrito(int id, [FromBody] Carrito nCantidad)
        {
            var carrito = carritoRepository.ActualizarCantidad(id, nCantidad);
            return "cantidad actualizada";
        }
    }
}
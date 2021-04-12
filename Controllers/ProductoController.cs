using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace Mi_Primer_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductoController: ControllerBase
    {
        
        private ProductoRepository productoRepository;

        public ProductoController(){
           productoRepository=new ProductoRepository();
        }

        [HttpGet]
        public  List<Producto> ObtenerDeProducto()
        {
                return productoRepository.ObtenerProductos();
        }
        [HttpPost]
        public string AgregarProducto([FromBody] Producto nuevo)
        {
            productoRepository.agregarProducto(nuevo);
            
            return "Producto agregado ";
        }
        [HttpPut]
        //ID, Nombre, precio venta, precio compra, descripcion 
        public string ActualizarPrecio([FromBody] Producto nuevo)
        {
           productoRepository.ActualizarProducto(nuevo);
            
            return "Producto editado ";
        }
        [HttpDelete]
        public string BorrarProducto([FromQuery] int id)
        {
            productoRepository.BorrarProducto(id);          
            return "Producto borrado con el id "+id;
        }
    }
}
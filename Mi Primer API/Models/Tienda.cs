using System.Collections.Generic;
namespace Mi_Primer_API.Controllers
    {
        public class Tienda{
        public string ID {get; set;}
        public string Nombre {get; set;}        
        public string Ubicacion {get; set;}
        public List<ControlInventario> ControlInventario{get; set;}
        public List<Factura> Facturas{get; set;}
        public List<Producto> Productos{get; set;}
        //=======================================================================
        // Metodos creados por Ricardo
        //=======================================================================
        public bool Estado(){
            // si es true el estado es bueno ya que las ventas son mayores a las compras
            return (TotalVentas()>TotalCompras());
        }
        public float TotalCompras(){
            float respuesta=0;
            foreach (var item in ControlInventario)
            {
                respuesta+= item.TotalCompra;
            }
            return respuesta;
        }
        public float TotalVentas(){
            float respuesta=0;
            foreach (var item in Facturas)
            {
                respuesta+= item.TotalPagar;
            }
            return respuesta;
        }
        //=======================================================================
        public  Tienda (string nombre, string ubicacion)
        {
            ID=nombre+ubicacion;
            Nombre=nombre; 
            Ubicacion = ubicacion;
            Facturas = new List<Factura>();
            ControlInventario = new List<ControlInventario>();
            Productos=new List<Producto>();
        }
    }
}
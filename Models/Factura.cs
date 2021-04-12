
using System.Collections.Generic;
namespace Mi_Primer_API.Controllers
    {
        public class Factura
        {
            public int ID{get; set;}
            public int IdFactura{get; set;}
            public string NombreCliente{get; set;}
            public string Productos{get; set;}
            public int TotalPagar{get; set;}
            public int Fecha{get; set;}
            public string TiendaID{get; set;}

            public Factura(int NuevaIdFactura, string NuevoNombreCliente, string NuevosProductos, 
            int NuevoTotalPagar, int NuevaFecha, string NuevaTiendaID)
            {                 
                IdFactura = NuevaIdFactura;
                NombreCliente = NuevoNombreCliente;
                Productos = NuevosProductos;
                TotalPagar = NuevoTotalPagar;
                Fecha = NuevaFecha;
                TiendaID = NuevaTiendaID;
            }
            public Factura()
            {               
            }
        }
 }

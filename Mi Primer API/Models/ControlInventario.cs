using System;
namespace Mi_Primer_API.Controllers
    {
        public class ControlInventario 
        {
            public int ID{get; set;}
            public int IdProducto{get; set;}
            public int CantidadVenta{get; set;}
            public int CantidadCompra{get; set;}
            public int TotalVenta{get; set;}
            public int TotalCompra{get; set;}
            public int Fecha{get; set;}

            public ControlInventario(int id,int NuevaIdProducto, int Nuevacantidadventa,int  Nuevacantidadcompra, 
            int NuevoTotalventa, int NuevoTotalcompra,int Nuevafecha)
            {
                int ID=id;
                int IdProducto = NuevaIdProducto;
                int CantidadVenta= Nuevacantidadventa;
                int CantidadCompra = Nuevacantidadcompra;
                int TotalVenta = NuevoTotalventa;
                int TotalCompra= NuevoTotalcompra;
                int Fecha = Nuevafecha;
            }
            public ControlInventario()
            {

            }
        }
    }

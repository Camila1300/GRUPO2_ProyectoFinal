using System.Collections.Generic;
using Mi_Primer_API.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Mi_Primer_API
{
    public class Tiendas2Context : DbContext
    {
        public DbSet<Tienda> Tiendas { get; set; } 
        public DbSet<Factura> Facturas { get; set; } 
        public DbSet<Producto> Productos { get; set; }  


        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=CadenaDeTiendas.db");//Nombre de base de datos
    }
}
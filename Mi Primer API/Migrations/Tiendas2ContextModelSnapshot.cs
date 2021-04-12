﻿// <auto-generated />
using Mi_Primer_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Mi_Primer_API.Migrations
{
    [DbContext(typeof(Tiendas2Context))]
    partial class Tiendas2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Mi_Primer_API.Controllers.ControlInventario", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadCompra")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CantidadVenta")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fecha")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TiendaID")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalCompra")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalVenta")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("TiendaID");

                    b.ToTable("ControlInventario");
                });

            modelBuilder.Entity("Mi_Primer_API.Controllers.Factura", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fecha")
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdFactura")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NombreCliente")
                        .HasColumnType("TEXT");

                    b.Property<string>("Productos")
                        .HasColumnType("TEXT");

                    b.Property<string>("TiendaID")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalPagar")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("TiendaID");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Mi_Primer_API.Controllers.Producto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdProducto")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<int>("PrecioCompra")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrecioVenta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TiendaID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("TiendaID");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Mi_Primer_API.Controllers.Tienda", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ubicacion")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Tiendas");
                });

            modelBuilder.Entity("Mi_Primer_API.Controllers.ControlInventario", b =>
                {
                    b.HasOne("Mi_Primer_API.Controllers.Tienda", null)
                        .WithMany("ControlInventario")
                        .HasForeignKey("TiendaID");
                });

            modelBuilder.Entity("Mi_Primer_API.Controllers.Factura", b =>
                {
                    b.HasOne("Mi_Primer_API.Controllers.Tienda", null)
                        .WithMany("Facturas")
                        .HasForeignKey("TiendaID");
                });

            modelBuilder.Entity("Mi_Primer_API.Controllers.Producto", b =>
                {
                    b.HasOne("Mi_Primer_API.Controllers.Tienda", null)
                        .WithMany("Productos")
                        .HasForeignKey("TiendaID");
                });

            modelBuilder.Entity("Mi_Primer_API.Controllers.Tienda", b =>
                {
                    b.Navigation("ControlInventario");

                    b.Navigation("Facturas");

                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
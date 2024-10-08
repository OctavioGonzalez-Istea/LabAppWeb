﻿// <auto-generated />
using System;
using LaboratorioApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaboratorioWeb.Migrations
{
    [DbContext(typeof(RestauranteContext))]
    [Migration("20240928183157_inicial")]
    partial class inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entidades.Comanda", b =>
                {
                    b.Property<int>("ComandaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComandaId"));

                    b.Property<int>("MesaId")
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ComandaId");

                    b.HasIndex("MesaId");

                    b.ToTable("Comandas");

                    b.HasData(
                        new
                        {
                            ComandaId = 1,
                            MesaId = 1,
                            NombreCliente = "Cliente 1"
                        },
                        new
                        {
                            ComandaId = 2,
                            MesaId = 2,
                            NombreCliente = "Cliente 2"
                        },
                        new
                        {
                            ComandaId = 3,
                            MesaId = 3,
                            NombreCliente = "Cliente 3"
                        });
                });

            modelBuilder.Entity("Entidades.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpleadoId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpleadoId");

                    b.HasIndex("RolId");

                    b.HasIndex("SectorId");

                    b.ToTable("Empleados");

                    b.HasData(
                        new
                        {
                            EmpleadoId = 1,
                            Nombre = "Carlos Pérez",
                            Password = "password123",
                            RolId = 4,
                            SectorId = 1,
                            Usuario = "cperez"
                        },
                        new
                        {
                            EmpleadoId = 2,
                            Nombre = "Ana Gómez",
                            Password = "password456",
                            RolId = 2,
                            SectorId = 3,
                            Usuario = "agomez"
                        },
                        new
                        {
                            EmpleadoId = 3,
                            Nombre = "Pedro Ruiz",
                            Password = "password789",
                            RolId = 3,
                            SectorId = 2,
                            Usuario = "pruiz"
                        },
                        new
                        {
                            EmpleadoId = 4,
                            Nombre = "Juan López",
                            Password = "password000",
                            RolId = 5,
                            SectorId = 5,
                            Usuario = "jlopez"
                        },
                        new
                        {
                            EmpleadoId = 5,
                            Nombre = "Omar Sanchez",
                            Password = "password012",
                            RolId = 1,
                            SectorId = 4,
                            Usuario = "osanchez"
                        });
                });

            modelBuilder.Entity("Entidades.EstadoMesa", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("EstadosMesas");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Descripcion = "Esperando pedido"
                        },
                        new
                        {
                            EstadoId = 2,
                            Descripcion = "Comiendo"
                        },
                        new
                        {
                            EstadoId = 3,
                            Descripcion = "Pagando"
                        },
                        new
                        {
                            EstadoId = 4,
                            Descripcion = "Cerrada"
                        });
                });

            modelBuilder.Entity("Entidades.EstadoPedido", b =>
                {
                    b.Property<int>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstadoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoId");

                    b.ToTable("EstadosPedidos");

                    b.HasData(
                        new
                        {
                            EstadoId = 1,
                            Descripcion = "Pedido recibido"
                        },
                        new
                        {
                            EstadoId = 2,
                            Descripcion = "Preparando"
                        },
                        new
                        {
                            EstadoId = 3,
                            Descripcion = "Listo para servir"
                        },
                        new
                        {
                            EstadoId = 4,
                            Descripcion = "Entregado"
                        });
                });

            modelBuilder.Entity("Entidades.Mesa", b =>
                {
                    b.Property<int>("MesaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MesaId"));

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MesaId");

                    b.HasIndex("EstadoId");

                    b.ToTable("Mesas");

                    b.HasData(
                        new
                        {
                            MesaId = 1,
                            EstadoId = 1,
                            Nombre = "Cliente 1"
                        },
                        new
                        {
                            MesaId = 2,
                            EstadoId = 2,
                            Nombre = "Cliente 2"
                        },
                        new
                        {
                            MesaId = 3,
                            EstadoId = 3,
                            Nombre = "Cliente 3"
                        });
                });

            modelBuilder.Entity("Entidades.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFinalizacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("PedidoId");

                    b.HasIndex("ComandaId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Pedidos");

                    b.HasData(
                        new
                        {
                            PedidoId = 1,
                            Cantidad = 2,
                            ComandaId = 1,
                            EstadoId = 1,
                            FechaCreacion = new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7665),
                            ProductoId = 1
                        },
                        new
                        {
                            PedidoId = 2,
                            Cantidad = 2,
                            ComandaId = 2,
                            EstadoId = 2,
                            FechaCreacion = new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7684),
                            FechaFinalizacion = new DateTime(2024, 9, 28, 16, 1, 57, 22, DateTimeKind.Local).AddTicks(7685),
                            ProductoId = 1
                        },
                        new
                        {
                            PedidoId = 3,
                            Cantidad = 2,
                            ComandaId = 3,
                            EstadoId = 3,
                            FechaCreacion = new DateTime(2024, 9, 28, 15, 31, 57, 22, DateTimeKind.Local).AddTicks(7691),
                            FechaFinalizacion = new DateTime(2024, 9, 28, 15, 51, 57, 22, DateTimeKind.Local).AddTicks(7691),
                            ProductoId = 1
                        });
                });

            modelBuilder.Entity("Entidades.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.Property<int>("SectorId")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.HasIndex("SectorId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Descripcion = "Vino Tinto",
                            Precio = 1500,
                            SectorId = 1,
                            Stock = 50
                        },
                        new
                        {
                            ProductoId = 2,
                            Descripcion = "Cerveza IPA",
                            Precio = 300,
                            SectorId = 2,
                            Stock = 100
                        },
                        new
                        {
                            ProductoId = 3,
                            Descripcion = "Empanadas",
                            Precio = 150,
                            SectorId = 3,
                            Stock = 200
                        },
                        new
                        {
                            ProductoId = 4,
                            Descripcion = "Tarta de Chocolate",
                            Precio = 600,
                            SectorId = 4,
                            Stock = 30
                        });
                });

            modelBuilder.Entity("Entidades.Rol", b =>
                {
                    b.Property<int>("RolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RolId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RolId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RolId = 1,
                            Descripcion = "Mozo"
                        },
                        new
                        {
                            RolId = 2,
                            Descripcion = "Cocinero"
                        },
                        new
                        {
                            RolId = 3,
                            Descripcion = "Cervecero"
                        },
                        new
                        {
                            RolId = 4,
                            Descripcion = "Bartender"
                        },
                        new
                        {
                            RolId = 5,
                            Descripcion = "Socio"
                        });
                });

            modelBuilder.Entity("Entidades.Sector", b =>
                {
                    b.Property<int>("SectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectorId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectorId");

                    b.ToTable("Sectores");

                    b.HasData(
                        new
                        {
                            SectorId = 1,
                            Descripcion = "Barra de tragos y vinos"
                        },
                        new
                        {
                            SectorId = 2,
                            Descripcion = "Barra de cerveza artesanal"
                        },
                        new
                        {
                            SectorId = 3,
                            Descripcion = "Cocina"
                        },
                        new
                        {
                            SectorId = 4,
                            Descripcion = "Candy Bar"
                        },
                        new
                        {
                            SectorId = 5,
                            Descripcion = "Caja"
                        });
                });

            modelBuilder.Entity("Entidades.Comanda", b =>
                {
                    b.HasOne("Entidades.Mesa", "Mesa")
                        .WithMany("Comandas")
                        .HasForeignKey("MesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mesa");
                });

            modelBuilder.Entity("Entidades.Empleado", b =>
                {
                    b.HasOne("Entidades.Rol", "Rol")
                        .WithMany("Empleados")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Sector", "Sector")
                        .WithMany("Empleados")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Entidades.Mesa", b =>
                {
                    b.HasOne("Entidades.EstadoMesa", "EstadoMesa")
                        .WithMany("Mesas")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadoMesa");
                });

            modelBuilder.Entity("Entidades.Pedido", b =>
                {
                    b.HasOne("Entidades.Comanda", "Comanda")
                        .WithMany("Pedidos")
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.EstadoPedido", "EstadoPedido")
                        .WithMany("Pedidos")
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidades.Producto", "Producto")
                        .WithMany("Pedidos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("EstadoPedido");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Entidades.Producto", b =>
                {
                    b.HasOne("Entidades.Sector", "Sector")
                        .WithMany("Productos")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Entidades.Comanda", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Entidades.EstadoMesa", b =>
                {
                    b.Navigation("Mesas");
                });

            modelBuilder.Entity("Entidades.EstadoPedido", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Entidades.Mesa", b =>
                {
                    b.Navigation("Comandas");
                });

            modelBuilder.Entity("Entidades.Producto", b =>
                {
                    b.Navigation("Pedidos");
                });

            modelBuilder.Entity("Entidades.Rol", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Entidades.Sector", b =>
                {
                    b.Navigation("Empleados");

                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}

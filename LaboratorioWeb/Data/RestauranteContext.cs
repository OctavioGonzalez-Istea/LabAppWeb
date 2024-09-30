using Microsoft.EntityFrameworkCore;
using Entidades;
using LaboratorioWeb.Data.Seed;

namespace LaboratorioApi.Data
{
    public class RestauranteContext : DbContext
    {
        public RestauranteContext(DbContextOptions<RestauranteContext> options) : base(options) { }

        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EstadoMesa> EstadosMesas { get; set; }
        public DbSet<EstadoPedido> EstadosPedidos { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Sector> Sectores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a muchos entre Mesa y Comanda
            modelBuilder.Entity<Mesa>()
                .HasMany(m => m.Comandas)
                .WithOne(c => c.Mesa)
                .HasForeignKey(c => c.MesaId);

            // Relación uno a muchos entre EstadoMesa y Mesa
            modelBuilder.Entity<EstadoMesa>()
                .HasMany(em => em.Mesas)
                .WithOne(m => m.EstadoMesa)
                .HasForeignKey(m => m.EstadoId);

            // Relación uno a muchos entre Producto y Pedido
            modelBuilder.Entity<Producto>()
                .HasMany(p => p.Pedidos)
                .WithOne(p => p.Producto)
                .HasForeignKey(p => p.ProductoId);

            // Relación uno a muchos entre Comanda y Pedido
            modelBuilder.Entity<Comanda>()
                .HasMany(c => c.Pedidos)
                .WithOne(p => p.Comanda)
                .HasForeignKey(p => p.ComandaId);

            // Relación uno a muchos entre Sector y Producto
            modelBuilder.Entity<Sector>()
                .HasMany(s => s.Productos)
                .WithOne(p => p.Sector)
                .HasForeignKey(p => p.SectorId);

            // Relación uno a muchos entre Sector y Empleado
            modelBuilder.Entity<Sector>()
                .HasMany(s => s.Empleados)
                .WithOne(e => e.Sector)
                .HasForeignKey(e => e.SectorId);

            // Relación uno a muchos entre Rol y Empleado
            modelBuilder.Entity<Rol>()
                .HasMany(r => r.Empleados)
                .WithOne(e => e.Rol)
                .HasForeignKey(e => e.RolId);

            // Relación uno a muchos entre EstadoPedido y Pedido
            modelBuilder.Entity<EstadoPedido>()
                .HasMany(ep => ep.Pedidos)
                .WithOne(p => p.EstadoPedido)
                .HasForeignKey(p => p.EstadoId);

            // Llamamos a las clases seed
            ComandaSeed.Seed(modelBuilder);
            SectorSeed.Seed(modelBuilder);
            RolSeed.Seed(modelBuilder);
            EstadoPedidoSeed.Seed(modelBuilder);
            EstadoMesaSeed.Seed(modelBuilder);
            ProductoSeed.Seed(modelBuilder);
            EmpleadoSeed.Seed(modelBuilder);
            MesaSeed.Seed(modelBuilder);
            PedidoSeed.Seed(modelBuilder);
            
        }

    }
}

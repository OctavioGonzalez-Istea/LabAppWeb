using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboratorioWeb.Data.Seed
{
    public class PedidoSeed : IEntityTypeConfiguration<Pedido>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>().HasData(
                new  { PedidoId = 1, NombreCliente = "Cliente 1", ComandaId = 1, ProductoId = 1, Cantidad = 2, MesaId = 1, EstadoId = 1, FechaCreacion = DateTime.Now },  // Pendiente
                new  { PedidoId = 2, NombreCliente = "Cliente 2", ComandaId = 2, ProductoId = 1, Cantidad = 2, MesaId = 2, EstadoId = 2, FechaCreacion = DateTime.Now, FechaFinalizacion = DateTime.Now.AddMinutes(30) },  // En preparación
                new  { PedidoId = 3, NombreCliente = "Cliente 3", ComandaId = 3, ProductoId = 1, Cantidad = 2, MesaId = 3, EstadoId = 3, FechaCreacion = DateTime.Now, FechaFinalizacion = DateTime.Now.AddMinutes(20) }   // Listo para servir
            );
        }

        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            throw new NotImplementedException();
        }
    }
}

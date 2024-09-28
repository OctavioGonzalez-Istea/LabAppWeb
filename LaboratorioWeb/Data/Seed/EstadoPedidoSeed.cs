using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboratorioWeb.Data.Seed
{
    public class EstadoPedidoSeed : IEntityTypeConfiguration<EstadoPedido>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoPedido>().HasData(
                new  { EstadoId = 1, Descripcion = "Pedido recibido" },
                new  { EstadoId = 2, Descripcion = "Preparando" },
                new  { EstadoId = 3, Descripcion = "Listo para servir" },
                new  { EstadoId = 4, Descripcion = "Entregado" }
            );
        }

        public void Configure(EntityTypeBuilder<EstadoPedido> builder)
        {
            throw new NotImplementedException();
        }
    }
}

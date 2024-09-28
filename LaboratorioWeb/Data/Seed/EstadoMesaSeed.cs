using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboratorioWeb.Data.Seed
{
    public class EstadoMesaSeed : IEntityTypeConfiguration<EstadoMesa>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoMesa>().HasData(
                new  { EstadoId = 1, Descripcion = "Esperando pedido" },
                new  { EstadoId = 2, Descripcion = "Comiendo" },
                new  { EstadoId = 3, Descripcion = "Pagando" },
                new  { EstadoId = 4, Descripcion = "Cerrada" }
            );
        }

        public void Configure(EntityTypeBuilder<EstadoMesa> builder)
        {
            throw new NotImplementedException();
        }
    }
}

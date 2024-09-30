using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboratorioWeb.Data.Seed
{
    public class MesaSeed : IEntityTypeConfiguration<Mesa>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mesa>().HasData(
                new  { MesaId = 1, Nombre = "Cliente 1", EstadoId = 1 }, // Esperando pedido
                new  { MesaId = 2, Nombre = "Cliente 2", EstadoId = 2 }, // Comiendo
                new  { MesaId = 3, Nombre = "Cliente 3", EstadoId = 3 }  // Pagando
            );
        }

        public void Configure(EntityTypeBuilder<Mesa> builder)
        {
            throw new NotImplementedException();
        }
    }
}

using Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioWeb.Data.Seed
{
    public class ComandaSeed : IEntityTypeConfiguration<Comanda>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Comanda>().HasData(
                new  { ComandaId = 1, MesaId = 1, NombreCliente = "Cliente 1" },
                new  { ComandaId = 2, MesaId = 2, NombreCliente = "Cliente 2" },
                new  { ComandaId = 3, MesaId = 3, NombreCliente = "Cliente 3" }
            );
        }

        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            throw new NotImplementedException();
        }
    }

}

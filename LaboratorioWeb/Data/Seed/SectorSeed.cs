using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboratorioWeb.Data.Seed
{
    public class SectorSeed : IEntityTypeConfiguration<Sector>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sector>().HasData(
                new  { SectorId = 1, Descripcion = "Barra de tragos y vinos"},
                new  { SectorId = 2, Descripcion = "Barra de cerveza artesanal"},
                new  { SectorId = 3, Descripcion = "Cocina"},
                new  { SectorId = 4, Descripcion = "Candy Bar"},
                new  { SectorId = 5, Descripcion = "Caja"}
            );
        }

        public void Configure(EntityTypeBuilder<Sector> builder)
        {
            throw new NotImplementedException();
        }
    }
}

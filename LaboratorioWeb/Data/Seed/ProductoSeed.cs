using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboratorioWeb.Data.Seed
{
    public class ProductoSeed : IEntityTypeConfiguration<Producto>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().HasData(
                new  { ProductoId = 1, SectorId = 1, Descripcion = "Vino Tinto", Stock = 50, Precio = 1500 },
                new  { ProductoId = 2, SectorId = 2, Descripcion = "Cerveza IPA", Stock = 100, Precio = 300 },
                new  { ProductoId = 3, SectorId = 3, Descripcion = "Empanadas", Stock = 200, Precio = 150 },
                new  { ProductoId = 4, SectorId = 4, Descripcion = "Tarta de Chocolate", Stock = 30, Precio = 600 }
            );
        }

        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            throw new NotImplementedException();
        }
    }
}

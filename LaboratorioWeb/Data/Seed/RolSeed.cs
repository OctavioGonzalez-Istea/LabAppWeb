using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboratorioWeb.Data.Seed
{
    public class RolSeed : IEntityTypeConfiguration<Rol>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new  { RolId = 1, Descripcion = "Mozo"},
                new  { RolId = 2, Descripcion = "Cocinero"},
                new  { RolId = 3, Descripcion = "Cervecero"},
                new  { RolId = 4, Descripcion = "Bartender"},
                new  { RolId = 5, Descripcion = "Socio"}
            );
        }

        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            throw new NotImplementedException();
        }
    }
}

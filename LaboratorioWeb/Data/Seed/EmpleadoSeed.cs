using Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LaboratorioWeb.Data.Seed
{
    public class EmpleadoSeed : IEntityTypeConfiguration<Empleado>
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasData(
                new  { EmpleadoId = 1, Nombre = "Carlos Pérez", Usuario = "cperez", Password = "password123", SectorId = 1, RolId = 4 },  // Bartender
                new  { EmpleadoId = 2, Nombre = "Ana Gómez", Usuario = "agomez", Password = "password456", SectorId = 3, RolId = 2 },  // Cocinero
                new  { EmpleadoId = 3, Nombre = "Pedro Ruiz", Usuario = "pruiz", Password = "password789", SectorId = 2, RolId = 3 },  // Cervecero
                new  { EmpleadoId = 4, Nombre = "Juan López", Usuario = "jlopez", Password = "password000", SectorId = 5, RolId = 5 },  // Socio
                new  { EmpleadoId = 5, Nombre = "Omar Sanchez", Usuario = "osanchez", Password = "password012", SectorId = 4, RolId = 1 }  // Socio
            );
        }

        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            throw new NotImplementedException();
        }
    }
}

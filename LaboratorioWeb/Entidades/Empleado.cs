using Microsoft.AspNetCore.Mvc;

namespace Entidades
{
    public class Empleado
{
    public int EmpleadoId { get; set; }
    public required string Nombre { get; set; }
    public required string Usuario { get; set; }
    public required string Password { get; set; }
    public int SectorId { get; set; }
    public int RolId { get; set; }

    public required Sector Sector { get; set; }
    public required Rol Rol { get; set; }
}
}

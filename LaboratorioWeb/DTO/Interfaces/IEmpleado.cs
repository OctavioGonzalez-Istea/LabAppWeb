namespace LaboratorioWeb.Interfaces
{
    public interface IEmpleadoDTO
    {
        int EmpleadoId { get; set; }
        string Nombre { get; set; }
        string Usuario { get; set; }
        int SectorId { get; set; }
        string SectorDescripcion { get; set; }
        int RolId { get; set; }
        string RolDescripcion { get; set; }
    }
}

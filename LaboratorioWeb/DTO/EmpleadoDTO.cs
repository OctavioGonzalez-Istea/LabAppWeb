namespace LaboratorioWeb.DTO
{
    public class EmpleadoDTO
    {
        public int EmpleadoId { get; set; }
        public required string Nombre { get; set; }
        public required string Usuario { get; set; }
        public int SectorId { get; set; }
        public required string SectorDescripcion { get; set; }
        public int RolId { get; set; }
        public required string RolDescripcion { get; set; }
    }
}

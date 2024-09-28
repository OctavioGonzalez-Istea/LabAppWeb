namespace LaboratorioWeb.DTO
{
    public class MesaDTO
    {
        public int MesaId { get; set; }
        public required string Nombre { get; set; }
        public int EstadoId { get; set; }
        public required string EstadoDescripcion { get; set; }
    }
}

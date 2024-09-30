namespace LaboratorioWeb.Interfaces
{
    public interface IMesaDTO
    {
        int MesaId { get; set; }
        string Nombre { get; set; }
        int EstadoId { get; set; }
        string EstadoDescripcion { get; set; }
    }
}

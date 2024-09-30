namespace LaboratorioWeb.Interfaces
{
    public interface IPedidoDTO
    {
        int PedidoId { get; set; }
        int ComandaId { get; set; }
        int ProductoId { get; set; }
        string ProductoDescripcion { get; set; }
        int Cantidad { get; set; }
        int EstadoId { get; set; }
        string EstadoDescripcion { get; set; }
        DateTime FechaCreacion { get; set; }
        DateTime? FechaFinalizacion { get; set; }
    }
}

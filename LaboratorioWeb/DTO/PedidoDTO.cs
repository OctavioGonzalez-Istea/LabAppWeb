namespace LaboratorioWeb.DTO
{
    public class PedidoDTO
    {
        public int PedidoId { get; set; }
        public int ComandaId { get; set; }
        public int ProductoId { get; set; }
        public required string ProductoDescripcion { get; set; }
        public int Cantidad { get; set; }
        public int EstadoId { get; set; }
        public required string EstadoDescripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
    }
}

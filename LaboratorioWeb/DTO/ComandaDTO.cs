namespace LaboratorioWeb.DTO
{
    public class ComandaDTO
    {
        public int ComandaId { get; set; }
        public int MesaId { get; set; }
        public string NombreCliente { get; set; } = string.Empty; // Inicializado para evitar nulos

        // Se mantiene la lista de pedidos, pero asume que PedidoDTO está simplificado
        public List<PedidoDTO> Pedidos { get; set; } = new List<PedidoDTO>();
    }
}

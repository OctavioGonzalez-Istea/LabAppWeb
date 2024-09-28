using System.Text.Json.Serialization;

namespace LaboratorioWeb.DTO
{
    public class ComandaDTO
    {
        public int ComandaId { get; set; }
        public int MesaId { get; set; }
        public required string NombreCliente { get; set; }
        public required List<PedidoDTO> Pedidos { get; set; } // Cada comanda puede tener varios pedidos
    }
}

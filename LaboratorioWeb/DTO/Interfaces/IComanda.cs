using LaboratorioWeb.DTO;

namespace LaboratorioWeb.Interfaces
{
    public interface IComandaDTO
    {
        int ComandaId { get; set; }
        int MesaId { get; set; }
        string NombreCliente { get; set; }
        List<PedidoDTO> Pedidos { get; set; }
    }
}

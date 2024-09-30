namespace LaboratorioWeb.Interfaces
{
    public interface IProductoDTO
    {
        int ProductoId { get; set; }
        int SectorId { get; set; }
        string Descripcion { get; set; }
        int Stock { get; set; }
        decimal Precio { get; set; }
    }
}

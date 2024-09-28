namespace LaboratorioWeb.DTO
{
    public class ProductoDTO
    {
        public int ProductoId { get; set; }
        public int SectorId { get; set; }
        public required string Descripcion { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
    }
}

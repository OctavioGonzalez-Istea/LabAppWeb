using AutoMapper;
using Entidades;
using LaboratorioWeb.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapeos para Comanda
        CreateMap<Comanda, ComandaDTO>()
            .ForMember(dest => dest.Pedidos, opt => opt.MapFrom(src => src.Pedidos));
        CreateMap<ComandaDTO, Comanda>()
            .ForMember(dest => dest.Pedidos, opt => opt.MapFrom(src => src.Pedidos))
            .ForMember(dest => dest.Mesa, opt => opt.Ignore()); // Ignorar la mesa completa

        // Mapeos para Empleado
        CreateMap<Empleado, EmpleadoDTO>()
            .ForMember(dest => dest.SectorDescripcion, opt => opt.MapFrom(src => src.Sector.Descripcion))
            .ForMember(dest => dest.RolDescripcion, opt => opt.MapFrom(src => src.Rol.Descripcion));
        CreateMap<EmpleadoDTO, Empleado>();

        // Mapeos para EstadoMesa
        CreateMap<EstadoMesa, EstadoMesaDTO>();
        CreateMap<EstadoMesaDTO, EstadoMesa>();

        // Mapeos para EstadoPedido
        CreateMap<EstadoPedido, EstadoPedidoDTO>();
        CreateMap<EstadoPedidoDTO, EstadoPedido>();

        // Mapeos para Mesa
        CreateMap<Mesa, MesaDTO>()
            .ForMember(dest => dest.EstadoDescripcion, opt => opt.MapFrom(src => src.EstadoMesa.Descripcion));
        CreateMap<MesaDTO, Mesa>();

        // Mapeos para Pedido
        CreateMap<Pedido, PedidoDTO>()
            .ForMember(dest => dest.ProductoDescripcion, opt => opt.MapFrom(src => src.Producto.Descripcion))
            .ForMember(dest => dest.EstadoDescripcion, opt => opt.MapFrom(src => src.EstadoPedido.Descripcion));
        // Configuración para el mapeo del PedidoDTO a Pedido, pero ignorando ciertos campos
        CreateMap<PedidoDTO, Pedido>()
            .ForMember(dest => dest.EstadoId, opt => opt.Ignore()) // Ignoramos EstadoId
            .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore()) // Ignoramos FechaCreacion
            .ForMember(dest => dest.FechaFinalizacion, opt => opt.Ignore()); // Ignoramos FechaFinalizacion

        // Mapeos para Producto
        CreateMap<Producto, ProductoDTO>();
        CreateMap<ProductoDTO, Producto>();

        // Mapeos para Rol
        CreateMap<Rol, RolDTO>();
        CreateMap<RolDTO, Rol>();

        // Mapeos para Sector
        CreateMap<Sector, SectorDTO>();
        CreateMap<SectorDTO, Sector>();
    }
}

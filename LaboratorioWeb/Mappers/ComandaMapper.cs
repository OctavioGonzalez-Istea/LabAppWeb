//using Entidades;
//using LaboratorioWeb.DTO;

//public static class ComandaMapper
//{
//    // Convierte de entidad a DTO
//    public static ComandaDTO ToDTO(Comanda comanda)
//    {
//        return new ComandaDTO
//        {
//            ComandaId = comanda.ComandaId,
//            MesaId = comanda.MesaId,
//            NombreCliente = comanda.NombreCliente,
//            Pedidos = comanda.Pedidos.Select(p => ToDTO(p)).ToList()
//        };
//    }

//    // Convierte de DTO a entidad
//    public static Comanda ToEntity(ComandaDTO comandaDto, Mesa mesa, List<Pedido> pedidos)
//    {
//        return new Comanda
//        {
//            ComandaId = comandaDto.ComandaId,
//            MesaId = comandaDto.MesaId,
//            NombreCliente = comandaDto.NombreCliente,
//            Mesa = mesa,
//            Pedidos = pedidos
//        };
//    }

//    // Convierte de entidad Pedido a DTO
//    public static PedidoDTO ToDTO(Pedido pedido)
//    {
//        return new PedidoDTO
//        {
//            PedidoId = pedido.PedidoId,
//            ComandaId = pedido.ComandaId,
//            ProductoId = pedido.Producto.ProductoId,
//            ProductoDescripcion = pedido.Producto.Descripcion,
//            Cantidad = pedido.Cantidad,
//            EstadoId = pedido.EstadoPedido.EstadoId,
//            EstadoDescripcion = pedido.EstadoPedido.Descripcion,
//            FechaCreacion = pedido.FechaCreacion,
//            FechaFinalizacion = pedido.FechaFinalizacion
//        };
//    }

//    // Convierte de DTO Pedido a entidad
//    public static Pedido ToEntity(PedidoDTO pedidoDto, Comanda comanda, Producto producto, EstadoPedido estadoPedido)
//    {
//        return new Pedido
//        {
//            PedidoId = pedidoDto.PedidoId,
//            ComandaId = pedidoDto.ComandaId,
//            Comanda = comanda,
//            ProductoId = pedidoDto.ProductoId,
//            Producto = producto,
//            Cantidad = pedidoDto.Cantidad,
//            EstadoId = pedidoDto.EstadoId,
//            EstadoPedido = estadoPedido,
//            FechaCreacion = pedidoDto.FechaCreacion,
//            FechaFinalizacion = pedidoDto.FechaFinalizacion
//        };
//    }

//    // Convierte de entidad Mesa a DTO
//    public static MesaDTO ToDTO(Mesa mesa)
//    {
//        return new MesaDTO
//        {
//            MesaId = mesa.MesaId,
//            Nombre = mesa.Nombre,
//            EstadoId = mesa.EstadoMesa.EstadoId,
//            EstadoDescripcion = mesa.EstadoMesa.Descripcion
//        };
//    }

//    // Convierte de DTO Mesa a entidad
//    public static Mesa ToEntity(MesaDTO mesaDto, EstadoMesa estadoMesa)
//    {
//        return new Mesa
//        {
//            MesaId = mesaDto.MesaId,
//            Nombre = mesaDto.Nombre,
//            EstadoId = mesaDto.EstadoId,
//            EstadoMesa = estadoMesa
//        };
//    }
//}

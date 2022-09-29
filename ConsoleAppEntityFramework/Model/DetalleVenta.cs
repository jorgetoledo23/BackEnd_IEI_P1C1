namespace ConsoleAppEntityFramework.Model
{
    public class DetalleVenta
    {
        public Guid Id { get; set; }
        public int Cantidad { get; set; }

        //FK Venta
        public Guid VentaId { get; set; }
        public Venta Venta { get; set; }

        //FK Producto
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }


    }
}

namespace ConsoleAppEntityFramework.Model
{
    public class Venta
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Total { get; set; }
        public int IVA { get; set; }


        //FK Foreign Key
        public string ClienteRut { get; set; }
        public Cliente Cliente { get; set; }

        //Fk
        public List<DetalleVenta> DetalleVenta { get; set; }

    }
}

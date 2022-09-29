using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEntityFramework.Model
{
    public class Cliente
    {
        [Key]
        public string Rut { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        //Propiedad de Navegacion
        public List<Venta> Ventas { get; set; }

    }
}

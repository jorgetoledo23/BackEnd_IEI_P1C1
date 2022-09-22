using System.ComponentModel.DataAnnotations;

namespace ConsoleAppEntityFramework.Model
{
    public class Producto
    {
        //// Id ProductoId
        //[Key]
        //public string Rut { get; set; } // PK

        public int Id { get; set; }  //PK
        public string Name { get; set; }
        public int Precio{ get; set; }
        public int Stock{ get; set; }
        public string UrlImagen{ get; set; }

    }
}

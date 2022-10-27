using System.ComponentModel.DataAnnotations;

namespace WebApplication_MVC.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Precio { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public string UrlImagen { get; set; }
        [Required]
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}

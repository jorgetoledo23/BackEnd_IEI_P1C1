using System.ComponentModel.DataAnnotations;

namespace WebApplication_MVC.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Nombre es Requerido!")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "Descripcion es Requerido!")]
        public string Descripcion{ get; set; }
    }

}

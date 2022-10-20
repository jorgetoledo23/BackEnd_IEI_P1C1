namespace WebApplication_MVC.Models
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Stock { get; set; }
        public string UrlImagen { get; set; }


        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

    }
}

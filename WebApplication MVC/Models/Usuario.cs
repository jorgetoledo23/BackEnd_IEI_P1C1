namespace WebApplication_MVC.Models
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Rol { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

    }
}

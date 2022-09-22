using Microsoft.EntityFrameworkCore;

namespace ConsoleAppEntityFramework.Model
{
    public class AppDbContext : DbContext
    {

        public DbSet<Producto> tblProductos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BackEnd2022;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Producto>().HasKey(x => x.Rut);
        }



    }
}

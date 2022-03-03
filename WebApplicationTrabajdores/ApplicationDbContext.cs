using Microsoft.EntityFrameworkCore;
using WebApplicationTrabajdores.Entidades;

namespace WebApplicationTrabajdores
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }      
        public DbSet<Trabajador> Trabajadores { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }


    }
}

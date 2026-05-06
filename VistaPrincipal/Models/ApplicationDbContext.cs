using Microsoft.EntityFrameworkCore;

namespace VistaPrincipal.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<CarritoItem> CarritoItems { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VistaPrincipal.Controllers;
using VistaPrincipal.Models;

namespace VistaPrincipal.Data
{
    public class optimusDBContext : DbContext
    {

        
        public optimusDBContext(DbContextOptions<optimusDBContext> options)
            : base(options) { }

        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<LogAuditoria> LogAuditoria { get; set; }
        public DbSet<IntentoFallido> IntentosFallidos { get; set; }
    }
}
using Microsoft.EntityFrameworkCore;
using Nuevo_Proyecto.Model;

namespace Nuevo_Proyecto.Data
{

public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Store> Sales { get; set; }
    }
}

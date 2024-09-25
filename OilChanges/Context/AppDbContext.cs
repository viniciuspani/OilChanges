using Microsoft.EntityFrameworkCore;
using OilChanges.Shared.Model;
using System.Collections.Generic;

namespace OilChanges.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Oleo> Oleos { get; set; }
        public DbSet<Filtro> Filtros { get; set; }
        public DbSet<TrocaOleo> TrocaOleos { get; set; }
      
    }
}

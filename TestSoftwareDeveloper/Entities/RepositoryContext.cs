using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using TestSoftwareDeveloper.Entities.Models;

namespace TestSoftwareDeveloper.Entities
{
    public class RepositoryContext : DbContext
    {
       
        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "VentasDb");
        }
        public DbSet<Persona>? Personas { get; set; }
        public DbSet<Factura>? Facturas { get; set; }
    }
}

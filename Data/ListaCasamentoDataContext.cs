using System;
using Map.Data.Mappings;
using Maps.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Models.Pessoa;
using Models.Pessoa.Noivo;

namespace Data.Mappings
{
    public class ListaCasamentoDataContext : DbContext
    {
        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Noivo> Noivos { get; set; }
        public DbSet<Padrinho> Padrinho { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ListaCasamento;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConvidadosMap());
            modelBuilder.ApplyConfiguration(new NoivosMap());
            modelBuilder.ApplyConfiguration(new PadrinhosMap());

        }
    }
}
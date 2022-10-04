using Microsoft.EntityFrameworkCore;
using teste_payment_api.src.Models;

namespace teste_payment_api.src.Context
{
    public class TesteVendasContext : DbContext
    {
        public TesteVendasContext(DbContextOptions<TesteVendasContext> options): base(options){

        }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){

            builder.Entity<Vendedor>(tabela =>{
                tabela.HasKey(x => x.Id);
                tabela
                    .HasMany(x => x.Vendas)
                    .WithOne()
                    .HasForeignKey(x => x.VendedorId);
            });

            builder.Entity<Venda>(tabela =>{
                tabela.HasKey(x => x.Id);
            });

        }
    }
}
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
    }
}
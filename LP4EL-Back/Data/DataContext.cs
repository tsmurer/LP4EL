using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Hospital> hospitais { get; set; }
        public DbSet<Doacao> doacoes { get; set; }
        public DbSet<Produto> produtos { get; set; }
        public DbSet<ProdutoResgatado> produtosResgatados {get; set;}
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        
    }
}
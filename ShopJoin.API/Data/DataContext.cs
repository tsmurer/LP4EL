using Microsoft.EntityFrameworkCore;
using ShopJoin.API.Models;

namespace ShopJoin.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        
    }
}
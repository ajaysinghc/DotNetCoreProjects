using FoodApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodApp.Data
{
    public class FoodAppDbContext : DbContext
    {
        public FoodAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurant { get; set; }
    }
}

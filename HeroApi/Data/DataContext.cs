using Microsoft.EntityFrameworkCore;
using HeroApi.Entities;

namespace HeroApi.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        public DbSet<Hero> Heroes { get; set; }
    }
}

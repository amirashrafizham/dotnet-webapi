using Microsoft.EntityFrameworkCore;
using rpgTest_2.Models;

namespace rpgTest_2.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Character> Characters { get; set; }
    }
}
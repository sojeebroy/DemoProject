using DempProect.Models;
using Microsoft.EntityFrameworkCore;


namespace DempProect.Database
{
    public class DemoProjectDbContext : DbContext
    {
        public DemoProjectDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }

    }
}

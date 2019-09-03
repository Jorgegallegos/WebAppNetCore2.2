using Microsoft.EntityFrameworkCore;
using WebAppNetCore2._2.Entities;

namespace WebAppNetCore2._2.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options)
            : base(options)
        {
        }


        public DbSet<Developer> Developers { get; set; }
    }
}

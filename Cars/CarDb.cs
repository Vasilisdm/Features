using Microsoft.EntityFrameworkCore;

namespace Cars
{
    public class CarDb : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Cars.db");
    }
}
 
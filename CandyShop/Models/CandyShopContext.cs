using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Candy.Models
{
  public class CandyShopContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Treat> Treats { get; set; }
    public DbSet<Flavor> Flavors { get; set; }
    public DbSet<FlavorTreat> FlavorTreats { get; set; }
    public CandyShopContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      builder.Entity<Treat>()
      .HasData(
        new Treat { TreatId = 1, Name = "Snickers", Description = "Made With Rich Chocolate, Silky Caramel, Chewy Nougat & Packed With Crunchy Nutty Goodness." },
        new Treat { TreatId = 2, Name = "Reese's", Description = "American candy by The Hershey Company consisting of a peanut butter cup encased in chocolate" },
        new Treat { TreatId = 3, Name = "KitKat", Description = "Made of three layers of wafer separated and covered by an outer layer of chocolate" },
        new Treat { TreatId = 4, Name = "Haribo", Description = "Small, fruit gum candies, similar to a jelly baby in some English-speaking countries"}
      );
    }
  }
}
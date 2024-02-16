using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Candy.Models
{
  public class CandyShopContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Treat> Treats { get; set; }
    public CandyShopContext(DbContextOptions options) : base(options) { }
  }
}
using Microsoft.EntityFrameworkCore;

namespace Candy.Models
{
  public class CandyShopContext : IdentityDbContext<ApplicationUser>
  {
    public CandyShopContext(DbContextOptions options) : base(options) { }
  }
}
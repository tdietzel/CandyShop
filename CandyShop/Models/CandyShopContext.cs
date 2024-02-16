using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Candy.Models
{
  public class CandyShopContext : IdentityDbContext<ApplicationUser>
  {
    public CandyShopContext(DbContextOptions options) : base(options) { }
  }
}
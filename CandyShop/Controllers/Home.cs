using Microsoft.AspNetCore.Mvc;
using Candy.Models;

namespace Candy.Controllers
{
  public class HomeController : Controller
  {
    private readonly CandyShopContext _db;
    public HomeController(CandyShopContext db)
    {
      _db = db;
    }

    [Route("/")]
    public ActionResult Index() { return View(); }
  }
}
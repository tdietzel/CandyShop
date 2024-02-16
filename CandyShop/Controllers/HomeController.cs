using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
    public ActionResult Index() {
      Treat[] treats = _db.Treats.ToArray();
      Flavor[] flavors = _db.Flavors.ToArray();

      Dictionary<string, object[]> model = new Dictionary<string, object[]>();

      model.Add("treats", treats);
      model.Add("flavors", flavors);

      return View(model);
    }
  }
}
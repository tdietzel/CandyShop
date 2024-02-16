using Microsoft.AspNetCore.Mvc;
using Candy.Models;

namespace Candy.Controllers
{
  public class TreatController : Controller
  {
    private readonly CandyShopContext _db;
    public TreatController(CandyShopContext db)
    {
      _db = db;
    }

    public ActionResult Index() { return View(); }
  }
}
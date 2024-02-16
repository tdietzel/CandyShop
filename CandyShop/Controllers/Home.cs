using Microsoft.AspNetCore.Mvc;
using Candy.Models;

namespace Candy.Controllers
{
  public class HomeController : Controller
  {
    [Route("/")]
    public string Home() { return View(); }
  }
}
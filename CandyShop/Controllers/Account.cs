using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Candy.Models;
using Candy.ViewModels;

namespace Candy.Controllers
{
  public class AccountController : Controller
  {
    private readonly CandyShopContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    public AccountController(CandyShopContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
      _db = db;
      _userManager = userManager;
      _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        ApplicationUser user = new ApplicationUser { UserName = model.Email };
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Home");
        }
        else
        {
          foreach (IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
          return View(model);
        }
      }
    }
    public IActionResult Register() { return View(); }
  }
}
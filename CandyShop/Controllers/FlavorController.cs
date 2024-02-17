using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using Candy.Models;

namespace Candy.Controllers
{
  public class FlavorController : Controller
  {
    private readonly CandyShopContext _db;
    public FlavorController(CandyShopContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Flavors.ToList());
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }
    [Authorize]
    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Detail(int id)
    {
      Flavor selectedFlavor = _db.Flavors
        .Include(e => e.JoinEntities)
        .ThenInclude(join => join.Treat)
      .FirstOrDefault(e => e.FlavorId == id);

      return View(selectedFlavor);
    }

    [Authorize]
    public ActionResult Edit(int flavorId)
    {
      return View(_db.Flavors.Find(flavorId));
    }
    [Authorize]
    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Flavors.Update(flavor);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public ActionResult Delete(int flavorId)
    {
      Flavor selectedFlavor = _db.Flavors.Find(flavorId);
      _db.Flavors.Remove(selectedFlavor);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public ActionResult AddTreat(Flavor flavor, int treatId)
    {
      #nullable enable
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(j => j.TreatId == treatId && j.FlavorId == flavor.FlavorId);
      #nullable disable

      if (joinEntity == null && treatId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { TreatId = treatId, FlavorId = flavor.FlavorId });
        _db.SaveChanges();
      }

      return RedirectToAction("Detail", new { id = flavor.FlavorId });
    }
    [Authorize]
    public ActionResult AddTreat(int id)
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");

      return View(_db.Flavors.Find(id));
    }

    [Authorize]
    [HttpPost]
    public ActionResult DeleteTreat(int joinId)
    {
      FlavorTreat joinEntry = _db.FlavorTreats.Find(joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}
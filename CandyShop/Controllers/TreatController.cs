using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
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

    public ActionResult Index()
    {
      return View(_db.Treats.ToList());
    }

    [Authorize]
    public ActionResult Create()
    {
      return View();
    }
    [Authorize]
    [HttpPost]
    public ActionResult Create(Treat treat)
    {
      _db.Treats.Add(treat);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    public ActionResult Detail(int id)
    {
      Treat selectedTreat = _db.Treats
        .Include(e => e.JoinEntities)
        .ThenInclude(join => join.Flavor)
      .FirstOrDefault(e => e.TreatId == id);

      return View(selectedTreat);
    }

    [Authorize]
    public ActionResult Edit(int treatId)
    {
      return View(_db.Treats.Find(treatId));
    }
    [Authorize]
    [HttpPost]
    public ActionResult Edit(Treat treat)
    {
      _db.Treats.Update(treat);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }
    
    [Authorize]
    [HttpPost]
    public ActionResult Delete(int treatId)
    {
      Treat selectedTreat = _db.Treats.Find(treatId);
      _db.Treats.Remove(selectedTreat);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }

    [Authorize]
    [HttpPost]
    public ActionResult AddFlavor(Treat treat, int flavorId)
    {
      #nullable enable
      FlavorTreat? joinEntity = _db.FlavorTreats.FirstOrDefault(j => j.FlavorId == flavorId && j.TreatId == treat.TreatId);
      #nullable disable

      if (joinEntity == null && flavorId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = flavorId, TreatId = treat.TreatId });
        _db.SaveChanges();
      }

      return RedirectToAction("Detail", new { id = treat.TreatId });
    }
    [Authorize]
    public ActionResult AddFlavor(int id)
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");

      return View(_db.Treats.Find(id));
    }

    [Authorize]
    [HttpPost]
    public ActionResult DeleteFlavor(int joinId)
    {
      FlavorTreat joinEntry = _db.FlavorTreats.Find(joinId);
      _db.FlavorTreats.Remove(joinEntry);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}
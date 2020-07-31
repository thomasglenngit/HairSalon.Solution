using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
        foreach(Stylist style in _db.Stylists)
        {
          if(style.Name == stylist.Name)
          {
            return RedirectToAction("Index");
          }
        }
        _db.Stylists.Add(stylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
        Stylist thisStylist = _db.Stylists.Include(stylist => stylist.Evaluations).FirstOrDefault(stylists => stylists.StylistId == id);
        return View(thisStylist); // Eager loading in a Lazy Loading context.
    }

    public ActionResult Edit(int id)
    {
        Stylist thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
        return View(thisStylist);
    }

    [HttpPost]
    public ActionResult Edit(Stylist stylist)
    {
        _db.Entry(stylist).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
        Stylist thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
        return View(thisStylist);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
        Stylist thisStylist = _db.Stylists.FirstOrDefault(stylists => stylists.StylistId == id);
        _db.Stylists.Remove(thisStylist);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
  public class EvaluationsController : Controller
  {
    private readonly HairSalonContext _db;

    public EvaluationsController(HairSalonContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult Create()
    {
      ViewBag.ClientId = new SelectList(_db.Clients, "ClientId", "Name");
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Evaluation evaluation)
    {
      _db.Evaluations.Add(evaluation);
      _db.SaveChanges();
      return RedirectToAction("Details", "Clients", new { id = evaluation.ClientId });
    }
  }
}
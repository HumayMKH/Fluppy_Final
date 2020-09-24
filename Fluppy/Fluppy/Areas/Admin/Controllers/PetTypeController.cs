using Fluppy.Areas.Admin.Filters;
using Fluppy.DAL;
using Fluppy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fluppy.Areas.Admin.Controllers
{
    [logout]
    public class PetTypeController : Controller
    {
        // GET: Admin/PetType
        FluppyContext db = new FluppyContext();
        public ActionResult Index()
        {
            List<PetType> petType = db.PetTypes.ToList();
            return View(petType);
        }

        //Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PetType petType)
        {
            if (ModelState.IsValid)
            {
                db.PetTypes.Add(petType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(petType);
        }

        //Admin/Category/Update
        public ActionResult Update(int id)
        {
            PetType petType = db.PetTypes.Find(id);
            if (petType == null)
            {
                return HttpNotFound();
            }
            return View(petType);
        }

        [HttpPost]
        public ActionResult Update(PetType petType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petType).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(petType);
        }

        //Admin/Category/Delete
        public ActionResult Delete(int id)
        {
            PetType petType = db.PetTypes.Find(id);
            if (petType == null)
            {
                return HttpNotFound();
            }
            db.PetTypes.Remove(petType);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
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
    public class PetSizeController : Controller
    {
        // GET: Admin/PetSize
        FluppyContext db = new FluppyContext();
        public ActionResult Index()
        {
            List<PetSize> size = db.PetSizes.ToList();
            return View(size);
        }



        //Admin/Position/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PetSize petSize)
        {
            if (ModelState.IsValid)
            {
                db.PetSizes.Add(petSize);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(petSize);
        }

        //Admin/Position/Update
        public ActionResult Update(int id)
        {
            PetSize size = db.PetSizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        [HttpPost]
        public ActionResult Update(PetSize size)
        {
            if (ModelState.IsValid)
            {
                db.Entry(size).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(size);
        }

        //Admin/Position/Delete
        public ActionResult Delete(int id)
        {
            PetSize size = db.PetSizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            db.PetSizes.Remove(size);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
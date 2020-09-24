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
    public class ProductCategoryController : Controller
    {
        // GET: Admin/ProductCategory
        FluppyContext db = new FluppyContext();
        public ActionResult Index()
        {
            List<ProductCategory> categories = db.ProductCategories.ToList();
            return View(categories);
        }

        //Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                db.ProductCategories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //Admin/Category/Update
        public ActionResult Update(int id)
        {
            ProductCategory category = db.ProductCategories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Update(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        //Admin/Category/Delete
        public ActionResult Delete(int id)
        {
            ProductCategory category = db.ProductCategories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            db.ProductCategories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
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
    public class HomeSocialController : Controller
    {
        // GET: Admin/HomeSocial

        FluppyContext db = new FluppyContext();
        public ActionResult Index()
        {
                List<HomeSocial> homeSocials = db.HomeSocials.Include("HomeSetting").Include("SocialType").ToList();
                return View(homeSocials);
        }

        //Admin/SocialCompany/Create
        public ActionResult Create()
        {
            ViewBag.Home = db.HomeSettings.ToList();
            ViewBag.SocialType = db.SocialTypes.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(HomeSocial homeSocial)
        {
                if (ModelState.IsValid)
                {
                    db.HomeSocials.Add(homeSocial);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            ViewBag.Home = db.HomeSettings.ToList();
            ViewBag.SocialType = db.SocialTypes.ToList();

            return View(homeSocial);
        }

        //Admin/SocialCompany/Update
        public ActionResult Update(int id)
        {
                HomeSocial homeSocial = db.HomeSocials.Find(id);

                if (homeSocial == null)
                {
                    return HttpNotFound();
                }
            ViewBag.Home = db.HomeSettings.ToList();
            ViewBag.SocialType = db.SocialTypes.ToList();

            return View(homeSocial);
        }

        [HttpPost]
        public ActionResult Update(HomeSocial homeSocial)
        {
                if (ModelState.IsValid)
                {
                    db.Entry(homeSocial).State = EntityState.Modified;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            ViewBag.Home = db.HomeSettings.ToList();
            ViewBag.SocialType = db.SocialTypes.ToList();

            return View(homeSocial);
        }

        //Admin/SocialCompany/Delete
        public ActionResult Delete(int id)
        {
                HomeSocial homeSocial = db.HomeSocials.Find(id);
                if (homeSocial == null)
                {
                    return HttpNotFound();
                }
                db.HomeSocials.Remove(homeSocial);
                db.SaveChanges();

                return RedirectToAction("Index");
        }
    }
}
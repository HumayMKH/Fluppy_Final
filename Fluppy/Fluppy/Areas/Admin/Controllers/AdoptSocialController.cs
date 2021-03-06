﻿using Fluppy.Areas.Admin.Filters;
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
    public class AdoptSocialController : Controller
    {
        // GET: Admin/AdoptSocial
        FluppyContext db = new FluppyContext();
        public ActionResult Index()
        {
            List<AdoptSocial> adoptSocials = db.AdoptSocials.Include("Adopt").Include("SocialType").ToList();
            return View(adoptSocials);
        }

        //Admin/SocialCompany/Create
        public ActionResult Create()
        {
            ViewBag.Adopt = db.Adopts.ToList();
            ViewBag.SocialType = db.SocialTypes.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(AdoptSocial adoptSocial)
        {
            if (ModelState.IsValid)
            {
                db.AdoptSocials.Add(adoptSocial);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Adopt = db.Adopts.ToList();
            ViewBag.SocialType = db.SocialTypes.ToList();

            return View(adoptSocial);
        }

        //Admin/SocialCompany/Update
        public ActionResult Update(int id)
        {
            AdoptSocial adoptSocial = db.AdoptSocials.Find(id);

            if (adoptSocial == null)
            {
                return HttpNotFound();
            }
            ViewBag.Adopt = db.Adopts.ToList();
            ViewBag.SocialType = db.SocialTypes.ToList();

            return View(adoptSocial);
        }

        [HttpPost]
        public ActionResult Update(AdoptSocial adoptSocial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adoptSocial).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Adopt = db.Adopts.ToList();
            ViewBag.SocialType = db.SocialTypes.ToList();

            return View(adoptSocial);
        }

        //Admin/SocialCompany/Delete
        public ActionResult Delete(int id)
        {
            AdoptSocial adoptSocial = db.AdoptSocials.Find(id);
            if (adoptSocial == null)
            {
                return HttpNotFound();
            }
            db.AdoptSocials.Remove(adoptSocial);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
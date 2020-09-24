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
    public class GenderController : Controller
    {
        // GET: Admin/Gender
        FluppyContext db = new FluppyContext();
        public ActionResult Index()
        {
            List<Gender> gender = db.Genders.ToList();
            return View(gender);
        }

        

        //Admin/Position/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Genders.Add(gender);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(gender);
        }

        //Admin/Position/Update
        public ActionResult Update(int id)
        {
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            return View(gender);
        }

        [HttpPost]
        public ActionResult Update(Gender gender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gender).State = EntityState.Modified;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gender);
        }

        //Admin/Position/Delete
        public ActionResult Delete(int id)
        {
            Gender gender = db.Genders.Find(id);
            if (gender == null)
            {
                return HttpNotFound();
            }
            db.Genders.Remove(gender);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
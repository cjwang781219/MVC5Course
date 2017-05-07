﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : Controller
    {

        private FabricsEntities db = new FabricsEntities();
        // GET: EF
        public ActionResult Index()
        {
            var all = db.Product.AsQueryable();
            var data = db.Product.Where(p => p.Active == true && p.ProductName.Contains("Black"));
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product prodect)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(prodect);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var prodect = db.Product.Find(id);
            return View(prodect);
        }

        [HttpPost]
        public ActionResult Edit(int id,Product prodect)
        {
            if (ModelState.IsValid)
            {
                var item = db.Product.Find(id);
                item.ProductName = prodect.ProductName;
                item.Price = prodect.Price;
                item.Stock = prodect.Stock;
                item.Active = prodect.Active;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prodect);
        }

        public ActionResult Delete(int id)
        {
            var item = db.Product.Find(id);
            db.Product.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
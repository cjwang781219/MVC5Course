﻿using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EFController : BaseController
    {
        
        // GET: EF
        public ActionResult Index()
        {
            var all = db.Product.AsQueryable();
            var data = db.Product.Where(p => p.Active == true && p.Is刪除 == false).OrderByDescending(p=>p.ProductId).Take(20);
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
                return RedirectToAction("Index");
            }
            return View(prodect);
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
            var prodect = db.Product.Find(id);

            //foreach (var item in prodect.OrderLine)
            //{
            //    db.OrderLine.Remove(item);
            //}
            //db.OrderLine.RemoveRange(prodect.OrderLine);

            //db.Product.Remove(prodect);
            prodect.Is刪除 = true;
            try
            {

                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Detail(int id)
        {
            //var Prodect = db.Product.Find(id);
            var Prodect = db.Database.SqlQuery<Product>("select * from dbo.Product where productid = @p0",id).FirstOrDefault();
            return View(Prodect);
        }
    }
}
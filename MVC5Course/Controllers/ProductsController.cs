﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;
using MVC5Course.Models.ViewModels;
using MVC5Course.Models.QueryModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        ProductRepository repo = RepositoryHelper.GetProductRepository();
        //private FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index(bool? Active = true)
        {
            var data = repo.All().Where(p=>p.Active.HasValue && p.Active == Active).OrderByDescending(p => p.ProductId).Take(10);
            
            return View(data);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.getProductByID(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HandleError(ExceptionType = typeof(DbUpdateException),View = "Error_DbUpdateException")]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            //if (ModelState.IsValid)
            //{
            //    repo.Add(product);
            //    repo.UnitOfWork.Commit();
            //    //db.Product.Add(product);
            //    //db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            
            //模擬錯誤訊息
            //if (ModelState.IsValid)
            {
                repo.Add(product);
                repo.UnitOfWork.Commit();
                //db.Product.Add(product);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Product product = db.Product.Find(id);
            Product product = repo.getProductByID(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,FormCollection formcollects)
        {
            //[Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product
            //if (ModelState.IsValid)
            //{
            //    repo.Edit(product);
            //    repo.UnitOfWork.Commit();
            //    //db.Entry(product).State = EntityState.Modified;
            //    //db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            var product = repo.getProductByID(id);
            //只針對特定欄位做modl binding
            if (TryUpdateModel(product,new string[] { "ProductId", "ProductName", "Price", "Active", "Stock" }))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = repo.getProductByID(id.Value);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Product product = repo.getProductByIDd(id);
            //db.Product.Remove(product);
            //db.SaveChanges();
            Product product = repo.getProductByID(id);
            repo.Delete(product);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        public ActionResult ListProdects(ListProdectsQM qm)
        {
            //var data = db.Product.Where(p => p.Active == true).OrderByDescending(p => p.ProductId)
            //    .Select(x => new ProdectLiteVM() {
            //        ProductId = x.ProductId,
            //        ProductName = x.ProductName,
            //        Price = x.Price,
            //        Stock = x.Stock
            //    }).Take(10);
            ViewBag.test1 = "test1";
            ViewData["test2"] = "test2";
            var data2 = repo.getProductList();
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(qm.q))
                {
                    data2 = data2.Where(x => x.ProductName.Contains(qm.q));
                }
                data2 = data2.Where(x => x.Stock >= qm.Stock_s && x.Stock <= qm.Stock_e);
                //var data = repo.getProductList();
                
            }
            var data = data2.Select(x => new ProdectLiteVM()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                Stock = x.Stock
            }).Take(10);
            return View(data);
        }
        
        public ActionResult CreateProtect()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProtect(ProdectLiteVM data)
        {
            if(ModelState.IsValid)
            {
                TempData["successMsg"] = "新增成功";
                
                return RedirectToAction("ListProdects");
            }
            //驗證失敗 繼續顯示原頁面
            return View();
        }
    }
}

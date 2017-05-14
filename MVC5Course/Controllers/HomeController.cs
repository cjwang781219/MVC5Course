using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Unknow()
        {
            return View();
        }
        
        //[SharedViewBag]
        [SharedViewBag(MyProperty ="Test Hello world")]
        public ActionResult About()
        {
            //移至Attribute裡
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult PartialAbout()
        {
            if (Request.IsAjaxRequest())
            {
                //模擬AJAX
                //$.get('/Home/PartialAbout',function(data){ alert(data) });
                return PartialView("About");
            }
            return View("About");
        }

        public ActionResult ContentAction()
        {
            return PartialView("SuccessReduirect", "/");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult getFile()
        {
            return File(Server.MapPath("~/Content/news.png"), "image/png","newsPicture.png");
        }

        public ActionResult getJSON()
        {
            //關閉延遲載入不然會錯
            db.Configuration.LazyLoadingEnabled = false;
            //模擬jquery get json
            // $.get('Home/getJSON',function(data){console.log(data)});
            return Json(db.Product.Take(3),JsonRequestBehavior.AllowGet);
        }
    }
}
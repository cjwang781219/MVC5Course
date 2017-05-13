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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

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
    }
}
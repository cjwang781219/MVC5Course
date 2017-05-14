using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    [HandleError(ExceptionType = typeof(DbEntityValidationException), View = "Error_DbEntityValidationException")]
    public abstract class BaseController : Controller
    {
        protected FabricsEntities db = new FabricsEntities();

        [LocalOnly]
        public ActionResult Debug()
        {
            return Content("Debug");
        }

        //找不到action時 所做的特定處理，一般不建議做
        //protected override void HandleUnknownAction(string actionName)
        //{
        //    RedirectToAction("Index","Home").ExecuteResult(ControllerContext);
        //}
    }
}
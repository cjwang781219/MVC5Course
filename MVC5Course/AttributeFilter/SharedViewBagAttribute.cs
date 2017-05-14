using System;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class SharedViewBagAttribute : ActionFilterAttribute
    {
        //可自訂傳入參數（固定值）
        public string MyProperty { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.Message = string.IsNullOrEmpty(MyProperty)?"Your application description page.":MyProperty;
        }
    }
}
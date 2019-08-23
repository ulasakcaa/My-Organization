using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOrgViewer.MyActionFilters
{
    public class ActionRightAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Session["User"] == null)
            {
                filterContext.RequestContext.HttpContext.Response.Redirect("/Home/Login",true);
                
            }
        }
    }
}
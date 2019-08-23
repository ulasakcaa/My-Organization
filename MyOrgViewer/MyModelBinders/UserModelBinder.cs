using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOrgViewer.MyModelBinders
{
    public class UserModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            
            if (controllerContext.RequestContext.HttpContext.Request.QueryString["UserID"] == null)
                return base.BindModel(controllerContext, bindingContext);

            MyOrganizationEntities ctx = new MyOrganizationEntities();
            UserRepository rep = new UserRepository(ctx);

            int UserId = Convert.ToInt32(controllerContext.RequestContext.HttpContext.Request.QueryString["UserID"]);
            User usr = rep.Get(UserId);
            
            return usr;
        }
    }
}
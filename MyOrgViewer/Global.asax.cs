using Autofac;
using Autofac.Integration.Mvc;
using DataAccessLayer;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using MyOrgViewer.Controllers;
using MyOrgViewer.MyControllerFactories;
using MyOrgViewer.MyModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MyOrgViewer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new MyOrganizationEntities())
                            .InstancePerLifetimeScope();
          
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<OrganizationRepository>().As<IOrganizationRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ImageRepository>().As<IImageRepository>().InstancePerLifetimeScope();

            builder.RegisterType<OrgImageRepository>().As<IImageOrgRepository>().InstancePerLifetimeScope();

            builder.RegisterType<OrgUserRepository>().As<IOrgUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<testRepository>().As<ITestRepository>().InstancePerLifetimeScope();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //builder.RegisterType<HomeController>().InstancePerRequest();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

         //   ControllerBuilder.Current.SetControllerFactory(new MyControllerFactory());

            ModelBinders.Binders.Add(typeof(User), new UserModelBinder());
          //  ModelBinders.Binders.Add(typeof(StudentUIModel), new StudentModelBinder())
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //if (HttpContext.Current.Request.Url.ToString().ToUpper().Contains("HTTP") 
            //    && !HttpContext.Current.Request.Url.ToString().ToUpper().Contains("HTTPS")
            //    )
            //    HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString().Replace("http", "https"));
        }
    }
}

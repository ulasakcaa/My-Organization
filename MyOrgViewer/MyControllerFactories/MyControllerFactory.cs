using DataAccessLayer;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using MyOrgViewer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyOrgViewer.MyControllerFactories
{
    public class MyControllerFactory:DefaultControllerFactory
    {
        static IUserRepository repuser;
        static IOrganizationRepository repOrg;
        static IImageRepository repImg;
        static IOrgUserRepository orgUserRepository;
        static IImageOrgRepository orgImagerep;
        static MyOrganizationEntities ctx;
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (ctx == null)
                ctx = new MyOrganizationEntities();

            if(repuser==null)
             repuser = new UserRepository(ctx);

            if (repOrg == null)
                repOrg = new OrganizationRepository(ctx);

            if (repImg == null)
                repImg = new ImageRepository(ctx);

            if (orgImagerep == null)
                orgImagerep = new OrgImageRepository(ctx);

            if(orgUserRepository == null)
            orgUserRepository = new OrgUserRepository(ctx);

            //if (controllerName == "Home")
            //{
            //    return new HomeController(repuser,repOrg,orgImagerep);
            //}
            //if (controllerName == "Organization")
            //{
            //    return new OrganizationController(repOrg, repImg, repuser, orgUserRepository, orgImagerep,new testRepository());
            //}

            return base.CreateController(requestContext, controllerName);
        }
    }
}
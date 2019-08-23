using DataAccessLayer.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOrgViewer.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        IUserRepository _repUser;
        IOrganizationRepository _orgRep;
        ITestRepository _testRepo;
        public UserController(IUserRepository repuser, IOrganizationRepository orgRep, ITestRepository testRepository)
        {
            _repUser = repuser;
            _orgRep = orgRep;
            _testRepo = testRepository;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
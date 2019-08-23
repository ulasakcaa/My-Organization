using DataAccessLayer;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using MyOrgViewer.ActionFilters;
using MyOrgViewer.Models;
using MyOrgViewer.MyActionFilters;
using MyOrgViewer.MyReusltTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOrgViewer.Controllers
{
    public class HomeController : Controller
    {
        IUserRepository _userRepository;
        IOrganizationRepository _orgRepo;
        public HomeController(IUserRepository userRepository, IOrganizationRepository orgRepo, IImageOrgRepository imageRep)
        {
            _userRepository = userRepository;
            _orgRepo = orgRepo;
        }

        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginItem lg)
        {
            if (!ModelState.IsValid)
                return View(lg);
            
            var userEntity= _userRepository.List().Where(c => c.UserName == lg.UserName && c.Password == lg.Password).FirstOrDefault();

            if (userEntity == null)
            {
                ModelState.AddModelError("hatali", "User name or Password is wrong");
                return View(lg);
             }

            Session["User"] = userEntity;

            return  RedirectToAction("UserList");
        }

        public CustomResult About()
        {
            ViewBag.Message = "Your application description page.";

            return new CustomResult();
        }

        [MyActionFilter]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ActionRight]
        public ActionResult UserList()
        {
            List<User> model = _userRepository.List();
            return View(model);
        }
        
        [HttpGet]
        public ActionResult Edit(User usr)
        {
            return View(usr);
        }

        [HttpPost]
        public ActionResult EditUser(User usr)
        {

            return View(usr);
        }
    }
}
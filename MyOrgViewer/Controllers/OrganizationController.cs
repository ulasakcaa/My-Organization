using DataAccessLayer;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using MyOrgViewer.Models;
using MyOrgViewer.MyActionFilters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOrgViewer.Controllers
{
    public class OrganizationController : Controller
    {
        private IOrganizationRepository _organizationRepository;
        private IImageRepository _imageRepository;
        private IUserRepository _userRepository;
        private IOrgUserRepository _orgUserrepository;
        private IImageOrgRepository _orgImageRepository;
        private ITestRepository _testrep;
        public OrganizationController(IOrganizationRepository orgRepository, IImageRepository imageRepository, IUserRepository userRepository, IOrgUserRepository orgUserrepository
            ,IImageOrgRepository orgImageRepository, ITestRepository testrep
            )
        {
            _organizationRepository = orgRepository;
            _imageRepository = imageRepository;
            _userRepository = userRepository;
            _orgUserrepository = orgUserrepository;
            _orgImageRepository = orgImageRepository;

            _testrep = testrep;
        }

        // GET: Organization
        public ActionResult Index()
        {
            OrgTitle model = new OrgTitle();
            model.Baslik = ConfigurationManager.AppSettings["OrgTitle"];
            model.AltBaslik = ConfigurationManager.AppSettings["OrgTitleAlt"];
            return View(model);
        }

        [ActionRight]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionRight]
        public ActionResult Add(Organization org)
        {
            if (Request.Files.Count <= 0)
            {
                ModelState.AddModelError("ImageValidation", "Image seçilmedir");
            }
            if (Request.Files[0].ContentLength<=0)
            {
                ModelState.AddModelError("ImageValidation", "Image seçilmedir");
            }


            if (!ModelState.IsValid)
            {
                return View(org);
            }

            Images image = new Images();
            image.imageUrl = Request.Files[0].FileName;
            _imageRepository.Add(image);

            var imagePath = ConfigurationManager.AppSettings["ImagePath"] + "/" + image.Id + "_" + image.imageUrl;

            Request.Files[0].SaveAs(imagePath);

            org.MainImageId = image.Id;
            org.Organizer = ((User)Session["User"]).Id;
          
            _organizationRepository.Add(org);
            
            return RedirectToAction("Index");
        }

        public PartialViewResult ListOrgs()
        {
            List<Organization> orgList = _organizationRepository.List();

            return PartialView(orgList);
        }


        [ActionRight]
        public ActionResult Detail(int id)
        {
            Organization model = _organizationRepository.Get(id);

            #region 1.way to get only not selected users
            ViewData["AllUsers"] = _userRepository.List().Where(c => !model.OrgUser.Any(x => x.UserId == c.Id)).ToList();
            #endregion

            #region  2.way to get only not selected users
            //List<User> tumUSer = _userRepository.List();
            //List<User> filteredUSer = new List<User>();
            //foreach (var usr in tumUSer)
            //{
            //    if(model.OrgUser.Where(c=>c.UserId==usr.Id).Count()<=0)
            //    {
            //        filteredUSer.Add(usr);
            //    }

            //}
            //ViewData["AllUsers"] = filteredUSer;
            #endregion

            return View(model);
        }

        public ActionResult AddMember(int selectedUser,int orgId)
        {
            OrgUser orgUser = new OrgUser();
            orgUser.OrgId = orgId;
            orgUser.UserId = selectedUser;
           
            _orgUserrepository.Add(orgUser);

            return RedirectToAction("Detail", new { id = orgId });
        }

        public ActionResult AddImage(int orgId)
        {
            Images img = new Images();
            img.imageUrl = Request.Files[0].FileName;
            _imageRepository.Add(img);

            string imagePath= ConfigurationManager.AppSettings["ImagePath"] + "/" + img.Id + "_" + img.imageUrl;

            Request.Files[0].SaveAs(imagePath);

            OrgImage orgimage = new OrgImage();
            orgimage.ImageId = img.Id;
            orgimage.OrgId = orgId;
            _orgImageRepository.Add(orgimage);


            return RedirectToAction("Detail", new { id = orgId });

        }

        public JsonResult deleteImage(int imageId)
        {
            OrgImage orgImage = _orgImageRepository.List().Where(c => c.ImageId == imageId).FirstOrDefault();

            _orgImageRepository.Delete(orgImage.Id);

            _imageRepository.Delete(imageId);

            return new JsonResult() { Data = "silindi çok pis" };
        }



        public ActionResult removeUser(int id,int orgId)
        {
            _orgUserrepository.Delete(id);


            return RedirectToAction("Detail", new { id = orgId });
        }

        public PartialViewResult MemberAdd()
        {
            return PartialView();
        }
    }
}
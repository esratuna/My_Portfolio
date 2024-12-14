using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: AdminLayout
        public ActionResult Layout()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }

        
        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutSidebar()
        {
            var email = Session["email"].ToString();
            var admin = db.Tbl_Admins.FirstOrDefault(x => x.Email == email);


            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.İmage = admin.ImageUrl;
            return PartialView();
        }
        public PartialViewResult AdminLayoutNavbar()
        {
            var email = Session["email"].ToString();
            var admin = db.Tbl_Admins.FirstOrDefault(x=>x.Email == email);


            ViewBag.nameSurname = admin.Name + " " + admin.Surname;
            ViewBag.İmage = admin.ImageUrl;
           

            return PartialView();
        }
        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutScripts()
        {
            return PartialView();
        }
    }
}
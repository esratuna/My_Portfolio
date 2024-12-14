using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultBanner()
        {
            var values = db.Tbl_Banners.Where(x=>x.IsShown==true ).ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultExpertise()
        {
            var values = db.Tbl_Expertises.ToList();
            return PartialView(values);
        }
            
        public PartialViewResult DefaultExperiance()
        {
            var values = db.Tbl_Experiances.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProjects()
        {
            var values = db.Tbl_Projects.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            // ViewBag ile sosyal medya verilerini gönderme
            List<Tbl_SocialsMedias> socialMedia = db.Tbl_SocialsMedias.ToList();
            ViewBag.SocialMedia = socialMedia;

            // İletişim bilgilerini model olarak gönderme
            var value = db.Tbl_Contacts.ToList();
            return PartialView(value);
        }

        [HttpPost]
        public ActionResult SendMessage(Tbl_Messages model)
        {
            if (ModelState.IsValid)
            {
                model.DataSent = DateTime.Now;
                model.IsRead = false;

                db.Tbl_Messages.Add(model);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(model);
        }
        public PartialViewResult DefaultAbout()
        {
            var values = db.Tbl_Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult DefaultEducation()
        {
            var value = db.Tbl_Educations.ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultTestimonials()
        {
            var value = db.Tbl_Testimonials.ToList();
            return PartialView(value);
        }

        public PartialViewResult DefaultContact()
        {
            var value = db.Tbl_Contacts.ToList();
            return PartialView(value);
        }

        public PartialViewResult Socials()
        {
            var value = db.Tbl_SocialsMedias.ToList();
            return PartialView(value);
        }
    }
}
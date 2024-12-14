using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class TestimonialsController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: Testimonials
        public ActionResult Index()
        {
            var value = db.Tbl_Testimonials.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateTestimonials()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonials(Tbl_Testimonials model)
        {
            db.Tbl_Testimonials.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonials (int id)
        {
            var value = db.Tbl_Testimonials.Find(id);
            db.Tbl_Testimonials.Remove(value);
            db.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonials (int id)
        {
            var value = db.Tbl_Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonials (Tbl_Testimonials model)
        {
            var value = db.Tbl_Testimonials.Find(model.TestimonalId);
            value.Title = model.Title;
            value.Comment = model.Comment;
            value.ImageUrl = model.ImageUrl;
            value.NameSurname = model.NameSurname;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class EducationController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        public ActionResult Index()
        {
            var education = db.Tbl_Educations.ToList();
            return View(education);
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = db.Tbl_Educations.Find(id);
            db.Tbl_Educations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]

        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEducation(Tbl_Educations model)

        {
            db.Tbl_Educations.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = db.Tbl_Educations.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEducation(Tbl_Educations model)
        {
            var value = db.Tbl_Educations.Find(model.EducationId);
            value.SchoolName = model.SchoolName;
            value.Description = model.Description;
            value.EndDate = model.EndDate;
            value.StartDate = model.StartDate;
            value.Degree = model.Degree;
            value.Department = model.Department;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        

    }
}
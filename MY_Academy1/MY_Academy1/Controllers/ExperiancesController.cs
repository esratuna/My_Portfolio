using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class ExperiancesController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: Experiances
        public ActionResult Index()
        {
            var values = db.Tbl_Experiances.ToList();
            return View(values);
        }

        public ActionResult DeleteExperiances(int id)
        {
            var value = db.Tbl_Experiances.Find(id);
            db.Tbl_Experiances.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateExperiances()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExperiances(Tbl_Experiances model)
        {
            db.Tbl_Experiances.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperiances(int id)
        {
            var value = db.Tbl_Experiances.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateExperiances(Tbl_Experiances model)
        {
            var value = db.Tbl_Experiances.Find(model.ExperianceId);
            value.CompanyName = model.CompanyName;
            value.StartDate = model.StartDate;
            value.EndDate = model.EndDate;
            value.Description = model.Description;
            value.Title = model.Title;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class ExpertiseController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: Expertise
        public ActionResult Index()
        {
            var value = db.Tbl_Expertises.ToList();
            return View(value);
        }

        public ActionResult DeleteExpertise(int id)
        {
            var value = db.Tbl_Expertises.Find(id);
            db.Tbl_Expertises.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreatExpertise()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatExpertise(Tbl_Expertises model)
        {
            db.Tbl_Expertises.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public ActionResult UpdateExpertise(int id)
        {
            var value = db.Tbl_Expertises.Find(id);
            return View(value); 
        }

        [HttpPost]
        public ActionResult UpdateExpertise(Tbl_Expertises model)
        {
            var value = db.Tbl_Expertises.Find(model.ExpertiseId);
            value.Title = model.Title;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();



        public ActionResult Index()
        {
            var values = db.Tbl_Categories.ToList();

            return View(values);
        }
        [HttpGet]
        public ActionResult CreatCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreatCategory(Tbl_Categories model)
        {
            db.Tbl_Categories.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = db.Tbl_Categories.Find(id);
            var projectExist = db.Tbl_Projects.Where(x => x.CategoryId == value.CategoryId).Any();
                if(projectExist)
            {

                TempData["CategoryDeleteError"] = "Bu kategoride ait proje vardır silemezsiniz";
                return RedirectToAction("Index");
            }
            db.Tbl_Categories.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.Tbl_Categories.Find(id);
            return View(value);
            
        }
        [HttpPost]
        public ActionResult UpdateCategory(Tbl_Categories model)
        {
            var value = db.Tbl_Categories.Find(model.CategoryId);
            value.CategoryName = model.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Category(int id)
        {
            
            return View("İndex");

        }

    }
}
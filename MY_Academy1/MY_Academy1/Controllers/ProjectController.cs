using Microsoft.Ajax.Utilities;
using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MY_Academy1.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
     
        

        private void CategoryDropDown()
        {
            var categoryList = db.Tbl_Categories.ToList();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString()
                                               }).ToList();
            ViewBag.Categories = categories;
        }
        
        public ActionResult Index()
        {
            var projects = db.Tbl_Projects.ToList();
            return View(projects);
        }

        //IList IEnumerable ICollection Lİst araştır aralarındaki fark ne?

        [HttpGet]
        public ActionResult CreateProject()
        {
            CategoryDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(Tbl_Projects model) 
        {



            CategoryDropDown();
            if (!ModelState.IsValid)
            {
                return View();
            }

           
            db.Tbl_Projects.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.Tbl_Projects.Find(id);
            db.Tbl_Projects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var value = db.Tbl_Projects.Find(id);
            return View(value);
        }
        [HttpPost]
        
        public ActionResult UpdateProject(Tbl_Projects model)
        {
            CategoryDropDown();
            var value = db.Tbl_Projects.Find(model.ProjectId);
            value.Name = model.Name;
            value.İmageUrl = model.İmageUrl;
            value.Description = model.Description;
            value.CategoryId = model.CategoryId;
            value.GithupUrl = model.GithupUrl;

            if (!ModelState.IsValid)
            {
                return View();
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        
    }
}
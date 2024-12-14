using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class SocialMediaController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities(); 
        // GET: SocialMedia
        public ActionResult Index()
        {
            var values = db.Tbl_SocialsMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tbl_SocialsMedias social_model)
        {
            db.Tbl_SocialsMedias.Add(social_model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var value = db.Tbl_SocialsMedias.Find(id);
            db.Tbl_SocialsMedias .Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var socialMedia = db.Tbl_SocialsMedias.Find(id);
            return View(socialMedia);
        }

        [HttpPost]
        public ActionResult Update(Tbl_SocialsMedias model)
        {
            var value = db.Tbl_SocialsMedias.Find(model.SocialMediaId);
            value.Name = model.Name;
            value.Url = model.Url;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
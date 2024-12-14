using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class BannerController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: Banner
        public ActionResult Index()

        {
            var values = db.Tbl_Banners.ToList();
            return View(values);
        }

        public ActionResult Show(int id)
        {

            var allBanners = db.Tbl_Banners.ToList();
            foreach (var banner in allBanners)
            {
                banner.IsShown = false;
            }


            var selectedBanner = db.Tbl_Banners.Find(id);
            if (selectedBanner != null)
            {
                selectedBanner.IsShown = true;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Banner/Delete/5
        public ActionResult Delete(int id)
        {
            var value = db.Tbl_Banners.Find(id);

            if (value != null)
            {

                int bannerCount = db.Tbl_Banners.Count();

                if (bannerCount <= 1)
                {

                    TempData["Message"] = "The last remaining banner cannot be deleted.";
                    return RedirectToAction("Index");
                }

                db.Tbl_Banners.Remove(value);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tbl_Banners banner)
        {
            if (ModelState.IsValid)
            {
                var allBanners = db.Tbl_Banners.ToList();
                foreach (var existingBanner in allBanners)
                {
                    existingBanner.IsShown = false;
                }

                banner.IsShown = true;
                db.Tbl_Banners.Add(banner);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(banner);
        }
    }
}
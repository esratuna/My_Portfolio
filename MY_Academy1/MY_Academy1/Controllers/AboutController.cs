using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: About
        public ActionResult Index()
        {
            var values = db.Tbl_Abouts.ToList();
            return View(values);
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var about = db.Tbl_Abouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult Update(Tbl_Abouts model)
        {
            var value = db.Tbl_Abouts.Find(model.AboutId);
            if (ModelState.IsValid)
            {
                // ImageFile işlemi
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    value.ImageUrl = "/images/" + model.ImageFile.FileName;
                }

                // CV dosyası işlemi
                if (model.CvFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var cvSaveLocation = currentDirectory + "cv\\";
                    if (!Directory.Exists(cvSaveLocation))
                    {
                        Directory.CreateDirectory(cvSaveLocation);
                    }

                    var cvFileName = Path.Combine(cvSaveLocation, model.CvFile.FileName);
                    model.CvFile.SaveAs(cvFileName);
                    model.CvUrl = "/cv/" + model.CvFile.FileName;  // Veritabanına kaydedilecek CV URL'si
                }

                // Güncellenen değerleri kaydet
                value.Title = model.Title;
                value.ImageUrl = model.ImageUrl;
                value.Description = model.Description;
                value.CvUrl = model.CvUrl; // CV URL'sini ekle
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }





    }
}
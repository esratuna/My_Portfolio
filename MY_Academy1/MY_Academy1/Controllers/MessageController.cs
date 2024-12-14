using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: Message
        public ActionResult Index()
        {
            var values = db.Tbl_Messages.Where(m => m.IsRead == false).ToList();
            return View(values);
        }

        public PartialViewResult Detaylar(int? id)
        {

            var value = db.Tbl_Messages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return PartialView(value);
        }

        [HttpPost]
        public ActionResult Okundu(int id)
        {
            var value = db.Tbl_Messages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MesajıOku()
        {
            var value = db.Tbl_Messages.Where(x => x.IsRead == true).ToList();
            return View(value);
        }
    }
}
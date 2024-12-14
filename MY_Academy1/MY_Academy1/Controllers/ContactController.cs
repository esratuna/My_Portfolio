using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: Contact
        public ActionResult Index()
        {
            var value = db.Tbl_Contacts.ToList();
            return View(value);
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = db.Tbl_Contacts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult Update(Tbl_Contacts model)
        {
            var value = db.Tbl_Contacts.Find(model.ContactId);
            if (ModelState.IsValid)
            {
                value.Email = model.Email;
                value.Phone = model.Phone;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);

        }
    }


    

    
}
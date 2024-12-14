using MY_Academy1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MY_Academy1.Controllers
{
    public class Banner1Controller : Controller
    {
        MyPortfolioDBEntities db = new MyPortfolioDBEntities();
        // GET: Banner1
        public ActionResult Index()
        {
            var value = db.Tbl_Banners.ToList();

            return View();
        }
    }
}
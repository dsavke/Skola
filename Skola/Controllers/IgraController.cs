using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skola.Controllers
{
    public class IgraController : Controller
    {
        // GET: Igra
        public ActionResult Index()
        {
            Random random = new Random();
            int nasumicanBroj = random.Next(1, 101);
            ViewBag.NasumicanBroj = nasumicanBroj;
            return View();
        }
    }
}
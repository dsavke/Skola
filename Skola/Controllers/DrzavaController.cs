using Skola.DbModels;
using Skola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace Skola.Controllers
{
    public class DrzavaController : Controller
    {
        // GET: Drzava
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            using (var context = new SkolaContext()) {

                var drzave = context.Drzavas.Select(d => new DrzavaViewModel() {
                    DrzavaId = d.DrzavaID,
                    Naziv = d.Naziv
                }).ToList();

                return PartialView("List", drzave);

            }
        }

        [HttpPost]
        public ActionResult Create(string naziv)
        {
            using(var context = new SkolaContext())
            {

                bool proslo = true;
                string poruka = "";

                if(naziv.Trim() == "")
                {
                    proslo = false;
                    poruka = "GRESKA: Morate unijeti naziv!";
                }else if(naziv.Length > 50)
                {
                    proslo = false;
                    poruka = "GRESKA: Naziv drzave je predugacak!";
                }
                else if (!Regex.IsMatch(naziv, @"[\p{L} ]+$"))
                {
                    proslo = false;
                    poruka = "GRESKA: Naziv drzave mora da se sastoji samo od slova!";
                }

                if (proslo)
                {
                    Drzava drzava = new Drzava() { Naziv = naziv };
                    context.Drzavas.Add(drzava);
                    context.SaveChanges();
                }

                return new JsonResult() { Data = new { Success = proslo, Message = poruka}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                int drzavaID = Convert.ToInt32(id);

                using (var context = new SkolaContext())
                {

                    var drzave = context.Drzavas.ToList();

                    context.Drzavas.Remove(context.Drzavas.Find(drzavaID));
                    context.SaveChanges();

                    return new JsonResult() { Data = new { Success = true }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                }
            }
            catch (Exception ex)
            {
                return new JsonResult() { Data = new { Success = false }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

        }

    }
}
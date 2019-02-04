using Skola.DbModels;
using Skola.HelperClass;
using Skola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skola.Controllers
{
    public class OdjeljenjeController : Controller
    {

        List<OdjeljenjeViewModel> Odjeljenja = new List<OdjeljenjeViewModel>();

        // GET: Odjeljenje
        public ActionResult Index()
        {
            using(var context = new SkolaContext())
            {
                var odjeljenje = context.Odjeljenjes.Select(o => new OdjeljenjeViewModel()
                {
                    OdjeljenjeId = o.OdjeljenjeId,
                    Razrednik = o.Razrednik,
                    Razred = o.Razred,
                    Naziv = o.Naziv,
                    SkolskaGodina = o.SkolskaGodina,
                    Ime = o.Nastavnik.Ime,
                    Prezime = o.Nastavnik.Prezime
                }).ToList();

                return View(odjeljenje);

            }
        }

        public ActionResult Create()
        {
            using (var context = new SkolaContext())
            {
                ViewBag.Razrednik = context.Nastavniks.Select(n => new SelectListItem()
                {
                    Text = n.Ime + " " + n.Prezime,
                    Value = "" + n.NastavnikId
                }).ToList();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(OdjeljenjeViewModel odjeljenje)
        {
            using(var context = new SkolaContext())
            {
                Odjeljenje o = new Odjeljenje()
                {
                    OdjeljenjeId = odjeljenje.OdjeljenjeId,
                    Razrednik = odjeljenje.Razrednik,
                    Razred = odjeljenje.Razred,
                    Naziv = odjeljenje.Naziv,
                    SkolskaGodina = odjeljenje.SkolskaGodina
                };
                context.Odjeljenjes.Add(o);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            using (var context = new SkolaContext())
            {
                int odjeljeneID = Convert.ToInt32(id);
                Odjeljenje o = context.Odjeljenjes.Find(odjeljeneID);
                OdjeljenjeViewModel odjeljenje = new OdjeljenjeViewModel()
                {
                    OdjeljenjeId = o.OdjeljenjeId,
                    Razrednik = o.Razrednik,
                    Razred = o.Razred,
                    Naziv = o.Naziv,
                    SkolskaGodina = o.SkolskaGodina
                };

                ViewBag.Razrendik = context.Nastavniks.Select(n => new SelectListItem()
                {
                    Text = n.Ime + " " + n.Prezime,
                    Value = "" + n.NastavnikId
                }).ToList();

                return View(odjeljenje);
            }
        }

        [HttpPost]
        public ActionResult Edit(OdjeljenjeViewModel odjeljenje)
        {
            using(var context = new SkolaContext())
            {
                Odjeljenje o = context.Odjeljenjes.Find(odjeljenje.OdjeljenjeId);
                o.OdjeljenjeId = odjeljenje.OdjeljenjeId;
                o.Razrednik = odjeljenje.Razrednik;
                o.Razred = odjeljenje.Razred;
                o.Naziv = odjeljenje.Naziv;
                o.SkolskaGodina = odjeljenje.SkolskaGodina;
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        { 
            using (var context = new SkolaContext())
            {
                int odjeljeneID = Convert.ToInt32(id);
                Odjeljenje o = context.Odjeljenjes.Find(odjeljeneID);
                OdjeljenjeViewModel odjeljenje = new OdjeljenjeViewModel()
                {
                    OdjeljenjeId = o.OdjeljenjeId,
                    Razrednik = o.Razrednik,
                    Razred = o.Razred,
                    Naziv = o.Naziv,
                    SkolskaGodina = o.SkolskaGodina
                };
                return View(odjeljenje);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using(var context = new SkolaContext())
            {
                if (context.Odjeljenjes.Find(id).Uceniks.Count == 0)
                {
                    context.Odjeljenjes.Remove(context.Odjeljenjes.Find(id));
                    context.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Ne mozes obrisati ovo odjeljenje!");
                    Odjeljenje o = context.Odjeljenjes.Find(id);
                    OdjeljenjeViewModel odjeljenje = new OdjeljenjeViewModel()
                    {
                        OdjeljenjeId = o.OdjeljenjeId,
                        Razrednik = o.Razrednik,
                        Razred = o.Razred,
                        Naziv = o.Naziv,
                        SkolskaGodina = o.SkolskaGodina
                    };
                    return View(odjeljenje);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
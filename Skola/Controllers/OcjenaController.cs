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
    public class OcjenaController : Controller
    {

        // GET: Ocjena
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            using (var context = new SkolaContext())
            {
                OcjenaViewModel ocjena = new OcjenaViewModel();
                ocjena.UcenikId = id;

                ViewBag.Nastavnici = context.Nastavniks.Select(n => new SelectListItem()
                {
                    Text = n.Ime + " " + n.Prezime,
                    Value = "" + n.NastavnikId
                }).ToList();

                ViewBag.Predmeti = context.Predmets.Select(p => new SelectListItem()
                {
                    Text = p.Naziv,
                    Value = "" + p.PredmetId
                }).ToList();

                return View(ocjena);
            }
        }

        [HttpPost]
        public ActionResult Create(OcjenaViewModel ocjena)
        {
            using (var context = new SkolaContext())
            {

                context.Ocjenes.Add(new Ocjene()
                {
                    OcjenaId = ocjena.OcjenaId,
                    UcenikId = ocjena.UcenikId,
                    Datum = ocjena.Datum,
                    VrijednostOcjene = ocjena.Vrijednost,
                    TipOcjene = (int)ocjena.TipOcjene,
                    Predmet = ocjena.Predmet,
                    Nastavnik = ocjena.Nastavnik
                });

                context.SaveChanges();
            }

            return RedirectToAction("Details", "Ucenik", new { id = ocjena.UcenikId });
        }

        public ActionResult Edit(string id)
        {
            using (var context = new SkolaContext())
            {
                int ocjenaID = Convert.ToInt32(id);
                Ocjene ocjena = context.Ocjenes.Find(ocjenaID);
                OcjenaViewModel o = new OcjenaViewModel()
                {
                    OcjenaId = ocjena.OcjenaId,
                    UcenikId = ocjena.UcenikId,
                    Datum = ocjena.Datum,
                    Vrijednost = ocjena.VrijednostOcjene,
                    TipOcjene = (TipOcjene)ocjena.TipOcjene,
                    Predmet = ocjena.Predmet,
                    Nastavnik = ocjena.Nastavnik
                };

                ViewBag.Nastavnici = context.Nastavniks.Select(n => new SelectListItem()
                {
                    Text = n.Ime + " " + n.Prezime,
                    Value = "" + n.NastavnikId
                }).ToList();

                ViewBag.Predmeti = context.Predmets.Select(p => new SelectListItem()
                {
                    Text = p.Naziv,
                    Value = "" + p.PredmetId
                }).ToList();

                return View(o);
            }
        }

        [HttpPost]
        public ActionResult Edit(OcjenaViewModel ocjena)
        {
            using(var context = new SkolaContext())
            {
                Ocjene o = context.Ocjenes.Find(ocjena.OcjenaId);
                o.OcjenaId = ocjena.OcjenaId;
                o.UcenikId = ocjena.UcenikId;
                o.Datum = ocjena.Datum;
                o.VrijednostOcjene = ocjena.Vrijednost;
                o.TipOcjene = (int)ocjena.TipOcjene;
                o.Predmet = ocjena.Predmet;
                o.Nastavnik = ocjena.Nastavnik;
                context.SaveChanges();
            }

            return RedirectToAction("Details", "Ucenik", new { id = ocjena.UcenikId });
        }

        public ActionResult Delete(string id)
        {
            using (var context = new SkolaContext())
            {
                int ocjenaID = Convert.ToInt32(id);
                Ocjene ocjena = context.Ocjenes.Find(ocjenaID);
                OcjenaViewModel o = new OcjenaViewModel()
                {
                    OcjenaId = ocjena.OcjenaId,
                    UcenikId = ocjena.UcenikId,
                    Datum = ocjena.Datum,
                    Vrijednost = ocjena.VrijednostOcjene,
                    TipOcjene = (TipOcjene)ocjena.TipOcjene,
                    Predmet = ocjena.Predmet,
                    Nastavnik = ocjena.Nastavnik
                };
                return View(o);
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            int ucenikID = 0;
            using (var context = new SkolaContext())
            {
                ucenikID = context.Ocjenes.Find(id).UcenikId;
                context.Ocjenes.Remove(context.Ocjenes.Find(id));
                context.SaveChanges();
                return RedirectToAction("Details", "Ucenik", new { id = ucenikID });
            }
        }

    }
}
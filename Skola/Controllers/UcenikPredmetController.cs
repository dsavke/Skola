using Skola.DbModels;
using Skola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skola.Controllers
{
    public class UcenikPredmetController : Controller
    {
        // GET: UcenikPredmet
        public ActionResult Index()
        {
            using (var context = new SkolaContext())
            {
                var ucenici = context.Uceniks.Select(u => new UcenikViewModel()
                {
                    Ime = u.Ime,
                    Prezime = u.Prezime,
                    Grad = u.Grad.Naziv,
                    Drzava = u.Grad.Drzava.Naziv,
                    NazivOdjeljena = u.Odjeljenje.Naziv,
                    UcenikId = u.UcenikID
                }).ToList();
                return View(ucenici);
            }
        }

        public ActionResult Details(string id)
        {
            int ucenikID = Convert.ToInt32(id);
            using (var context = new SkolaContext())
            {

                UcenikPredmetViewModel ucenik = context.Uceniks.Where(u => u.UcenikID == ucenikID).Select(u => new UcenikPredmetViewModel()
                {
                    Ime = u.Ime,
                    Prezime = u.Prezime,
                    UcenikID = u.UcenikID,
                    Predmeti = u.Ocjenes.Select(o => new PrdmetViewModel()
                    {
                        PredmetID = o.Predmet1.PredmetId,
                        Naziv = o.Predmet1.Naziv
                    }).Distinct().ToList()
                }).FirstOrDefault();

                return View(ucenik);
            }
        }

        public ActionResult GetOcjene(string ucenikID, string predmetID)
        {
            int UcenikID = Convert.ToInt32(ucenikID);
            int PredmetID = Convert.ToInt32(predmetID);

            using(var context = new SkolaContext())
            {
                var ucenik = context.Uceniks.Find(UcenikID);
                var ocjene = ucenik.Ocjenes.Where(o => o.Predmet1.PredmetId == PredmetID)
                    .Select(o => new OcjenaPredmetViewModel()
                    {
                        OcjenaID = o.OcjenaId,
                        DatumOcjene = o.Datum,
                        Vrijednost = o.VrijednostOcjene,
                        TipOcjene = (TipOcjene)o.TipOcjene
                    }).ToList();
                return PartialView("_OcjenePredmet", ocjene);
            }
        }

    }
}
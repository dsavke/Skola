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
    public class UcenikController : Controller
    {

        List<UcenikViewModel> Ucenici = new List<UcenikViewModel>();

        // GET: Ucenik
        public ActionResult Index()
        {
            using(var context = new SkolaContext())
            {
                var ucenici = context.Uceniks.Select(u => new UcenikViewModel()
                {
                    UcenikId = u.UcenikID,
                    Ime = u.Ime,
                    Prezime = u.Prezime,
                    Pol = u.Pol,
                    Jmbg = u.JMBG,
                    Adresa = u.Adresa,
                    DatumRodjenja = u.DatumRodjenja,
                    ImeRoditelja = u.ImeRoditelja,
                    BrojUDnevniku = u.BrojUDnevniku,
                    Drzavljanstvo = u.Drzavljanstvo,
                    Odjeljenje = u.OdjeljenjeId,
                    NazivOdjeljena = u.Odjeljenje.Naziv
                }).ToList();
                return View(ucenici);
            }
            
        }

        public ActionResult Create()
        {
            ViewBag.Pol = new List<String>{ "Musko", "Zensko"};

            using(var context = new SkolaContext())
            {
                ViewBag.Odjeljenja = context.Odjeljenjes.Select(o => new SelectListItem()
                {
                    Text = o.Naziv,
                    Value = "" + o.OdjeljenjeId
                }).ToList();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(UcenikViewModel ucenik)
        {
            using(var context = new SkolaContext())
            {
                context.Uceniks.Add(new Ucenik() { UcenikID = ucenik.UcenikId, Ime = ucenik.Ime, Prezime = ucenik.Prezime, Pol = ucenik.Pol,
                                JMBG = ucenik.Jmbg, Adresa = ucenik.Adresa, DatumRodjenja = ucenik.DatumRodjenja, ImeRoditelja = ucenik.ImeRoditelja,
                                BrojUDnevniku = ucenik.BrojUDnevniku, Drzavljanstvo = ucenik.Drzavljanstvo, OdjeljenjeId = ucenik.Odjeljenje });
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            int ucenikID = Convert.ToInt32(id);
            using (var context = new SkolaContext())
            {
                Ucenik ucenik = context.Uceniks.Where(u => u.UcenikID == ucenikID).FirstOrDefault();
                UcenikViewModel ucenikViewModel = new UcenikViewModel(){ UcenikId = ucenik.UcenikID, Ime = ucenik.Ime, Prezime = ucenik.Prezime, Pol = ucenik.Pol,
                    Jmbg = ucenik.JMBG, Adresa = ucenik.Adresa, DatumRodjenja = ucenik.DatumRodjenja, ImeRoditelja = ucenik.ImeRoditelja,
                                BrojUDnevniku = ucenik.BrojUDnevniku, Drzavljanstvo = ucenik.Drzavljanstvo, Odjeljenje = ucenik.OdjeljenjeId };

                ViewBag.Pol = new List<String> { "Musko", "Zensko" };

                ViewBag.Odjeljenja = context.Odjeljenjes.Select(o => new SelectListItem()
                {
                    Text = o.Naziv,
                    Value = "" + o.OdjeljenjeId
                }).ToList();

                return View(ucenikViewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(UcenikViewModel ucenik)
        {

            using(var context = new SkolaContext())
            {
                Ucenik uc = context.Uceniks.Find(ucenik.UcenikId);

                uc.UcenikID = ucenik.UcenikId;
                uc.Ime = ucenik.Ime;
                uc.Prezime = ucenik.Prezime;
                uc.Pol = ucenik.Pol;
                uc.JMBG = ucenik.Jmbg;
                uc.Adresa = ucenik.Adresa;
                uc.DatumRodjenja = ucenik.DatumRodjenja;
                uc.ImeRoditelja = ucenik.ImeRoditelja;
                uc.BrojUDnevniku = ucenik.BrojUDnevniku;
                uc.Drzavljanstvo = ucenik.Drzavljanstvo;
                uc.OdjeljenjeId = ucenik.Odjeljenje;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {

            int ucenikID = Convert.ToInt32(id);

            using (var context = new SkolaContext())
            {
                Ucenik ucenik = context.Uceniks.Where(u => u.UcenikID == ucenikID).FirstOrDefault();
                UcenikViewModel ucenikViewModel = new UcenikViewModel()
                {
                    UcenikId = ucenik.UcenikID,
                    Ime = ucenik.Ime,
                    Prezime = ucenik.Prezime,
                    Pol = ucenik.Pol,
                    Jmbg = ucenik.JMBG,
                    Adresa = ucenik.Adresa,
                    DatumRodjenja = ucenik.DatumRodjenja,
                    ImeRoditelja = ucenik.ImeRoditelja,
                    BrojUDnevniku = ucenik.BrojUDnevniku,
                    Drzavljanstvo = ucenik.Drzavljanstvo,
                    Odjeljenje = ucenik.OdjeljenjeId
                };

                return View(ucenikViewModel);

            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var context = new SkolaContext())
            {
                context.Uceniks.Remove(context.Uceniks.Find(id));
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(string id)
        {
            int ucenikID = Convert.ToInt32(id);
            using (var context = new SkolaContext())
            {
                Ucenik ucenik = context.Uceniks.Where(u => u.UcenikID == ucenikID).FirstOrDefault();
                UcenikViewModel ucenikViewModel = new UcenikViewModel()
                {
                    UcenikId = ucenik.UcenikID,
                    Ime = ucenik.Ime,
                    Prezime = ucenik.Prezime,
                    Pol = ucenik.Pol,
                    Jmbg = ucenik.JMBG,
                    Adresa = ucenik.Adresa,
                    DatumRodjenja = ucenik.DatumRodjenja,
                    ImeRoditelja = ucenik.ImeRoditelja,
                    BrojUDnevniku = ucenik.BrojUDnevniku,
                    Drzavljanstvo = ucenik.Drzavljanstvo,
                    Odjeljenje = ucenik.OdjeljenjeId,
                    NazivOdjeljena = ucenik.Odjeljenje.Naziv
                };

                ucenikViewModel.NazivOdjeljena = ucenik.Odjeljenje.Naziv;

                ViewBag.Ocjene = context.Ocjenes.Where(o => o.UcenikId == ucenikID).Select(o => new OcjenaViewModel()
                {
                    OcjenaId = o.OcjenaId,
                    UcenikId = o.UcenikId,
                    Datum = o.Datum,
                    Vrijednost = o.VrijednostOcjene,
                    TipOcjene = (TipOcjene)o.TipOcjene,
                    Predmet = o.Predmet,
                    Nastavnik = o.Nastavnik,
                    ImeNastavnika = o.Nastavnik1.Ime,
                    PrezimeNastavnika = o.Nastavnik1.Prezime,
                    NazivPredmeta = o.Predmet1.Naziv
                }).ToList();

                return View(ucenikViewModel);
            }

        }

    }
}
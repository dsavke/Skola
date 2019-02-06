using Skola.DbModels;
using Skola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skola.Controllers
{
    public class RandomUcenikController : Controller
    {
        // GET: RandomUcenik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetRandomUcenik()
        {

            using (var context = new SkolaContext()) {

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
                    NazivOdjeljena = u.Odjeljenje.Naziv,
                    Grad = u.Grad.Naziv,
                    Drzava = u.Grad.Drzava.Naziv
                }).ToList();

                Random random = new Random();
                int r = random.Next(0, ucenici.Count);

                return PartialView("_RandomUcenik", ucenici.ElementAt(r));

            }
        }

    }
}
using Skola.DbModels;
using Skola.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skola.Controllers
{
    public class StatistikaController : Controller
    {
  
        public ActionResult Index()
        {

            using (var context = new SkolaContext())
            {
                StatistikaViewModel statistika = new StatistikaViewModel();
                statistika.UkupanBrojUcenika = context.Uceniks.Count();

                statistika.Top3OdlicnihUcenika = context.Uceniks.ToList().OrderByDescending(o => vratiProsjek(o.Ocjenes.ToList()))
                    .Select(u => new Top3Ucenika
                    {
                        Ime = u.Ime,
                        Prezime = u.Prezime
                    }).ToList().Take(3).ToList();

                statistika.BrojOdlicnih = brojUcenika(context.Uceniks.ToList(), 5);
                statistika.BrojVrloDobrih = brojUcenika(context.Uceniks.ToList(), 4);
                statistika.BrojDobrih = brojUcenika(context.Uceniks.ToList(), 3);
                statistika.BrojDovoljnih = brojUcenika(context.Uceniks.ToList(), 2);
                statistika.BrojNedovoljnih = brojUcenika(context.Uceniks.ToList(), 1);

                statistika.OdlicnihOdjeljenjes = context.Odjeljenjes.ToList().Select(o => new OdlicnihOdjeljenje()
                {
                    BrojUcenika = brojUcenika(o.Uceniks.ToList(), 5),
                    Odjeljenje = o.Naziv
                }).OrderByDescending(p => p.BrojUcenika).ToList();

                statistika.BrojMuskih = context.Uceniks.Where(u => u.Pol == "Musko").ToList().Count;
                statistika.BrojZenskih = context.Uceniks.Where(u => u.Pol == "Zensko").ToList().Count;

                var odjeljenja = context.Odjeljenjes.ToList();

                statistika.NajboljeOdjeljenjePoProsjeku = odjeljenja.Select(o => new OdjeljenjeProsjekViewModel()
                {
                    OdjeljenjeId = o.OdjeljenjeId,
                    Prosjek = Math.Round(vratiProsjekOdjeljenja(o.Uceniks.ToList()), 3),
                    Naziv = o.Naziv
                }).ToList().OrderByDescending(o => o.Prosjek).FirstOrDefault() as OdjeljenjeProsjekViewModel;

                var ucenici = context.Uceniks.ToList();

                statistika.ProsjekGodinaUcenika = ucenici.Average(u => ((decimal)u.DatumRodjenja.Subtract(DateTime.Now).Days / 365) * -1);

                statistika.Top5Ucenika = ucenici.Where(u => u.Ocjenes.Count != 0)
                    .Select(u => new Top5Ucenika()
                    {
                        Ime = u.Ime,
                        Prezime = u.Prezime,
                        Prosjek = Math.Round(u.Ocjenes.Average(o => o.VrijednostOcjene), 3)
                    }).OrderByDescending(t => t.Prosjek).Take(5).ToList();


                var nast = context.Nastavniks.ToList();

                statistika.Top3Nastavnika = nast.Where(n => n.Ocjenes.Count != 0)
                    .Select(n => new Top3Nastavnika()
                    {
                        Ime = n.Ime,
                        Prezime = n.Prezime,
                        Prosjek = Math.Round(n.Ocjenes
                        .Average(o => o.Ucenik.Ocjenes.Average(p => p.VrijednostOcjene)), 3)
                    }).OrderByDescending(p => p.Prosjek).Take(3).ToList();

                var predmeti = context.Predmets.ToList();

                statistika.Top4Predmeta = predmeti.Where(p => p.Ocjenes.Count != 0).Select(p => new Top4Predmeta
                {
                    Naziv = p.Naziv,
                    Prosjek = Math.Round(p.Ocjenes.Average(o => o.VrijednostOcjene), 3)
                }).OrderByDescending(p => p.Prosjek).Take(4).ToList();

                statistika.Pretraga = "";
                statistika.Pol = "";
                statistika.OdjeljenjeID = -1;

                statistika.Odjeljenjes = new List<SelectListItem>();

                statistika.Odjeljenjes = context.Odjeljenjes.Select(o => new SelectListItem()
                {
                    Value = "" + o.OdjeljenjeId,
                    Text = o.Naziv
                }).ToList();

                statistika.Odjeljenjes.Insert(0, new SelectListItem() { Text = "Izaberi odjeljenje", Value = "-1" });
                

                return View(statistika);
            }
        }

        [HttpGet]
        public ActionResult Podaci(string pretraga, int odjeljenje, string pol)
        {
            using (var context = new SkolaContext())
            {
                var Ucenici = context.Uceniks.Where(u => (u.OdjeljenjeId == odjeljenje || odjeljenje == -1) &&
                    (u.Pol == pol || pol == "")).Select(u => new UcenikViewModel()
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

                string[] vrijednost = pretraga.Split(' ');

                if (vrijednost[0] == "") return new JsonResult { Data = Ucenici, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                foreach (string value in vrijednost)
                {

                    Ucenici = Ucenici.ToList().Where(u => u.Ime.Contains(value) ||
                        u.Prezime.Contains(value) || u.Jmbg.Contains(value) ||
                        u.BrojUDnevniku.ToString().Contains(value)).ToList();
                }

                return new JsonResult { Data = Ucenici, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

            }

        }

        private double vratiProsjkePoNastavniku(List<Ocjene> ocjene)
        {
            if (ocjene.Count == 0) return 0;
            double rez = ocjene.Average(o => vratiProsjek(o.Ucenik.Ocjenes.ToList()));
            return rez;
        }

        private double vratiProsjekOdjeljenja(List<Ucenik> lista)
        {
            double prosjek = 0;
            if (lista.Count == 0) return 0;
            prosjek = lista.Average(u => vratiProsjek(u.Ocjenes.ToList()));
            return prosjek;
        }

        private int brojUcenika(List<Ucenik> list, int ocjena)
        {
            var novaLista = list.Where(u => Math.Round(vratiProsjek(u.Ocjenes.ToList()), MidpointRounding.AwayFromZero) == ocjena).Select(u => u).ToList();
            return novaLista.Count;
        }

        private double vratiProsjek(List<Ocjene> list)
        {
            double prosjek = 0;

            if (list.Count == 0) return 1;
            prosjek = list.Average(o => o.VrijednostOcjene);

            return prosjek;
     
        }
    }
}
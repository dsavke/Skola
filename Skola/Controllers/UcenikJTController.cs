using Skola.DbModels;
using Skola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace Skola.Controllers
{
    public class UcenikJTController : Controller
    {
        // GET: UcenikJT
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {
            try
            {
                using (var context = new SkolaContext())
                {

                    var states = context.Uceniks.Select(u => new UcenikViewModel()
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
                        GradId = u.GradID,
                        Grad = u.Grad.Naziv,
                        Drzava = u.Grad.Drzava.Naziv
                    }).ToList();

                    var count = states.Count;

                    var records = states.OrderBy(jtSorting).Skip(jtStartIndex).Take(jtPageSize).ToList();

                    return Json(new { Result = "OK", Records = records, TotalRecordCount = count });
                }
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

    }
}
using Skola.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Skola.Controllers
{
    public class KonverterController : Controller
    {

        private List<Valuta> vratiListuValuta()
        {
            List<Valuta> Valutas = new List<Valuta>();
            Valutas.Add(new Valuta() { Naziv = "Euro", ValutaID = 0, KursValute = 0.50 });
            Valutas.Add(new Valuta() { Naziv = "Dolar", ValutaID = 1, KursValute = 1.45 });
            Valutas.Add(new Valuta() { Naziv = "Frank", ValutaID = 2, KursValute = 1.85 });
            Valutas.Add(new Valuta() { Naziv = "Dinar", ValutaID = 3, KursValute = 60 });
            return Valutas;
        }

        // GET: Konverter
        public ActionResult Index()
        {

            ViewBag.Valute = vratiListuValuta().Select(v => new SelectListItem()
            {
                Value = "" + v.ValutaID,
                Text = v.Naziv
            }).ToList();

            return View();
        }

        public ActionResult GetConvertedValue(string vrijednost, int valutaID)
        {

            bool proslo = true;
            string poruka = "";
            double vrije = 0.0;

            if (!double.TryParse(vrijednost, out vrije))
            {
                proslo = false;
                poruka += "Morate unijeti vrijednost" + Environment.NewLine;
            }else if(vrije < 0)
            {
                proslo = false;
                poruka += "Morate unijeti pozitivnu vrijednost" + Environment.NewLine;
            }

            List<Valuta> valutas = vratiListuValuta();

            Valuta valuta = valutas.Where(v => v.ValutaID == valutaID).FirstOrDefault();

            double konvertovanaVrijednost = vrije * valuta.KursValute;
    
            return new JsonResult() { Data = new { Success = proslo, Message = poruka, Konvertovano = 
                            new { Vrijednost = konvertovanaVrijednost, NazivValute = valuta.Naziv } }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}
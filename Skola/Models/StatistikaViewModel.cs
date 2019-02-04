using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skola.Models
{
    public class StatistikaViewModel
    {
        public int UkupanBrojUcenika { get; set; }
        public List<Top3Ucenika> Top3OdlicnihUcenika { get; set; }
        public int BrojOdlicnih { get; set; }
        public int BrojVrloDobrih { get; set; }
        public int BrojDobrih { get; set; }
        public int BrojDovoljnih { get; set; }
        public int BrojNedovoljnih { get; set; }
        public List<OdlicnihOdjeljenje> OdlicnihOdjeljenjes { get; set; }
        public int BrojMuskih { get; set; }
        public int BrojZenskih { get; set; }
        public OdjeljenjeProsjekViewModel NajboljeOdjeljenjePoProsjeku { get; set; }
        public decimal ProsjekGodinaUcenika { get; set; }
        public string Pretraga { get; set; }

        public List<Top5Ucenika> Top5Ucenika { get; set; }
        public List<Top3Nastavnika> Top3Nastavnika { get; set; }
        public List<Top4Predmeta> Top4Predmeta { get; set; }

    }

}
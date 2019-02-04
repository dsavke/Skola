using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Skola.Models
{

    public enum TipOcjene
    {
        Usmeni,
        Pismeni,
        Prakticno
    }

    public class OcjenaViewModel
    {
        public int OcjenaId { get; set; }
        public int UcenikId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }
        public int Vrijednost { get; set; }
        public TipOcjene TipOcjene { get; set; }
        public int Predmet { get; set; }
        public int Nastavnik { get; set; }
        public string ImeNastavnika { get; set; }
        public string PrezimeNastavnika { get; set; }
        public string NazivPredmeta { get; set; }
    }
}
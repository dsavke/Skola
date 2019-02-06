using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Skola.Models
{
    public class UcenikViewModel
    {
        public int UcenikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Pol { get; set; }
        public string Jmbg { get; set; }
        public string Adresa { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DatumRodjenja { get; set; }
        public string ImeRoditelja { get; set; }
        public int BrojUDnevniku { get; set; }
        public string Drzavljanstvo { get; set; }
        public int Odjeljenje { get; set; }
        public string NazivOdjeljena { get; set; }
        public int GradId { get; set; }
    }
}
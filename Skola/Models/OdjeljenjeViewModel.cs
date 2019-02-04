using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skola.Models
{
    public class OdjeljenjeViewModel
    {
        public int OdjeljenjeId { get; set; }
        public int Razrednik { get; set; }
        public byte Razred { get; set; }
        public string Naziv { get; set; }
        public int SkolskaGodina { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
    }
}
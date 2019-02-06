using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skola.Models
{
    public class Valuta
    {
        public string Naziv { get; set; }
        public int ValutaID { get; set; }
        public double KursValute { get; set; }
    }
}
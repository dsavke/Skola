using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skola.Models
{
    public class OcjenaPredmetViewModel
    {
        public int OcjenaID { get; set; }
        public int Vrijednost { get; set; }
        public DateTime DatumOcjene { get; set; }
        public TipOcjene TipOcjene { get; set; }
    }
}
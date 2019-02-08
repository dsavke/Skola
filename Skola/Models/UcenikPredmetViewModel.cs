using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skola.Models
{
    public class UcenikPredmetViewModel
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int UcenikID { get; set; }
        public List<PrdmetViewModel> Predmeti { get; set; } 
    }
}
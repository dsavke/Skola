using Skola.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Skola.HelperClass
{
    public static class DataHelper
    {
        public static List<UcenikViewModel> LoadUcenik()
        {
            List<UcenikViewModel> Ucenici = new List<UcenikViewModel>();

            using (StreamReader sr = new StreamReader(@"C:\Users\dejan.savanovic\Documents\Simulacija skole\Ucenik.txt"))
            {
                string linija = sr.ReadLine();
                while(linija != null)
                {
                    string[] vrijednosti = linija.Split(';');
                    UcenikViewModel ucenik = new UcenikViewModel();
                    ucenik.UcenikId = Convert.ToInt32(vrijednosti[0]);
                    ucenik.Ime = vrijednosti[1];
                    ucenik.Prezime = vrijednosti[2];
                    ucenik.Pol = vrijednosti[3];
                    ucenik.Jmbg = vrijednosti[4];
                    ucenik.Adresa =vrijednosti[5];
                    ucenik.DatumRodjenja = Convert.ToDateTime(vrijednosti[6]);
                    ucenik.ImeRoditelja = vrijednosti[7];
                    ucenik.BrojUDnevniku = Convert.ToInt32(vrijednosti[8]);
                    ucenik.Drzavljanstvo = vrijednosti[9];
                    ucenik.Odjeljenje = Convert.ToInt32(vrijednosti[10]);
                    Ucenici.Add(ucenik);
                    linija = sr.ReadLine();
                }
            }

            return Ucenici;
        }

        public static void SaveUcenik(this List<UcenikViewModel> Ucenici)
        {
            using(StreamWriter sw = new StreamWriter(@"C:\Users\dejan.savanovic\Documents\Simulacija skole\Ucenik.txt"))
            {
                foreach(UcenikViewModel ucenik in Ucenici)
                {
                    string linija = ucenik.UcenikId + ";" +
                    ucenik.Ime + ";" +
                    ucenik.Prezime + ";" +
                    ucenik.Pol + ";" +
                    ucenik.Jmbg + ";" +
                    ucenik.Adresa + ";" +
                    ucenik.DatumRodjenja + ";" +
                    ucenik.ImeRoditelja + ";" +
                    ucenik.BrojUDnevniku + ";" +
                    ucenik.Drzavljanstvo + ";" +
                    ucenik.Odjeljenje + ";";
                    sw.WriteLine(linija);
                }
            }
        }

        public static int GetNextUcenikID(this List<UcenikViewModel> Ucenici)
        {
            int index = 0;
            if (Ucenici.Count != 0)
            index = Ucenici.Max(u => u.UcenikId) + 1;
            return index;
        }

        public static List<OcjenaViewModel> LoadOcjena()
        {
            List<OcjenaViewModel> Ocjene = new List<OcjenaViewModel>();
            using(StreamReader sr = new StreamReader(@"C:\Users\dejan.savanovic\Documents\Simulacija skole\Ocjena.txt"))
            {
                string linija = sr.ReadLine();
                while(linija != null)
                {
                    string[] vrijednosti = linija.Split(';');
                    OcjenaViewModel ocjena = new OcjenaViewModel();
                    ocjena.OcjenaId = Convert.ToInt32(vrijednosti[0]);
                    ocjena.UcenikId = Convert.ToInt32(vrijednosti[1]);
                    ocjena.Datum = Convert.ToDateTime(vrijednosti[2]);
                    ocjena.Vrijednost = Convert.ToInt32(vrijednosti[3]);
                    ocjena.TipOcjene = (TipOcjene)Convert.ToInt32(vrijednosti[4]);
                   // ocjena.Predmet = vrijednosti[5];
                    //ocjena.Nastavnik = vrijednosti[6];
                    Ocjene.Add(ocjena);
                    linija = sr.ReadLine();
                }
            }
            return Ocjene;
        }

        public static void SaveOcjena(this List<OcjenaViewModel> Ocjene)
        {
            using(StreamWriter sw = new StreamWriter(@"C:\Users\dejan.savanovic\Documents\Simulacija skole\Ocjena.txt"))
            {
                foreach(OcjenaViewModel ocjena in Ocjene)
                {
                    string linija = ocjena.OcjenaId + ";" +
                    ocjena.UcenikId + ";" +
                    ocjena.Datum + ";" +
                    ocjena.Vrijednost + ";" +
                    (int)ocjena.TipOcjene + ";" +
                    ocjena.Predmet + ";" +
                    ocjena.Nastavnik + ";";
                    sw.WriteLine(linija);
                }
            }
        }

        public static int GetNextOcjenaID(this List<OcjenaViewModel> Ocjene)
        {
            int index = 0;
            if (Ocjene.Count != 0)
                index = Ocjene.Max(o => o.OcjenaId) + 1;
            return index;
        }

        public static List<OdjeljenjeViewModel> LoadOdjeljenje()
        {
            List<OdjeljenjeViewModel> Odjeljenja = new List<OdjeljenjeViewModel>();

            using(StreamReader sr = new StreamReader(@"C:\Users\dejan.savanovic\Documents\Simulacija skole\Odjeljenje.txt"))
            {
                string linija = sr.ReadLine();
                while(linija != null)
                {
                    string[] vrijednosti = linija.Split(';');
                    OdjeljenjeViewModel odjeljenje = new OdjeljenjeViewModel();
                    odjeljenje.OdjeljenjeId = Convert.ToInt32(vrijednosti[0]);
                    ///djeljenje.Razrednik = vrijednosti[1];
                    odjeljenje.Razred = Convert.ToByte(vrijednosti[2]);
                    odjeljenje.Naziv = vrijednosti[3];
                    odjeljenje.SkolskaGodina = Convert.ToInt32(vrijednosti[4]);
                    Odjeljenja.Add(odjeljenje);
                    linija = sr.ReadLine();
                }
            }

            return Odjeljenja;
        }

        public static void SaveOdjeljenje(this List<OdjeljenjeViewModel> Odjeljenja)
        {
            using(StreamWriter sw = new StreamWriter(@"C:\Users\dejan.savanovic\Documents\Simulacija skole\Odjeljenje.txt"))
            {
                foreach(OdjeljenjeViewModel odjeljenje in Odjeljenja)
                {
                    string linija = odjeljenje.OdjeljenjeId + ";" +
                    odjeljenje.Razrednik + ";" +
                    odjeljenje.Razred + ";" +
                    odjeljenje.Naziv + ";" +
                    odjeljenje.SkolskaGodina + ";";
                    sw.WriteLine(linija);
                }
            }
        }

        public static int GetNextOdjeljenjeID(this List<OdjeljenjeViewModel> Odjeljenja)
        {
            int index = 0;
            if (Odjeljenja.Count != 0)
                index = Odjeljenja.Max(o => o.OdjeljenjeId) + 1;
            return index;
        }

    }
}
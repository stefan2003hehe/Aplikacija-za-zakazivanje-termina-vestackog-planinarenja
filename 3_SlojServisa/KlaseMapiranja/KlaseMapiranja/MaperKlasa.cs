using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using KlasePodataka;

namespace KlaseMapiranja
{
    public class MaperKlasa
    {
        // atributi
        private string pStringKonekcije;

        // property

        // konstruktor
        public MaperKlasa(string noviStringKonekcije)
        {
            pStringKonekcije = noviStringKonekcije;
        }
        public string DajSifruTipaRuteZaWebServis(string NazivTipaIzBaze)
        {
            string pomSifraWS = "";

            // HEURISTIKA:
            // prvo slovo naziva tipa ispita koristi se kao šifra
            // primer: "Sever" -> "S", "Jug" -> "J"
            if (!string.IsNullOrEmpty(NazivTipaIzBaze))
            {
                pomSifraWS = NazivTipaIzBaze[0].ToString().ToUpper();
            }

            return pomSifraWS;
        }

    }
}

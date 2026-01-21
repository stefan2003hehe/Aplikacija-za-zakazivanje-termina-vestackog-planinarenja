using System;
using System.Data;
using KlasePodataka;

namespace PoslovnaLogika
{
    public class TerminPL
    {
        private TerminDAL terminDAL;

        public TerminPL(string connStr)
        {
            terminDAL = new TerminDAL(connStr);
        }

        public bool DodajTermin(int korisnikID, int trenerID, DateTime datumVreme, decimal trajanjeSati, string ruta, string tezina, decimal cena)
        {
            return terminDAL.DodajTermin(korisnikID, trenerID, datumVreme, trajanjeSati, ruta, tezina, cena);
        }

        public bool TrenerJeZauzet(int trenerID, DateTime datumVreme, decimal trajanjeSati)
        {
            return terminDAL.TrenerJeZauzet(trenerID, datumVreme, trajanjeSati);
        }

        public DataTable VratiSveTermine()
        {
            return terminDAL.VratiSveTermine();
        }

        public DataTable VratiTermineZaKorisnika(int korisnikID)
        {
            return terminDAL.VratiTermineZaKorisnika(korisnikID);
        }

        public DataTable VratiTermineZaTrenera(int trenerID)
        {
            return terminDAL.VratiTermineZaTrenera(trenerID);
        }

        public bool IzmeniTermin(int idTermin, int korisnikID, int trenerID, DateTime datumVreme, decimal trajanjeSati, string ruta, string tezina, decimal cena)
        {
            return terminDAL.IzmeniTermin(idTermin, korisnikID, trenerID, datumVreme, trajanjeSati, ruta, tezina, cena);
        }

        public bool ObrisiTermin(int idTermin)
        {
            return terminDAL.ObrisiTermin(idTermin);
        }
    }
}

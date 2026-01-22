using System;
using System.Data;
using DBUtils;
using KlasePodataka;

namespace SlojPoslovneLogike
{
    public class PoslovnaLogika
    {
        private static KorisnikDAL korisnikDAL;
        private static TrenerDAL trenerDAL;
        private static TerminDAL terminDAL;

        // Inicijalizacija DAL klasa
        public static void Inicijalizuj(KonekcijaKlasa konekcija)
        {
            korisnikDAL = new KorisnikDAL(konekcija);
            trenerDAL = new TrenerDAL(konekcija);
            terminDAL = new TerminDAL(konekcija);
        }

        // --- PRAVILO: Čas ne može biti zakazan u prošlosti ---
        public static void ProveriProslostTermin(DateTime datumVreme)
        {
            if (datumVreme < DateTime.Now)
                throw new InvalidOperationException("Čas ne može biti zakazan u prošlosti.");
        }

        // --- PRAVILO: Validacija broja termina po korisniku ---
        public static void ProveriOgranicenjeTerminaKorisnika(int korisnikID, DateTime datum)
        {
            int maxTerminiPoKorisniku = UcitajIntIzXml("MaxTerminiPoKorisniku", 5);
            DataTable dt = terminDAL.DajTermineZaKorisnika(korisnikID);
            int brojTermina = 0;

            foreach (DataRow row in dt.Rows)
                if (Convert.ToDateTime(row["DatumVreme"]).Date == datum.Date)
                    brojTermina++;

            if (brojTermina >= maxTerminiPoKorisniku)
                throw new InvalidOperationException("Korisnik je dostigao maksimalan broj termina za ovaj dan.");
        }

        // --- PRAVILO: Validacija broja termina po treneru ---
        public static void ProveriOgranicenjeTerminaTrenera(int trenerID, DateTime datum)
        {
            int maxTerminiPoTreneru = UcitajIntIzXml("MaxTerminiPoTreneru", 8);
            DataTable dt = terminDAL.DajTermineZaTrenera(trenerID);
            int brojTermina = 0;

            foreach (DataRow row in dt.Rows)
                if (Convert.ToDateTime(row["DatumVreme"]).Date == datum.Date)
                    brojTermina++;

            if (brojTermina >= maxTerminiPoTreneru)
                throw new InvalidOperationException("Trener je dostigao maksimalan broj termina za ovaj dan.");
        }

        // --- Glavna metoda za izračunavanje cene termina ---
        public static decimal IzracunajCenuTermina(decimal cenaPoSatu, decimal trajanjeSati)
        {
            return cenaPoSatu * trajanjeSati;
        }

        // --- Validacija starosti korisnika ---
        private static void ProveriStarost(DateTime datumRodjenja)
        {
            int minimalneGodine = UcitajIntIzXml("MinimalneGodine", 12);
            int godine = DateTime.Now.Year - datumRodjenja.Year;
            if (DateTime.Now.Date < datumRodjenja.Date.AddYears(godine))
                godine--;

            if (godine < minimalneGodine)
                throw new InvalidOperationException($"Korisnik mora imati najmanje {minimalneGodine} godina.");
        }

        // --- Glavna metoda za validaciju prilikom zakazivanja termina ---
        public static void ProveriValidnostZakazivanjaTermina(int korisnikID, int trenerID, DateTime datumVreme, decimal trajanjeSati)
        {
            ProveriProslostTermin(datumVreme);
            DateTime datumRodjenja = korisnikDAL.DajDatumRodjenjaKorisnika(korisnikID.ToString());
            ProveriStarost(datumRodjenja);
            ProveriOgranicenjeTerminaKorisnika(korisnikID, datumVreme);
            ProveriOgranicenjeTerminaTrenera(trenerID, datumVreme);

            bool zauzet = terminDAL.TrenerJeZauzet(trenerID, datumVreme, trajanjeSati);
            if (zauzet)
                throw new InvalidOperationException("Trener je već zauzet u izabranom terminu.");
        }

        private static int UcitajIntIzXml(string kljuc, int podrazumevano)
        {
            try
            {
                var doc = new System.Xml.XmlDocument();
                doc.Load("Konfiguracija.xml");
                var node = doc.SelectSingleNode($"/Pravila/{kljuc}");
                if (node != null && int.TryParse(node.InnerText, out int vrednost))
                    return vrednost;
            }
            catch { }
            return podrazumevano;
        }
    }
}

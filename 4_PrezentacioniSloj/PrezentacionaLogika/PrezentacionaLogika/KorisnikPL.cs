using System;
using System.Data;
using KlasePodataka;
using DBUtils;

namespace PrezentacionaLogika
{
    public class KorisnikPL
    {
        private readonly KorisnikDAL korisnikDAL;

        public KorisnikPL()
        {
            // Inicijalizacija DAL-a sa konekcijom iz web.config
            korisnikDAL = new KorisnikDAL(new KonekcijaKlasa(
                System.Configuration.ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString));
        }

        // Vraća sve korisnike
        public DataTable DajSveKorisnike()
        {
            return korisnikDAL.DajSveKorisnike();
        }

        // Vraća korisnike filtrirane po imenu (koristi DAL proceduru)
        public DataTable DajKorisnikePoImenu(string ime)
        {
            if (string.IsNullOrWhiteSpace(ime))
                return DajSveKorisnike();

            return korisnikDAL.DajKorisnikePoImenu(ime);
        }

        // Dodavanje korisnika
        public bool DodajKorisnika(string ime, string prezime, string pol, string telefon, string email,
            DateTime datumRodjenja, string korisnickoIme, string sifra)
        {
            return korisnikDAL.DodajKorisnika(ime, prezime, pol, telefon, email, datumRodjenja, korisnickoIme, sifra);
        }

        // Izmena korisnika
        public bool IzmeniKorisnika(string id, string ime, string prezime, string pol, string telefon, string email,
            DateTime datumRodjenja, string korisnickoIme, string sifra)
        {
            return korisnikDAL.IzmeniKorisnika(id, ime, prezime, pol, telefon, email, datumRodjenja, korisnickoIme, sifra);
        }

        // Brisanje korisnika po ID-u
        public bool ObrisiKorisnika(string id)
        {
            return korisnikDAL.ObrisiKorisnika(id);
        }

        // Provera da li korisnik postoji po emailu
        public bool PostojiKorisnik(string email)
        {
            return korisnikDAL.PostojiKorisnik(email);
        }

        // Dohvatanje korisnika po korisničkom imenu (za sesiju/login)
        public DataTable DajKorisnikaPoKorisnickomImenu(string korisnickoIme)
        {
            return korisnikDAL.DajKorisnikaPoKorisnickomImenu(korisnickoIme);
        }

        // Provera prijave korisnika po korisničkom imenu i šifri
        public bool PrijavaKorisnika(string korisnickoIme, string sifra)
        {
            return korisnikDAL.PrijavaKorisnika(korisnickoIme, sifra);
        }

        // Dohvatanje imena korisnika po ID-u
        public string DajImePoID(string id)
        {
            return korisnikDAL.DajImePoID(id);
        }

        // Dohvatanje korisnika po polu (za filtriranje)
        public DataTable DajKorisnikePoPolu(string pol)
        {
            return korisnikDAL.DajKorisnikePoPolu(pol);
        }


        // Dohvatanje termina korisnika (ako bude potrebno)
        public DataTable DajKorisnikaTermine(int idKorisnik)
        {
            return korisnikDAL.DajKorisnikaTermine(idKorisnik);
        }
    }
}

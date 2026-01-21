using System;
using System.Data;
using KlasePodataka;
using DBUtils;

namespace PrezentacionaLogika
{
    public class AdminPL
    {
        private readonly AdminDAL adminDAL;

        public AdminPL()
        {
            // Inicijalizacija DAL sloja sa konekcijom iz web.config fajla
            adminDAL = new AdminDAL(new KonekcijaKlasa(
                System.Configuration.ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString));
        }

        // ======================
        // CRUD OPERACIJE
        // ======================

        // Dodavanje novog admina
        public bool DodajAdmina(string korisnickoIme, string sifra)
        {
            return adminDAL.DodajAdmina(korisnickoIme, sifra);
        }

        // Izmena admina
        public bool IzmeniAdmina(string id, string korisnickoIme, string sifra)
        {
            return adminDAL.IzmeniAdmina(id, korisnickoIme, sifra);
        }

        // Brisanje admina po ID-u
        public bool ObrisiAdmina(string id)
        {
            return adminDAL.ObrisiAdmina(id);
        }

        // ======================
        // DOHVAT PODATAKA
        // ======================

        // Dohvatanje svih admina
        public DataTable DajSveAdmine()
        {
            return adminDAL.DajSveAdmine();
        }

        // Dohvatanje admina po ID-u
        public DataTable DajAdminaPoID(string id)
        {
            return adminDAL.DajAdminaPoID(id);
        }

        // Dohvatanje admina po korisničkom imenu
        public DataTable DajAdminaPoKorisnickomImenu(string korisnickoIme)
        {
            return adminDAL.DajAdminaPoKorisnickomImenu(korisnickoIme);
        }


        // Provera da li admin postoji (login)
        public bool PrijavaAdmina(string korisnickoIme, string sifra)
        {
            return adminDAL.PrijavaAdmina(korisnickoIme, sifra);
        }

        // Vraća korisničko ime po ID-u
        public string DajImePoID(string id)
        {
            return adminDAL.DajImePoID(id);
        }
    }
}

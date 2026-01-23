using System;
using KlasePodataka;
using DBUtils;

namespace PrezentacionaLogika
{
    public class AdminAutentifikacija
    {
        private readonly AdminDAL adminRepo;

        public AdminAutentifikacija()
        {
            // Povezivanje sa bazom pomoću konekcije iz web.config
            string konekcioniString = System.Configuration.ConfigurationManager
                .ConnectionStrings["NasaKonekcija"].ConnectionString;

            adminRepo = new AdminDAL(new KonekcijaKlasa(konekcioniString));
        }

        /// <summary>
        /// Proverava da li postoji admin sa zadatim korisničkim imenom i lozinkom u bazi.
        /// </summary>
        /// <param name="korisnickoIme">Korisničko ime admina</param>
        /// <param name="lozinka">Lozinka admina</param>
        /// <returns>True ako admin postoji, inače False</returns>
        public bool ProveriAdmina(string korisnickoIme, string lozinka)
        {
            if (string.IsNullOrWhiteSpace(korisnickoIme) || string.IsNullOrWhiteSpace(lozinka))
                return false;

            return adminRepo.PrijavaAdmina(korisnickoIme, lozinka);
        }
    }
}

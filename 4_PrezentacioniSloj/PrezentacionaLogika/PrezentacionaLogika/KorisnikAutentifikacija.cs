using KlasePodataka;
using System;

namespace PrezentacionaLogika
{
    public class KorisnikAutentifikacija
    {
        private readonly KorisnikDAL korisnikRepo;

        public KorisnikAutentifikacija(KorisnikDAL korisnikRepozitorijum)
        {
            korisnikRepo = korisnikRepozitorijum ?? throw new ArgumentNullException(nameof(korisnikRepozitorijum));
        }

        public bool PrijaviKorisnika(string korisnickoIme, string sifra)
        {
            return korisnikRepo.PrijavaKorisnika(korisnickoIme, sifra);
        }
    }
}

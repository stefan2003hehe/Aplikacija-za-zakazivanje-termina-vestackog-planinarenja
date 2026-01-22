using KlasePodataka;
using System;

namespace PrezentacionaLogika
{
    public class TrenerAutentifikacija
    {
        private readonly TrenerDAL trenerRepo;

        public TrenerAutentifikacija(TrenerDAL trenerRepozitorijum)
        {
            trenerRepo = trenerRepozitorijum ?? throw new ArgumentNullException(nameof(trenerRepozitorijum));
        }

        public bool PrijaviTrenera(string korisnickoIme, string sifra)
        {
            return trenerRepo.PrijavaTrenera(korisnickoIme, sifra);
        }
    }
}

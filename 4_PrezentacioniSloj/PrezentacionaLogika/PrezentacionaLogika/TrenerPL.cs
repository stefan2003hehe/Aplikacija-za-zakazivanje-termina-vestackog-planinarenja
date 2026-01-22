using System;
using System.Data;
using KlasePodataka;
using DBUtils;

namespace PrezentacionaLogika
{
    public class TrenerPL
    {
        private readonly TrenerDAL trenerDAL;

        public TrenerPL()
        {
            trenerDAL = new TrenerDAL(new KonekcijaKlasa(
                System.Configuration.ConfigurationManager.ConnectionStrings["NasaKonekcija"].ConnectionString));
        }

        public bool DodajTrenera(string ime, string prezime, string pol, string telefon, string email, string sertifikati, decimal satnica, string korisnickoIme, string sifra)
        {
            return trenerDAL.DodajTrenera(ime, prezime, pol, telefon, email, sertifikati, satnica, korisnickoIme, sifra);
        }

        public bool IzmeniTrenera(string id, string ime, string prezime, string pol, string telefon, string email, string sertifikati, decimal satnica, string korisnickoIme, string sifra)
        {
            return trenerDAL.IzmeniTrenera(id, ime, prezime, pol, telefon, email, sertifikati, satnica, korisnickoIme, sifra);
        }

        public bool ObrisiTrenera(string id)
        {
            return trenerDAL.ObrisiTrenera(id);
        }

        public DataTable DajSveTrenere()
        {
            return trenerDAL.DajSveTrenere();
        }

        public DataTable DajTreneraPoID(string id)
        {
            return trenerDAL.DajTreneraPoID(id);
        }

        public DataTable DajTreneraPoKorisnickomImenu(string korisnickoIme)
        {
            return trenerDAL.DajTreneraPoKorisnickomImenu(korisnickoIme);
        }

        public DataTable DajTrenerePoImenu(string ime)
        {
            return trenerDAL.DajTrenerePoImenu(ime);
        }

        public bool PrijavaTrenera(string korisnickoIme, string sifra)
        {
            return trenerDAL.PrijavaTrenera(korisnickoIme, sifra);
        }

        public bool PostojiTrener(string email)
        {
            return trenerDAL.PostojiTrener(email);
        }

        public string DajImePoID(string id)
        {
            return trenerDAL.DajImePoID(id);
        }
    }
}

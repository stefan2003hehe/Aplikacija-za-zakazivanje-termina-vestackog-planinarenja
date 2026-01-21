using System;
using System.Data;
using DBUtils;

namespace KlasePodataka
{
    public class TrenerDAL : TabelaKlasa
    {
        public TrenerDAL(KonekcijaKlasa konekcija)
            : base(konekcija, "Trener")
        {
        }

        // Dodavanje trenera
        public bool DodajTrenera(string ime, string prezime, string pol, string telefon, string email, string sertifikati, decimal satnica, string korisnickoIme, string sifra)
        {
            string upit = $@"
                INSERT INTO Trener (Ime, Prezime, Pol, BrojTelefona, Email, Sertifikati, Satnica, KorisnickoIme, Sifra)
                VALUES ('{ime}', '{prezime}', '{pol}', '{telefon}', '{email}', '{sertifikati}', {satnica.ToString(System.Globalization.CultureInfo.InvariantCulture)}, '{korisnickoIme}', '{sifra}')";

            return IzvrsiAzuriranje(upit);
        }

        // Izmena trenera
        public bool IzmeniTrenera(string id, string ime, string prezime, string pol, string telefon, string email, string sertifikati, decimal satnica, string korisnickoIme, string sifra)
        {
            string upit = $@"
                UPDATE Trener
                SET Ime = '{ime}',
                    Prezime = '{prezime}',
                    Pol = '{pol}',
                    BrojTelefona = '{telefon}',
                    Email = '{email}',
                    Sertifikati = '{sertifikati}',
                    Satnica = {satnica.ToString(System.Globalization.CultureInfo.InvariantCulture)},
                    KorisnickoIme = '{korisnickoIme}',
                    Sifra = '{sifra}'
                WHERE IDTrener = {id}";

            return IzvrsiAzuriranje(upit);
        }

        // Brisanje trenera po ID-u
        public bool ObrisiTrenera(string id)
        {
            string upit = $@"EXEC ObrisiTrenera @IDTrener = {id}";
            return IzvrsiAzuriranje(upit);
        }

        // Dohvatanje svih trenera
        public DataTable DajSveTrenere()
        {
            string upit = "EXEC VratiSveTrenere";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Dohvatanje trenera po ID-u
        public DataTable DajTreneraPoID(string id)
        {
            string upit = $@"EXEC VratiTreneraPoID @IDTrener = {id}";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Dohvatanje trenera po korisničkom imenu
        public DataTable DajTreneraPoKorisnickomImenu(string korisnickoIme)
        {
            string upit = $@"EXEC VratiTreneraPoKorisnickomImenu @KorisnickoIme = '{korisnickoIme}'";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Dohvatanje trenera po imenu (filtriranje)
        public DataTable DajTrenerePoImenu(string ime)
        {
            string upit = $@"EXEC VratiTrenerePoImenu @Ime = '{ime}'";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }


        // Provera da li trener postoji na osnovu korisničkog imena i šifre (za login)
        public bool PrijavaTrenera(string korisnickoIme, string sifra)
        {
            string upit = $@"
                EXEC PostojiTrenerPrijava 
                    @KorisnickoIme = '{korisnickoIme}', 
                    @Sifra = '{sifra}'";

            DataSet ds = DajPodatke(upit);
            return (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                ? Convert.ToInt32(ds.Tables[0].Rows[0]["Postoji"]) > 0
                : false;
        }

        // Provera da li trener postoji na osnovu emaila
        public bool PostojiTrener(string email)
        {
            string upit = $@"EXEC PostojiTrener @Email = '{email}'";
            DataSet ds = DajPodatke(upit);
            return (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                ? Convert.ToInt32(ds.Tables[0].Rows[0]["Postoji"]) > 0
                : false;
        }

        // Dohvatanje imena trenera po ID-u
        public string DajImePoID(string id)
        {
            DataTable dt = DajTreneraPoID(id);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["Ime"].ToString();
            else
                return "";
        }
    }
}

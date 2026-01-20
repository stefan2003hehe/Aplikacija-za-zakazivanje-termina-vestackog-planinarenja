using DBUtils;
using System;
using System.Data;
using System.Data.SqlClient;


namespace KlasePodataka
{
    public class KorisnikDAL : TabelaKlasa
    {
        public KorisnikDAL(KonekcijaKlasa konekcija)
            : base(konekcija, "Korisnik")
        {
        }
        public bool DodajKorisnika(string ime, string prezime, string pol, string telefon, string email, DateTime datumRodjenja, string korisnickoIme, string sifra)
        {
            string upit = $@"
                INSERT INTO Korisnik (Ime, Prezime, Pol, BrojTelefona, Email, DatumRodjenja, KorisnickoIme, Sifra)
                VALUES ('{ime}', '{prezime}', '{pol}', '{telefon}', '{email}', '{datumRodjenja:yyyy-MM-dd}', '{korisnickoIme}', '{sifra}')";
            return IzvrsiAzuriranje(upit);
        }

        public bool IzmeniKorisnika(string id, string ime, string prezime, string pol, string telefon, string email, DateTime datumRodjenja, string korisnickoIme, string sifra)
        {
            string upit = $@"
                UPDATE Korisnik
                SET Ime = '{ime}',
                    Prezime = '{prezime}',
                    Pol = '{pol}',
                    BrojTelefona = '{telefon}',
                    Email = '{email}',
                    DatumRodjenja = '{datumRodjenja:yyyy-MM-dd}',
                    KorisnickoIme = '{korisnickoIme}',
                    Sifra = '{sifra}'
                WHERE IDKorisnik = {id}";
            return IzvrsiAzuriranje(upit);
        }

        public bool ObrisiKorisnika(string id)
        {
            string upit = $@"EXEC ObrisiKorisnika @IDKorisnik = {id}";
            return IzvrsiAzuriranje(upit);
        }

        public DateTime DajDatumRodjenjaKorisnika(string id)
        {
            string upit = $@"EXEC VratiKorisnikaPoID @IDKorisnik = {id}";
            DataSet ds = DajPodatke(upit);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return Convert.ToDateTime(ds.Tables[0].Rows[0]["DatumRodjenja"]);
            else
                throw new InvalidOperationException("Korisnik nije pronađen.");
        }

        public DataTable DajSveKorisnike()
        {
            string upit = "EXEC VratiSveKorisnike";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Dohvatanje korisnika po ID-u
        public DataTable DajKorisnikaPoID(string id)
        {
            string upit = $@"EXEC VratiKorisnikaPoID @IDKorisnik = {id}";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Provera da li korisnik postoji na osnovu emaila
        public bool PostojiKorisnik(string email)
        {
            string upit = $@"EXEC PostojiKorisnik @Email = '{email}'";
            DataSet ds = DajPodatke(upit);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Postoji"]) > 0;
            else
                return false;
        }

        // Dohvatanje korisnika po korisničkom imenu
        public DataTable DajKorisnikaPoKorisnickomImenu(string korisnickoIme)
        {
            string upit = $@"EXEC VratiKorisnikaPoKorisnickomImenu @KorisnickoIme = '{korisnickoIme}'";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Provera da li korisnik postoji na osnovu korisničkog imena i šifre (za login)
        public bool PrijavaKorisnika(string korisnickoIme, string sifra)
        {
            string upit = $@"
                EXEC PostojiKorisnikPrijava 
                    @KorisnickoIme = '{korisnickoIme}', 
                    @Sifra = '{sifra}'";

            DataSet ds = DajPodatke(upit);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Postoji"]) > 0;
            else
                return false;
        }

        // U KlasePodataka.KorisnikDAL
        public DataTable DajKorisnikaTermine(int idKorisnik)
        {
            string upit = $@"EXEC VratiTermineZaKorisnika @IDKorisnik = {idKorisnik}";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // === VRATI KORISNIKA PO KORISNIČKOM IMENU (poziva postojeću proceduru iz baze) ===

        public DataTable DajKorisnikePoImenu(string ime)
        {
            string upit = $@"EXEC VratiKorisnikePoImenu @Ime = '{ime}'";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Dohvatanje korisnika po polu
        public DataTable DajKorisnikePoPolu(string pol)
        {
            string upit = $@"EXEC VratiKorisnikePoPolu @Pol = '{pol}'";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }


        // Dohvatanje imena korisnika po ID-u
        public string DajImePoID(string id)
        {
            DataTable dt = DajKorisnikaPoID(id);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["Ime"].ToString();
            else
                return "";
        }
    }
}

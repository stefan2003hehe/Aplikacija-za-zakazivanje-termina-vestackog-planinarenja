using DBUtils;
using System;
using System.Data;

namespace KlasePodataka
{
    public class AdminDAL : TabelaKlasa
    {
        public AdminDAL(KonekcijaKlasa konekcija)
            : base(konekcija, "Admin")
        {
        }

        // Dodavanje novog admina
        public bool DodajAdmina(string korisnickoIme, string sifra)
        {
            string upit = $@"
                INSERT INTO Admin (KorisnickoIme, Sifra)
                VALUES ('{korisnickoIme}', '{sifra}')";
            return IzvrsiAzuriranje(upit);
        }

        // Izmena postojećeg admina
        public bool IzmeniAdmina(string id, string korisnickoIme, string sifra)
        {
            string upit = $@"
                UPDATE Admin
                SET KorisnickoIme = '{korisnickoIme}',
                    Sifra = '{sifra}'
                WHERE IDAdmin = {id}";
            return IzvrsiAzuriranje(upit);
        }

        // Brisanje admina
        public bool ObrisiAdmina(string id)
        {
            string upit = $@"DELETE FROM Admin WHERE IDAdmin = {id}";
            return IzvrsiAzuriranje(upit);
        }

        // Vraća sve admine
        public DataTable DajSveAdmine()
        {
            string upit = "SELECT IDAdmin, KorisnickoIme FROM Admin ORDER BY IDAdmin";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Dohvatanje admina po ID-u
        public DataTable DajAdminaPoID(string id)
        {
            string upit = $@"SELECT * FROM Admin WHERE IDAdmin = {id}";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Dohvatanje admina po korisničkom imenu
        public DataTable DajAdminaPoKorisnickomImenu(string korisnickoIme)
        {
            string upit = $@"SELECT * FROM Admin WHERE KorisnickoIme = '{korisnickoIme}'";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        // Provera da li admin postoji na osnovu korisničkog imena i šifre (login)
        public bool PrijavaAdmina(string korisnickoIme, string sifra)
        {
            string upit = $@"
                EXEC PostojiAdminPrijava 
                    @KorisnickoIme = '{korisnickoIme}', 
                    @Sifra = '{sifra}'";

            DataSet ds = DajPodatke(upit);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Postoji"]) > 0;
            else
                return false;
        }

        // Vraća ime (korisničko ime) po ID-u
        public string DajImePoID(string id)
        {
            DataTable dt = DajAdminaPoID(id);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["KorisnickoIme"].ToString();
            else
                return "";
        }
    }
}

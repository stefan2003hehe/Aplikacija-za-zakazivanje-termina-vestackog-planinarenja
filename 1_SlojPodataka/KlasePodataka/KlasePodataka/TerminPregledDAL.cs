using System;
using System.Data;
using DBUtils;

namespace KlasePodataka
{
    public class TerminPregledDAL : TabelaKlasa
    {
        public TerminPregledDAL(KonekcijaKlasa konekcija)
            : base(konekcija, "vw_TerminiDetalji")
        {
        }

        public DataTable DajSveTermineDetalji()
        {
            string upit = "SELECT * FROM vw_TerminiDetalji";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        public DataTable DajTermineZaKorisnika(int idKorisnik)
        {
            string upit = $"SELECT * FROM vw_KorisnikTermini WHERE KorisnikID = {idKorisnik}";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        public DataTable DajTermineZaTrenera(int idTrener)
        {
            string upit = $"SELECT * FROM vw_TrenerRaspored WHERE TrenerID = {idTrener}";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }

        public DataTable DajTermineZaDatum(DateTime datum)
        {
            string upit = $"SELECT * FROM vw_DnevniTermini WHERE CAST(DatumVreme AS DATE) = '{datum:yyyy-MM-dd}'";
            DataSet ds = DajPodatke(upit);
            return ds.Tables.Count > 0 ? ds.Tables[0] : new DataTable();
        }
    }
}

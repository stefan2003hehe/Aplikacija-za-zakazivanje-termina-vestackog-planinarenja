using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DBUtils
{
    public class TabelaKlasa
    {
        protected string _nazivTabele;
        protected KonekcijaKlasa _konekcijaObjekat;

        public TabelaKlasa(KonekcijaKlasa novaKonekcija, string noviNazivTabele)
        {
            _konekcijaObjekat = novaKonekcija ?? throw new ArgumentNullException(nameof(novaKonekcija));
            _nazivTabele = noviNazivTabele ?? throw new ArgumentNullException(nameof(noviNazivTabele));
        }

        public DataSet DajPodatke(string selectUpit)
        {
            if (string.IsNullOrEmpty(selectUpit))
                throw new ArgumentException("Select upit ne sme biti prazan.");

            DataSet ds = new DataSet();

            using (SqlConnection conn = _konekcijaObjekat.DajKonekciju())
            using (SqlCommand cmd = new SqlCommand(selectUpit, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(ds, _nazivTabele);
            }

            return ds;
        }

        public bool IzvrsiAzuriranje(string upit)
        {
            if (string.IsNullOrEmpty(upit))
                return false;

            using (SqlConnection conn = _konekcijaObjekat.DajKonekciju())
            using (SqlCommand cmd = conn.CreateCommand())
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    cmd.Transaction = trans;
                    cmd.CommandText = upit;
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        public bool IzvrsiAzuriranje(List<string> listaUpita)
        {
            if (listaUpita == null || listaUpita.Count == 0)
                return false;

            using (SqlConnection conn = _konekcijaObjekat.DajKonekciju())
            using (SqlCommand cmd = conn.CreateCommand())
            using (SqlTransaction trans = conn.BeginTransaction())
            {
                try
                {
                    cmd.Transaction = trans;

                    foreach (var upit in listaUpita)
                    {
                        cmd.CommandText = upit;
                        cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}

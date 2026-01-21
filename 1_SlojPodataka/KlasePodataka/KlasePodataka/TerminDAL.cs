using System;
using System.Data;
using System.Data.SqlClient;

namespace KlasePodataka
{
    public class TerminDAL
    {
        private string konekcijaString;

        public TerminDAL(string connStr)
        {
            konekcijaString = connStr;
        }

        // Dodaj termin
        public bool DodajTermin(int korisnikID, int trenerID, DateTime datumVreme, decimal trajanjeSati, string ruta, string tezina, decimal cena)
        {
            using (SqlConnection conn = new SqlConnection(konekcijaString))
            using (SqlCommand cmd = new SqlCommand("DodajTermin", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@KorisnikID", korisnikID);
                cmd.Parameters.AddWithValue("@TrenerID", trenerID);
                cmd.Parameters.AddWithValue("@DatumVreme", datumVreme);
                cmd.Parameters.AddWithValue("@TrajanjeSati", trajanjeSati);
                cmd.Parameters.AddWithValue("@Ruta", ruta);
                cmd.Parameters.AddWithValue("@Tezina", tezina);
                cmd.Parameters.AddWithValue("@Cena", cena);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Provera da li je trener zauzet
        public bool TrenerJeZauzet(int trenerID, DateTime datumVreme, decimal trajanjeSati)
        {
            using (SqlConnection conn = new SqlConnection(konekcijaString))
            using (SqlCommand cmd = new SqlCommand("TrenerJeZauzet", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TrenerID", trenerID);
                cmd.Parameters.AddWithValue("@DatumVreme", datumVreme);
                cmd.Parameters.AddWithValue("@TrajanjeSati", trajanjeSati);

                conn.Open();
                int zauzet = Convert.ToInt32(cmd.ExecuteScalar());
                return zauzet > 0;
            }
        }

        // Vrati sve termine
        public DataTable VratiSveTermine()
        {
            using (SqlConnection conn = new SqlConnection(konekcijaString))
            using (SqlCommand cmd = new SqlCommand("VratiSveTermine", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Vrati termine po korisniku
        public DataTable VratiTermineZaKorisnika(int korisnikID)
        {
            using (SqlConnection conn = new SqlConnection(konekcijaString))
            using (SqlCommand cmd = new SqlCommand("VratiTermineZaKorisnika", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDKorisnik", korisnikID);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Vrati termine po treneru
        public DataTable VratiTermineZaTrenera(int trenerID)
        {
            using (SqlConnection conn = new SqlConnection(konekcijaString))
            using (SqlCommand cmd = new SqlCommand("VratiTermineZaTrenera", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDTrener", trenerID);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // Izmeni termin
        public bool IzmeniTermin(int idTermin, int korisnikID, int trenerID, DateTime datumVreme, decimal trajanjeSati, string ruta, string tezina, decimal cena)
        {
            using (SqlConnection conn = new SqlConnection(konekcijaString))
            using (SqlCommand cmd = new SqlCommand("IzmeniTermin", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDTermin", idTermin);
                cmd.Parameters.AddWithValue("@KorisnikID", korisnikID);
                cmd.Parameters.AddWithValue("@TrenerID", trenerID);
                cmd.Parameters.AddWithValue("@DatumVreme", datumVreme);
                cmd.Parameters.AddWithValue("@TrajanjeSati", trajanjeSati);
                cmd.Parameters.AddWithValue("@Ruta", ruta);
                cmd.Parameters.AddWithValue("@Tezina", tezina);
                cmd.Parameters.AddWithValue("@Cena", cena);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        // Obrisi termin
        public bool ObrisiTermin(int idTermin)
        {
            using (SqlConnection conn = new SqlConnection(konekcijaString))
            using (SqlCommand cmd = new SqlCommand("ObrisiTermin", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDTermin", idTermin);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }
    }
}

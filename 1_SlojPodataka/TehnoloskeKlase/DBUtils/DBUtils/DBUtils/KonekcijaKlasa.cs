using System;
using System.Data.SqlClient;

namespace DBUtils
{
    public class KonekcijaKlasa
    {
        private SqlConnection _konekcija;
        private readonly string _putanjaBaze;
        private readonly string _nazivBaze;
        private readonly string _nazivDBMSinstance;
        private readonly string _stringKonekcije;

        public KonekcijaKlasa(string nazivDBMSInstance, string putanjaBaze, string nazivBaze)
        {
            _putanjaBaze = putanjaBaze;
            _nazivBaze = nazivBaze;
            _nazivDBMSinstance = nazivDBMSInstance;
            _stringKonekcije = "";
        }

        public KonekcijaKlasa(string noviStringKonekcije)
        {
            _putanjaBaze = "";
            _nazivBaze = "";
            _nazivDBMSinstance = "";
            _stringKonekcije = noviStringKonekcije;
        }

        private string DajStringKonekcije()
        {
            if (!string.IsNullOrEmpty(_stringKonekcije))
                return _stringKonekcije;

            if (string.IsNullOrEmpty(_putanjaBaze))
                return $"Data Source={_nazivDBMSinstance};Initial Catalog={_nazivBaze};Integrated Security=True";

            return $"Data Source=.\\{_nazivDBMSinstance};AttachDbFilename={_putanjaBaze}\\{_nazivBaze};Integrated Security=True;Connect Timeout=30;User Instance=True";
        }

        public bool OtvoriKonekciju()
        {
            try
            {
                if (_konekcija == null)
                    _konekcija = new SqlConnection(DajStringKonekcije());

                if (_konekcija.State != System.Data.ConnectionState.Open)
                    _konekcija.Open();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Neuspešno otvaranje konekcije: " + ex.Message, ex);
            }
        }

        public SqlConnection DajKonekciju()
        {
            if (_konekcija == null)
            {
                _konekcija = new SqlConnection(DajStringKonekcije());
                _konekcija.Open(); // sigurno otvaranje ako nije otvoreno
            }
            else if (_konekcija.State != System.Data.ConnectionState.Open)
            {
                _konekcija.Open();
            }

            return _konekcija;
        }

        public void ZatvoriKonekciju()
        {
            if (_konekcija != null && _konekcija.State == System.Data.ConnectionState.Open)
            {
                _konekcija.Close();
                _konekcija.Dispose();
                _konekcija = null;
            }
        }
    }
}

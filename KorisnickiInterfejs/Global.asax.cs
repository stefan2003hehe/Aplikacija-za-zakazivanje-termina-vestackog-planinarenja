using System;
using System.Configuration;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public class Global : System.Web.HttpApplication
    {
        public static KorisnikPL KorisnikPLInstance { get; private set; }
        public static TrenerPL TrenerPLInstance { get; private set; }
        public static bool uspehKonekcije { get; private set; }

        void Application_Start(object sender, EventArgs e)
        {
            try
            {
                // Inicijalizacija prezentacione logike
                KorisnikPLInstance = new KorisnikPL();
                TrenerPLInstance = new TrenerPL();

                uspehKonekcije = true;
            }
            catch
            {
                uspehKonekcije = false;
            }
        }
    }
}

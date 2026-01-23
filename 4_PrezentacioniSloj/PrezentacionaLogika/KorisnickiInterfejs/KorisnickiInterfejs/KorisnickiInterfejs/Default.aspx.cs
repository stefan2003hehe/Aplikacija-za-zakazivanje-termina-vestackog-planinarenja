using System;
using System.Web.UI;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class _Default : Page
    {
        private KorisnikPL korisnikPL;
        private TrenerPL trenerPL;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Uzimamo instancu prezentacione logike iz Global klase
            korisnikPL = Global.KorisnikPLInstance;
            trenerPL = Global.TrenerPLInstance;

            // Proveravamo da li su PL objekti inicijalizovani (što znači da je konekcija uspešna)
            if (korisnikPL != null && trenerPL != null)
            {
                lblStatusKonekcije.Text = "USPESNO REALIZOVANA KONEKCIJA!";
            }
            else
            {
                lblStatusKonekcije.Text = "NEUSPESNA KONEKCIJA!";
            }
        }
    }
}

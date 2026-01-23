using System;
using System.Data;
using System.Web.UI;
using PrezentacionaLogika;
using PoslovnaLogika;

namespace KorisnickiInterfejs
{
    public partial class LoginKorisnik : System.Web.UI.Page
    {
        private KorisnikPL korisnikPL;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicijalizacija prezentacione logike
            if (korisnikPL == null)
            {
                korisnikPL = new KorisnikPL(); // PL unutar sebe kreira DAL
            }

            if (!IsPostBack)
            {
                // Ako je korisnik već prijavljen
                if (Session["KorisnikID"] != null && Session["Uloga"]?.ToString() == "Korisnik")
                {
                    Response.Redirect("~/WelcomeKorisnik.aspx");
                }
            }
        }

        protected void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            try
            {
                string korisnickoIme = txtKorisnickoIme.Text.Trim();
                string sifra = txtSifra.Text.Trim();

                if (string.IsNullOrWhiteSpace(korisnickoIme) || string.IsNullOrWhiteSpace(sifra))
                {
                    lblStatus.Text = "Unesite korisničko ime i šifru.";
                    return;
                }

                // Poziv prezentacione logike za prijavu
                bool uspesnaPrijava = korisnikPL.PrijavaKorisnika(korisnickoIme, sifra);

                if (uspesnaPrijava)
                {
                    // Dohvati podatke korisnika preko PL
                    DataTable dtKorisnik = korisnikPL.DajKorisnikaPoKorisnickomImenu(korisnickoIme);

                    if (dtKorisnik.Rows.Count > 0)
                    {
                        int idKorisnik = Convert.ToInt32(dtKorisnik.Rows[0]["IDKorisnik"]);
                        string imePrezime = dtKorisnik.Rows[0]["Ime"].ToString() + " " + dtKorisnik.Rows[0]["Prezime"].ToString();

                        // Postavljanje session varijabli
                        Session["KorisnikID"] = idKorisnik;
                        Session["KorisnikImePrezime"] = imePrezime;
                        Session["Uloga"] = "Korisnik";
                        Session.Timeout = 60;

                        Response.Redirect("~/WelcomeKorisnik.aspx");
                    }
                    else
                    {
                        lblStatus.Text = "Korisnik nije pronađen.";
                    }
                }
                else
                {
                    lblStatus.Text = "Neispravni podaci. Pokušajte ponovo.";
                    txtKorisnickoIme.Text = "";
                    txtSifra.Text = "";
                    txtKorisnickoIme.Focus();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Greška pri prijavi: " + ex.Message;
            }
        }

        protected void btnNazad_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}

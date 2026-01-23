using System;
using System.Data;
using System.Web.UI;
using PrezentacionaLogika;
using PoslovnaLogika;

namespace KorisnickiInterfejs
{
    public partial class LoginTrener : Page
    {
        private TrenerPL trenerPL;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicijalizacija prezentacione logike
            trenerPL = Global.TrenerPLInstance;

            if (!IsPostBack)
            {
                // Ako je trener već prijavljen, preusmeri ga na WelcomeTrener
                if (Session["IDTrener"] != null && Session["Uloga"]?.ToString() == "Trener")
                {
                    Response.Redirect("~/WelcomeTrener.aspx");
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

                // Provera prijave preko prezentacione logike
                bool uspesnaPrijava = trenerPL.PrijavaTrenera(korisnickoIme, sifra);

                if (uspesnaPrijava)
                {
                    // Dohvati podatke trenera po korisničkom imenu
                    DataTable dtTrener = trenerPL.DajTreneraPoKorisnickomImenu(korisnickoIme);
                    if (dtTrener.Rows.Count > 0)
                    {
                        int idTrener = Convert.ToInt32(dtTrener.Rows[0]["IDTrener"]);
                        string imePrezime = dtTrener.Rows[0]["Ime"].ToString() + " " + dtTrener.Rows[0]["Prezime"].ToString();

                        // Postavljanje session varijabli
                        Session["IDTrener"] = idTrener;
                        Session["KorisnikImePrezime"] = imePrezime;
                        Session["Uloga"] = "Trener";
                        Session.Timeout = 60;

                        Response.Redirect("~/WelcomeTrener.aspx");
                    }
                    else
                    {
                        lblStatus.Text = "Ne može se učitati podaci trenera.";
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

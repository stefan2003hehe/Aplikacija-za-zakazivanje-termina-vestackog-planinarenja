using System;
using System.Web.UI;
using PrezentacionaLogika; 

namespace KorisnickiInterfejs
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["KorisnikImePrezime"] != null && Session["Uloga"]?.ToString() == "Admin")
                {
                    Response.Redirect("~/WelcomeAdmin.aspx");
                }
            }
        }

        protected void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            try
            {
                string unetoKorisnickoIme = txtKorisnickoIme.Text.Trim();
                string unetaSifra = txtSifra.Text.Trim();

                if (string.IsNullOrWhiteSpace(unetoKorisnickoIme) || string.IsNullOrWhiteSpace(unetaSifra))
                {
                    lblStatus.Text = "Molimo unesite korisničko ime i šifru.";
                    return;
                }

                AdminAutentifikacija autentifikacija = new AdminAutentifikacija();
                bool isValid = autentifikacija.ProveriAdmina(unetoKorisnickoIme, unetaSifra);

                if (isValid)
                {
                    Session["KorisnikImePrezime"] = unetoKorisnickoIme; 
                    Session["Uloga"] = "Admin";
                    Session.Timeout = 60;
                    Response.Redirect("~/WelcomeAdmin.aspx");
                }
                else
                {
                    lblStatus.Text = "Neispravno korisničko ime ili šifra.";
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

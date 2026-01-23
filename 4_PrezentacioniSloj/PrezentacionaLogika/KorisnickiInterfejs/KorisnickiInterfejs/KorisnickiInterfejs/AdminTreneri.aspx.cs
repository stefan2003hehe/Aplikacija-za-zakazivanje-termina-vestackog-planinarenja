using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;
using PoslovnaLogika;

namespace KorisnickiInterfejs
{
    public partial class AdminTrener : Page
    {
        private TrenerPL trenerPL;

        // Inicijalizacija PL sloja
        private void InicijalizujPL()
        {
            if (trenerPL == null) trenerPL = new TrenerPL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InicijalizujPL();
            if (!IsPostBack)
            {
                PopuniGridView();
            }
        }

        // Popunjavanje GridView
        private void PopuniGridView()
        {
            InicijalizujPL();
            DataTable dt = trenerPL.DajSveTrenere();
            gvTreneri.DataSource = dt;
            gvTreneri.DataBind();
        }

        // Dodavanje novog trenera
        protected void btnDodajTrenera_Click(object sender, EventArgs e)
        {
            InicijalizujPL();
            try
            {
                string ime = txtIme.Text.Trim();
                string prezime = txtPrezime.Text.Trim();
                string pol = txtPol.Text.Trim();
                string telefon = txtTelefon.Text.Trim();
                string email = txtEmail.Text.Trim();
                string sertifikati = txtSertifikati.Text.Trim();
                string korisnickoIme = txtKorisnickoIme.Text.Trim();
                string sifra = txtSifra.Text.Trim();
                decimal satnica;

                if (!decimal.TryParse(txtSatnica.Text.Trim(), out satnica))
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Unesite validnu satnicu.";
                    return;
                }

                if (trenerPL.PostojiTrener(email))
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Trener sa tim email-om već postoji.";
                    return;
                }

                bool uspesno = trenerPL.DodajTrenera(ime, prezime, pol, telefon, email, sertifikati, satnica, korisnickoIme, sifra);
                if (uspesno)
                {
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Trener dodat!";
                    PopuniGridView();

                    // Reset input polja
                    txtIme.Text = txtPrezime.Text = txtPol.Text = txtTelefon.Text =
                    txtEmail.Text = txtSertifikati.Text = txtSatnica.Text = txtKorisnickoIme.Text = txtSifra.Text = "";
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Greška pri dodavanju trenera.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Greška: " + ex.Message;
            }
        }

        // GridView editovanje
        protected void gvTreneri_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTreneri.EditIndex = e.NewEditIndex;
            PopuniGridView();
        }

        protected void gvTreneri_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTreneri.EditIndex = -1;
            PopuniGridView();
        }

        protected void gvTreneri_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            InicijalizujPL();

            GridViewRow row = gvTreneri.Rows[e.RowIndex];
            string id = gvTreneri.DataKeys[e.RowIndex].Value.ToString();

            string ime = ((TextBox)row.FindControl("txtEditIme")).Text.Trim();
            string prezime = ((TextBox)row.FindControl("txtEditPrezime")).Text.Trim();
            string pol = ((TextBox)row.FindControl("txtEditPol")).Text.Trim();
            string telefon = ((TextBox)row.FindControl("txtEditTelefon")).Text.Trim();
            string email = ((TextBox)row.FindControl("txtEditEmail")).Text.Trim();
            string sertifikati = ((TextBox)row.FindControl("txtEditSertifikati")).Text.Trim();
            string korisnickoIme = ((TextBox)row.FindControl("txtEditKorisnickoIme")).Text.Trim();
            string sifra = ((TextBox)row.FindControl("txtEditSifra")).Text.Trim();
            decimal satnica = decimal.Parse(((TextBox)row.FindControl("txtEditSatnica")).Text.Trim());

            bool uspesno = trenerPL.IzmeniTrenera(id, ime, prezime, pol, telefon, email, sertifikati, satnica, korisnickoIme, sifra);

            if (uspesno)
            {
                gvTreneri.EditIndex = -1;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Trener ažuriran!";
                PopuniGridView();
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Greška pri ažuriranju trenera.";
            }
        }

        protected void gvTreneri_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            InicijalizujPL();
            string id = gvTreneri.DataKeys[e.RowIndex].Value.ToString();

            bool uspesno = trenerPL.ObrisiTrenera(id);

            if (uspesno)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Trener obrisan!";
                PopuniGridView();
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Greška pri brisanju trenera.";
            }
        }
    }
}

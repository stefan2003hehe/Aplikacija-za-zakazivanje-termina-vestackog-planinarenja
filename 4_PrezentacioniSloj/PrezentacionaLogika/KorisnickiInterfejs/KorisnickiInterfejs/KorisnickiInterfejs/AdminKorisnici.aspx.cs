using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class AdminKorisnici : Page
    {
        private KorisnikPL korisnikPL;

        private void InicijalizujPL()
        {
            if (korisnikPL == null)
                korisnikPL = new KorisnikPL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InicijalizujPL();
            Page.Title = "Upravljanje korisnicima";

            if (!IsPostBack)
                PopuniGridView();
        }

        private void PopuniGridView()
        {
            gvKorisnici.DataSource = korisnikPL.DajSveKorisnike();
            gvKorisnici.DataBind();
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string ime = txtFilterIme.Text.Trim();
            gvKorisnici.DataSource = !string.IsNullOrEmpty(ime) ? korisnikPL.DajKorisnikePoImenu(ime) : korisnikPL.DajSveKorisnike();
            gvKorisnici.DataBind();
        }

        protected void btnPrikaziSve_Click(object sender, EventArgs e)
        {
            txtFilterIme.Text = "";
            PopuniGridView();
        }

        protected void btnDodajKorisnika_Click(object sender, EventArgs e)
        {
            try
            {
                string ime = txtIme.Text.Trim();
                string prezime = txtPrezime.Text.Trim();
                string pol = txtPol.Text.Trim();
                string telefon = txtTelefon.Text.Trim();
                string email = txtEmail.Text.Trim();
                string korisnickoIme = txtKorisnickoIme.Text.Trim();
                string sifra = txtSifra.Text.Trim();

                if (!DateTime.TryParse(txtDatumRodjenja.Text, out DateTime datumRodjenja))
                {
                    lblStatus.Text = "Unesite validan datum rođenja.";
                    return;
                }

                if (korisnikPL.PostojiKorisnik(email))
                {
                    lblStatus.Text = "Korisnik sa tim email-om već postoji.";
                    return;
                }

                bool uspesno = korisnikPL.DodajKorisnika(ime, prezime, pol, telefon, email, datumRodjenja, korisnickoIme, sifra);
                if (uspesno)
                {
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Korisnik dodat!";
                    PopuniGridView();
                    txtIme.Text = txtPrezime.Text = txtPol.Text = txtTelefon.Text =
                    txtEmail.Text = txtKorisnickoIme.Text = txtSifra.Text = txtDatumRodjenja.Text = "";
                }
                else
                {
                    lblStatus.Text = "Greška pri dodavanju korisnika.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Greška: " + ex.Message;
            }
        }

        protected void gvKorisnici_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvKorisnici.EditIndex = e.NewEditIndex;
            PopuniGridView();
        }

        protected void gvKorisnici_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvKorisnici.EditIndex = -1;
            PopuniGridView();
        }

        protected void gvKorisnici_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvKorisnici.Rows[e.RowIndex];
            string id = gvKorisnici.DataKeys[e.RowIndex].Value.ToString();

            string ime = ((TextBox)row.FindControl("txtEditIme")).Text.Trim();
            string prezime = ((TextBox)row.FindControl("txtEditPrezime")).Text.Trim();
            string pol = ((TextBox)row.FindControl("txtEditPol")).Text.Trim();
            string telefon = ((TextBox)row.FindControl("txtEditTelefon")).Text.Trim();
            string email = ((TextBox)row.FindControl("txtEditEmail")).Text.Trim();
            string korisnickoIme = ((TextBox)row.FindControl("txtEditKorisnickoIme")).Text.Trim();
            string sifra = ((TextBox)row.FindControl("txtEditSifra")).Text.Trim();
            DateTime datumRodjenja = DateTime.Parse(((TextBox)row.FindControl("txtEditDatumRodjenja")).Text.Trim());

            bool uspesno = korisnikPL.IzmeniKorisnika(id, ime, prezime, pol, telefon, email, datumRodjenja, korisnickoIme, sifra);
            if (uspesno)
            {
                gvKorisnici.EditIndex = -1;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Korisnik ažuriran!";
                PopuniGridView();
            }
            else
            {
                lblStatus.Text = "Greška pri ažuriranju korisnika.";
            }
        }

        protected void gvKorisnici_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gvKorisnici.DataKeys[e.RowIndex].Value.ToString();
            bool uspesno = korisnikPL.ObrisiKorisnika(id);
            if (uspesno)
            {
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Korisnik obrisan!";
                PopuniGridView();
            }
            else
            {
                lblStatus.Text = "Greška pri brisanju korisnika.";
            }
        }

        // 🔹 Dugme za parametarsku štampu
        protected void btnStampajPoPolu_Click(object sender, EventArgs e)
        {
            string pol = ddlPol.SelectedValue;
            if (string.IsNullOrEmpty(pol)) return;

            Response.Redirect("StampajPoPolu.aspx?pol=" + pol);
        }
    }
}

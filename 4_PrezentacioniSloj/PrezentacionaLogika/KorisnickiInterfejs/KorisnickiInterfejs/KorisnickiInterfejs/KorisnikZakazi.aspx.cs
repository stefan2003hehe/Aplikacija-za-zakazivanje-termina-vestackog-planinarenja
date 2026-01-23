using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace KorisnickiInterfejs
{
    public partial class KorisnikZakazi : Page
    {
        private TrenerPL trenerPL;
        private TerminPL terminPL;

        protected void Page_Load(object sender, EventArgs e)
        {
            InicijalizujPL();

            if (!IsPostBack)
            {
                if (Session["KorisnikID"] == null)
                    Response.Redirect("~/LoginKorisnik.aspx");

                PopuniDropDownTrener();
            }
        }

        private void InicijalizujPL()
        {
            if (trenerPL == null)
                trenerPL = new TrenerPL();
            if (terminPL == null)
                terminPL = new TerminPL();
        }

        private void PopuniDropDownTrener()
        {
            DataTable dt = trenerPL.DajSveTrenere();
            ddlTrener.Items.Clear();
            ddlTrener.Items.Add(new ListItem("-- Izaberite trenera --", "0"));

            foreach (DataRow row in dt.Rows)
            {
                ListItem item = new ListItem(
                    row["Ime"].ToString() + " " + row["Prezime"].ToString(),
                    row["IDTrener"].ToString()
                );
                item.Attributes["data-satnica"] = row["Satnica"].ToString();
                ddlTrener.Items.Add(item);
            }
        }

        protected void btnZakazi_Click(object sender, EventArgs e)
        {
            lblStatus.ForeColor = System.Drawing.Color.Red;

            try
            {
                // Validacija trenera
                if (ddlTrener.SelectedIndex == 0)
                {
                    lblStatus.Text = "Izaberite trenera.";
                    return;
                }

                // Validacija datuma i vremena
                if (!DateTime.TryParse(txtDatumVreme.Text.Trim(), out DateTime datumVreme))
                {
                    lblStatus.Text = "Unesite validan datum i vreme.";
                    return;
                }

                if (datumVreme <= DateTime.Now)
                {
                    lblStatus.Text = "Ne možete zakazati termin u prošlosti.";
                    return;
                }

                // Validacija trajanja
                if (!decimal.TryParse(txtTrajanje.Text.Trim(), out decimal trajanje) || trajanje <= 0)
                {
                    lblStatus.Text = "Unesite validan broj sati (trajanje > 0).";
                    return;
                }

                string ruta = txtRuta.Text.Trim();
                string tezina = txtTezina.Text.Trim();
                if (string.IsNullOrEmpty(ruta) || string.IsNullOrEmpty(tezina))
                {
                    lblStatus.Text = "Unesite sve potrebne podatke (rutu i težinu).";
                    return;
                }

                int korisnikID = Convert.ToInt32(Session["KorisnikID"]);
                int trenerID = Convert.ToInt32(ddlTrener.SelectedValue);

                // Provera zauzetosti
                if (terminPL.TrenerJeZauzet(trenerID, datumVreme, trajanje))
                {
                    lblStatus.Text = "Trener je zauzet u tom terminu. Izaberite drugi termin.";
                    return;
                }

                DataTable dtTrener = trenerPL.DajTreneraPoID(trenerID.ToString());
                if (dtTrener.Rows.Count == 0)
                {
                    lblStatus.Text = "Trener nije pronađen.";
                    return;
                }

                decimal satnica = Convert.ToDecimal(dtTrener.Rows[0]["Satnica"]);
                decimal cena = satnica * trajanje;
                txtCena.Text = cena.ToString("0.00");

                // Dodavanje termina
                bool uspesno = terminPL.DodajTermin(korisnikID, trenerID, datumVreme, trajanje, ruta, tezina, cena);

                if (uspesno)
                {
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = "Termin uspešno zakazan!";

                    divPrint.InnerHtml = $@"
                        <b>Termin zakazan:</b><br/>
                        Trener: {dtTrener.Rows[0]["Ime"]} {dtTrener.Rows[0]["Prezime"]}<br/>
                        Datum: {datumVreme:yyyy-MM-dd HH:mm}<br/>
                        Trajanje: {trajanje} sati<br/>
                        Ruta: {ruta}<br/>
                        Težina: {tezina}<br/>
                        Cena: {cena:0.00} RSD";
                }
                else
                {
                    lblStatus.Text = "Došlo je do greške prilikom zakazivanja termina.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Greška: " + ex.Message;
            }
        }
    }
}

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

using PoslovnaLogika;

namespace KorisnickiInterfejs
{
    public partial class AdminTermin : Page
    {
        private TerminPL terminPL;
        private KorisnikPL korisnikPL;
        private TrenerPL trenerPL;

        // Inicijalizacija PL sloja
        private void InicijalizujPL()
        {
            if (terminPL == null) terminPL = new TerminPL();
            if (korisnikPL == null) korisnikPL = new KorisnikPL();
            if (trenerPL == null) trenerPL = new TrenerPL();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            InicijalizujPL();

            if (!IsPostBack)
            {
                PopuniGridView();
            }

            // Automatsko izračunavanje cene preko __EVENTTARGET
            string eventTarget = Request["__EVENTTARGET"];
            if (eventTarget == "IzracunajCenu")
            {
                IzracunajCenu();
            }
        }

        // Automatsko izračunavanje cene termina
        private void IzracunajCenu()
        {
            if (int.TryParse(txtIDTrener.Text.Trim(), out int trenerID) &&
                decimal.TryParse(txtTrajanjeSati.Text.Trim(), out decimal trajanje))
            {
                DataTable dtTrener = trenerPL.DajTreneraPoID(trenerID.ToString());
                if (dtTrener.Rows.Count > 0)
                {
                    decimal satnica = Convert.ToDecimal(dtTrener.Rows[0]["Satnica"]);
                    txtCena.Text = (satnica * trajanje).ToString("0.00");
                }
            }
        }

        // Popunjavanje GridView sa opcionalnim filterom po datumu
        private void PopuniGridView(DateTime? filterDatum = null)
        {
            DataTable dt = filterDatum.HasValue ?
                terminPL.DajTermineZaDatum(filterDatum.Value) : terminPL.DajSveTermine();

            if (!dt.Columns.Contains("ImeKorisnika")) dt.Columns.Add("ImeKorisnika", typeof(string));
            if (!dt.Columns.Contains("ImeTrenera")) dt.Columns.Add("ImeTrenera", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                int korisnikID = Convert.ToInt32(row["IDKorisnik"]);
                int trenerID = Convert.ToInt32(row["IDTrener"]);
                row["ImeKorisnika"] = korisnikPL.DajImePoID(korisnikID.ToString());
                row["ImeTrenera"] = trenerPL.DajImePoID(trenerID.ToString());
            }

            gvTermini.DataSource = dt;
            gvTermini.DataBind();
        }

        // Dodavanje novog termina
        protected void btnDodajTermin_Click(object sender, EventArgs e)
        {
            try
            {
                int IDKorisnik = int.Parse(txtIDKorisnik.Text.Trim());
                int IDTrener = int.Parse(txtIDTrener.Text.Trim());
                DateTime datumVreme = DateTime.Parse(txtDatumVreme.Text.Trim());
                decimal trajanjeSati = decimal.Parse(txtTrajanjeSati.Text.Trim());
                string ruta = txtRuta.Text.Trim();
                string tezina = txtTezina.Text.Trim();
                decimal cena = decimal.Parse(txtCena.Text.Trim());

                if (terminPL.TrenerJeZauzet(IDTrener, datumVreme, trajanjeSati))
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Trener je zauzet u tom terminu.";
                    return;
                }

                bool uspesno = terminPL.DodajTermin(IDKorisnik, IDTrener, datumVreme, trajanjeSati, ruta, tezina, cena);
                lblStatus.ForeColor = uspesno ? System.Drawing.Color.Green : System.Drawing.Color.Red;
                lblStatus.Text = uspesno ? "Termin dodat!" : "Greška pri dodavanju termina.";

                if (uspesno)
                {
                    PopuniGridView();
                    txtIDKorisnik.Text = txtIDTrener.Text = txtDatumVreme.Text =
                        txtTrajanjeSati.Text = txtRuta.Text = txtTezina.Text = txtCena.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Greška: " + ex.Message;
            }
        }

        // GridView editovanje
        protected void gvTermini_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTermini.EditIndex = e.NewEditIndex;
            PopuniGridView();
        }

        protected void gvTermini_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTermini.EditIndex = -1;
            PopuniGridView();
        }

        protected void gvTermini_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvTermini.Rows[e.RowIndex];
            int idTermin = Convert.ToInt32(gvTermini.DataKeys[e.RowIndex].Value);

            int IDKorisnik = int.Parse(((TextBox)row.FindControl("txtEditIDKorisnik")).Text.Trim());
            int IDTrener = int.Parse(((TextBox)row.FindControl("txtEditIDTrener")).Text.Trim());
            DateTime datumVreme = DateTime.Parse(((TextBox)row.FindControl("txtEditDatumVreme")).Text.Trim());
            decimal trajanjeSati = decimal.Parse(((TextBox)row.FindControl("txtEditTrajanjeSati")).Text.Trim());
            string ruta = ((TextBox)row.FindControl("txtEditRuta")).Text.Trim();
            string tezina = ((TextBox)row.FindControl("txtEditTezina")).Text.Trim();
            decimal cena = decimal.Parse(((TextBox)row.FindControl("txtEditCena")).Text.Trim());

            if (terminPL.TrenerJeZauzet(IDTrener, datumVreme, trajanjeSati))
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Trener je zauzet u tom terminu.";
                return;
            }

            bool uspesno = terminPL.IzmeniTermin(idTermin, IDKorisnik, IDTrener, datumVreme, trajanjeSati, ruta, tezina, cena);
            gvTermini.EditIndex = -1;
            lblStatus.ForeColor = uspesno ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblStatus.Text = uspesno ? "Termin ažuriran!" : "Greška pri ažuriranju termina.";

            PopuniGridView();
        }

        protected void gvTermini_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idTermin = Convert.ToInt32(gvTermini.DataKeys[e.RowIndex].Value);
            bool uspesno = terminPL.ObrisiTermin(idTermin);
            lblStatus.ForeColor = uspesno ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblStatus.Text = uspesno ? "Termin obrisan!" : "Greška pri brisanju termina.";
            PopuniGridView();
        }
    }
}

using System;
using System.Data;
using System.Web.UI;
using PrezentacionaLogika;
using PoslovnaLogika;

namespace KorisnickiInterfejs
{
    public partial class KorisnikIstorija : Page
    {
        private TerminPL terminPL;
        private KorisnikPL korisnikPL;

        protected void Page_Load(object sender, EventArgs e)
        {
            InicijalizujPL();

            if (!IsPostBack)
            {
                // Provera da li je korisnik ulogovan
                if (Session["KorisnikID"] != null)
                {
                    int idKorisnik = Convert.ToInt32(Session["KorisnikID"]);

                    // Prikaz imena korisnika preko PL sloja
                    string imeKorisnika = korisnikPL.DajImePoID(idKorisnik.ToString());
                    lblKorisnik.Text = "Istorija termina korisnika: " + imeKorisnika;

                    // Učitaj istoriju termina
                    UcitajIstoriju(idKorisnik);
                }
                else
                {
                    Response.Redirect("LoginKorisnik.aspx");
                }
            }
        }

        private void InicijalizujPL()
        {
            if (terminPL == null)
                terminPL = new TerminPL();

            if (korisnikPL == null)
                korisnikPL = new KorisnikPL();
        }

        private void UcitajIstoriju(int idKorisnik)
        {
            try
            {
                // Dohvati sve termine korisnika
                DataTable dtSviTermini = terminPL.DajTermineZaKorisnika(idKorisnik);

                if (dtSviTermini != null && dtSviTermini.Rows.Count > 0)
                {
                    // Filtriraj samo prošle termine
                    DataView dv = new DataView(dtSviTermini);
                    dv.RowFilter = $"DatumVreme <= #{DateTime.Now:MM/dd/yyyy HH:mm:ss}#";

                    DataTable dtIstorija = dv.ToTable();

                    if (dtIstorija.Rows.Count > 0)
                    {
                        gvIstorija.DataSource = dtIstorija;
                        gvIstorija.DataBind();
                        lblPoruka.Text = "";
                    }
                    else
                    {
                        gvIstorija.DataSource = null;
                        gvIstorija.DataBind();
                        lblPoruka.Text = "Trenutno nemate završene termine.";
                    }
                }
                else
                {
                    gvIstorija.DataSource = null;
                    gvIstorija.DataBind();
                    lblPoruka.Text = "Nemate zakazane termine.";
                }
            }
            catch (Exception ex)
            {
                lblPoruka.Text = "Greška pri učitavanju istorije: " + ex.Message;
            }
        }

        protected void btnPocetna_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}

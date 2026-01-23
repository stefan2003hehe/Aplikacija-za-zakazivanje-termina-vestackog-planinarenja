using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;
using PoslovnaLogika;

namespace KorisnickiInterfejs
{
    public partial class KorisnikPrikaziT : Page
    {
        private TrenerPL trenerPL;

        protected void Page_Load(object sender, EventArgs e)
        {
            InicijalizujPL();

            if (!IsPostBack)
            {
                UcitajTrenere();
            }
        }

        // Inicijalizacija PL sloja
        private void InicijalizujPL()
        {
            if (trenerPL == null)
            {
                trenerPL = new TrenerPL();
            }
        }

        // Učitavanje svih trenera u GridView
        private void UcitajTrenere()
        {
            try
            {
                DataTable dt = trenerPL.DajSveTrenere();

                if (dt != null && dt.Rows.Count > 0)
                {
                    gvTreneri.DataSource = dt;
                    gvTreneri.DataBind();
                    lblPoruka.Text = "";
                }
                else
                {
                    gvTreneri.DataSource = null;
                    gvTreneri.DataBind();
                    lblPoruka.Text = "Nema dostupnih trenera u bazi.";
                }
            }
            catch (Exception ex)
            {
                lblPoruka.Text = "Greška pri učitavanju trenera: " + ex.Message;
            }
        }

        protected void gvTreneri_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}

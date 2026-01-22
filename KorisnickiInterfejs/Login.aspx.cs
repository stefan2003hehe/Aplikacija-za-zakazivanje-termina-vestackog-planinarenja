using System;
using System.Web.UI;

namespace KorisnickiInterfejs
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["KorisnikImePrezime"] != null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void btnKorisnik_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginKorisnik.aspx");
        }

        protected void btnTrener_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginTrener.aspx");
        }

        protected void btnAdmin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LoginAdmin.aspx");
        }
    }
}
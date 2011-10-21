using System;

namespace TWeb.Administracao.Prefeituras
{
    public partial class Detalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButtonVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Listagem.aspx");
        }

    }
}
using System;
using System.Web.UI.WebControls;

namespace TWeb.Administracao.Prefeituras
{
    public partial class Listagem : System.Web.UI.Page
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Aderencia { get; set; }
        public int StatusId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewListarPreituras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ceedfc'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=''");
                e.Row.Attributes.Add("style", "cursor:pointer;");
                //e.Row.Attributes.Add("onclick", "location='manter.aspx?id=" + e.Row.Cells[0].Text + "'");
                e.Row.Attributes.Add("onclick", "location='manter.aspx?id=" + ((HiddenField)e.Row.Cells[0].FindControl("Id")).Value + "'");

            }
        }

        protected void GridViewListarPreituras_RowCreated (object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[0].Visible = false;
        }
    }
}
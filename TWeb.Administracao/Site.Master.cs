using System;
using System.Web.Security;

namespace TWeb.Administracao
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}

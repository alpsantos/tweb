using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace TWeb.Administracao.Prefeituras
{
    public partial class Detalhes : System.Web.UI.Page
    {
        private Apresentacao.Detalhes _detalhes;

        public int Id
        {
            set { IdHiddenField.Value = value.ToString(); }
            get { return Convert.ToInt32(IdHiddenField.Value); }
        }

        public string Nome
        {
            set { NomeTextBox.Text = value; }
            get { return NomeTextBox.Text; }
        }

        public int Aderencia
        {
            set { AderenciaTextBox.Text = value.ToString(); }
            get { return Convert.ToInt32(AderenciaTextBox.Text); }
        }

        public int Ordem
        {
            set { OrdemTextBox.Text = value.ToString(); }
            get { return Convert.ToInt32(OrdemTextBox.Text); }
        }

        public int Status
        {
            set
            {
                CarregaStatusDropDownList(value);
            }
            get { return Convert.ToInt32(StatusDropDownList.SelectedValue); }
        }

        public NameValueCollection Documentos
        {
            set { CarregarDocumentosCheckBoxList(value); }
            get { return RetornaDocumentos(); }
        }

        private NameValueCollection RetornaDocumentos()
        {
            NameValueCollection nameValueCollection = new NameValueCollection();

            foreach (ListItem item in DocumentosCheckBoxList.Items)
            {
                if (item.Selected)
                nameValueCollection .Add(item.Text, item.Value);
            }

            return nameValueCollection;
        }

        private void CarregarDocumentosCheckBoxList(NameValueCollection value)
        {
            foreach (ListItem item in DocumentosCheckBoxList.Items)
            {
                if (value[item.Text].Contains("True"))
                    item.Selected = true;
            }
        }

        private void CarregaStatusDropDownList(int value)
        {
            foreach (ListItem item in StatusDropDownList.Items)
            {
                if (item.Value.Contains(value.ToString()))
                {
                    item.Selected = true;
                    return;
                }
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            if (id == 0)
                Response.Redirect("listagem.aspx");

            _detalhes = new Apresentacao.Detalhes();
            _detalhes.BuscarPrefeitura(this, id);


            //NomeTextBox.Text = _detalhes.Nome;
            //AderenciaTextBox.Text = _detalhes.Aderencia.ToString();
            //OrdemTextBox.Text = _detalhes.Ordem.ToString();
            //StatusDropDownList.SelectedIndex = _detalhes.StatusId;

            //DocumentosCheckBoxList.Text = _detalhes.Nome;
        }



        //private void MontarDocumentosCheckBoxList()
        //{
        //    DocumentosCheckBoxList.SelectedIndex = statusId;
        //}
        protected void AtualizarPrefeitura_Click(object sender, EventArgs e)
        {
            _detalhes.AtualizarPrefeitura(this);
        }
    }
}
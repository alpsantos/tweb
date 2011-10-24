using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace TWeb.Administracao.Prefeituras
{
    public partial class Manter : System.Web.UI.Page
    {
        private Apresentacao.Manter _manter;

        public int Id
        {
            set { IdHiddenField.Value = value.ToString(); }
            get { return IdHiddenField.Value == null ? 0 : Convert.ToInt32(IdHiddenField.Value); }
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

        public int DocumentosId
        {
            set { DocumentosIdHiddenField.Value = value.ToString(); }
            get { return DocumentosIdHiddenField.Value == null ? 0 : Convert.ToInt32(DocumentosIdHiddenField.Value); }
        }

        public NameValueCollection Documentos
        {
            set { CarregarDocumentosCheckBoxList(value); }
            get { return RetornaDocumentos(); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);

                if (id != 0)
                {
                    _manter = new Apresentacao.Manter();
                    _manter.BuscarPrefeitura(this, id);
                }
            }
        }

        private NameValueCollection RetornaDocumentos()
        {
            NameValueCollection nameValueCollection = new NameValueCollection();

            foreach (ListItem item in DocumentosCheckBoxList.Items)
            {
                if (item.Selected)
                    nameValueCollection.Add(item.Text, item.Value);
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


        protected void SalvarPrefeitura_Click(object sender, EventArgs e)
        {
            _manter = new Apresentacao.Manter();

            if (IsPostBack)
            {
                if (IdHiddenField.Value == "0")
                    _manter.AdicionarPrefeitura(this);

                else
                    _manter.AtualizarPrefeitura(this);
            }

        }
    }
}
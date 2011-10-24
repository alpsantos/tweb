using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI.WebControls;

namespace TWeb.Administracao.Prefeituras
{
    public partial class Manter : System.Web.UI.Page
    {
        public Manter()
        {
            _manterServico = new ManterServico();
             ErrosMenssagens = new List<string>();
        }

        private ManterServico _manterServico;

        public int Id
        {
            set { IdHiddenField.Value = value.ToString(); }
            get { return String.IsNullOrEmpty(IdHiddenField.Value) ? 0 : Convert.ToInt32(IdHiddenField.Value); }
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
                ConfiguraStatusDropDownList(value);
            }
            get { return Convert.ToInt32(StatusDropDownList.SelectedValue); }
        }

        public int DocumentosId
        {
            set { DocumentosIdHiddenField.Value = value.ToString(); }
            get { return String.IsNullOrEmpty(DocumentosIdHiddenField.Value) ? 0 : Convert.ToInt32(DocumentosIdHiddenField.Value); }
        }

        public NameValueCollection Documentos
        {
            set { ConfiguraDocumentosCheckBoxList(value); }
            get { return RetornaDocumentos(); }
        }

        public List<String> ErrosMenssagens { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]); //todo : parse errado

                if (id != 0)
                {
                    _manterServico = new ManterServico();
                    _manterServico.BuscarPrefeitura(this, id);
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

        private void ConfiguraDocumentosCheckBoxList(NameValueCollection value)
        {
            foreach (ListItem item in DocumentosCheckBoxList.Items)
            {
                if (value[item.Text].Contains("True"))
                    item.Selected = true;
            }
        }

        private void ConfiguraStatusDropDownList(int value)
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
            _manterServico = new ManterServico();

            if (IsPostBack)
            {
                if (IdHiddenField.Value == "0")

                    _manterServico.AdicionarPrefeitura(this);

                else
                    _manterServico.AtualizarPrefeitura(this);

                Validar(this.ErrosMenssagens);

            }

        }

        private void Validar(List<string> errosMenssagens)
        {
            if (errosMenssagens.Count > 0)
            {
                ErrosRepeater.DataSource = errosMenssagens;
                ErrosRepeater.DataBind();
            }
            else
            {
                SucessoMenssagem.DataBind();
            }
        }

    }
}
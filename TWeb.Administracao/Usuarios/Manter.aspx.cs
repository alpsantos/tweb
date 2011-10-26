using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace TWeb.Administracao.Usuarios
{
    public partial class Manter : System.Web.UI.Page
    {
        private ManterServico _manterServico;

        public Manter()
        {
            _manterServico = new ManterServico();
            MenssagensDeErro = new List<string>();
        }

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

        public string Login
        {
            set { LoginTextBox.Text = value; }
            get { return LoginTextBox.Text; }
        }

        public string Email
        {
            set { EmailTextBox.Text = value; }
            get { return EmailTextBox.Text; }
        }

        public string Senha
        {
            set { SenhaTextBox.Text = value; }
            get { return SenhaTextBox.Text; }
        }

        public int Status
        {
            set
            {
                ConfiguraStatusDropDownList(value);
            }
            get { return Convert.ToInt32(StatusDropDownList.SelectedValue); }
        }

        public List<String> MenssagensDeErro { get; set; }

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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["id"]); //todo : parse errado

                if (id != 0)
                {
                    _manterServico = new ManterServico();
                    _manterServico.BuscarUsuario(this, id);
                }
            }
        }

        protected void SalvarUsuario_Click(object sender, EventArgs e)
        {
            _manterServico = new ManterServico();

            if (IsPostBack)
            {
                if (IdHiddenField.Value == "0")

                    _manterServico.AdicionarUsuario(this);

                else
                    _manterServico.AtualizarUsuario(this);

                ExibirMenssagemRetorno(this.MenssagensDeErro);
            }
        }

        private void ExibirMenssagemRetorno(List<string> errosMenssagens)
        {
            if (errosMenssagens.Count > 0)
            {
                ErrosRepeater.DataSource = errosMenssagens;
                ErrosRepeater.DataBind();
                SucessoPanel.Visible = false;
                ErrosRepeater.Visible = true;
            }
            else
            {
                SucessoPanel.Visible = true;
                ErrosRepeater.Visible = false;
            }
        }
    }
}
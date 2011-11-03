using System;
using System.Collections.Generic;

namespace TWeb.Administracao.Glossario
{
    public partial class Manter : System.Web.UI.Page
    {
        public List<string> MenssagensDeErro { get; private set; }

        public int Id
        {
            set { IdHiddenField.Value = value.ToString(); }
            get { return String.IsNullOrEmpty(IdHiddenField.Value) ? 0 : Convert.ToInt32(IdHiddenField.Value); }
        }
        
        public string Conteudo
        {
            get { return GlossarioTextBox.Text; }
            set { GlossarioTextBox.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ManterServico glossarioServico = new ManterServico();
                glossarioServico.BuscarGlossario(this);
            }
        }

        protected void SalvarGlossario_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                ManterServico glossarioServico = new ManterServico();
                glossarioServico.AtualizarGlossario(this);
            }
        }
    }
}
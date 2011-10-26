using System.ComponentModel;

namespace TWeb.Site.Models
{
    public class Documento
    {
        public Documento(TipoDocumento tipoDocumento, bool pendente)
        {
            TipoDocumento = tipoDocumento;
            Pendente = pendente;
            Descricao = Helper.EnumHelper.GetEnumDescription(tipoDocumento);
        }
        public Documento()
        {
        }
        public string Descricao { get; protected set; }
        public string linkDocumento { get; protected set; }
        public bool Pendente { get; protected set; }
        public TipoDocumento TipoDocumento { get; protected set; }
    }

    public enum TipoDocumento : int
    {
        [Description("LDO")]
        LDO = 1,
        [Description("BF")]
        BF = 2,
        [Description("BP")]
        BP = 3,
        [Description("RGF")]
        RGF = 4,
        [Description("RREO")]
        RREO = 5,
        [Description("PPA")]
        PPA = 6,
        [Description("BO")]
        BO = 7,
        [Description("LC")]
        LC = 8,
        [Description("Painel Financeiro")]
        PainelFinanceiro = 9,
        [Description("Parecer TCE")]
        ParecerTCE = 10
    }
}

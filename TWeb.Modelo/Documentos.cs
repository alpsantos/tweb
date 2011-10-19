using TWeb.Infra.Dominio;

namespace TWeb.Modelo
{
    public class Documentos : ObjetoDeValorBase<int>
    {
        public bool LDO { get; set; }
        public bool BF { get; set; }
        public bool BP { get; set; }
        public bool RGF { get; set; }
        public bool RREO { get; set; }
        public bool PPA { get; set; }
        public bool BO { get; set; }
        public bool LC { get; set; }
        public bool PainelFinanceiro { get; set; }
        public bool ParecerTCE { get; set; }


        protected override void Validar()
        {

        }
    }
}

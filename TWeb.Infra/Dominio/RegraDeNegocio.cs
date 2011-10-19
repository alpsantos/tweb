namespace TWeb.Infra.Dominio
{
    public class RegraDeNegocio
    {
        public RegraDeNegocio(string propriedade, string regra)
        {
            this.Propriedade = propriedade;
            this.Regra = regra;
        }

        public string Propriedade { get; set; }
        public string Regra { get; set; }
    }
}
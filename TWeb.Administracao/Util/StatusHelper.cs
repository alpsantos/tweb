namespace TWeb.Administracao.Util
{
    public static class StatusHelper
    {
        public static string TraduzirStatus(object status)
        {
            if (status != null)
            {
                switch (status.ToString())
                {
                    case "1":
                        return "Ativo";
                    case "2":
                        return "Desativado";
                    default:
                        return "Indeterminado";
                }
            }

            return "Indeterminado";
        }
    }
}
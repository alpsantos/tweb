namespace TWeb.Administracao.Servicos
{
    public static class Helper
    {
        public static string ConverterStatus(object status)
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
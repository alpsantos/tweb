using System.Text.RegularExpressions;

namespace TWeb.Modelo.Util
{
    public static class SenhaValidador
    {
        public static bool SenhaValida(string senha)
        {
            if (string.IsNullOrEmpty(senha))
                return false;

            // No minimo 6 caracteres ex:hello123
            const string regexString = @"(?=.{6,})[a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+";

            Regex regex = new Regex(regexString);

            return regex.IsMatch(senha);
        }
    }
}

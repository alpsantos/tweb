using System.Text.RegularExpressions;

namespace TWeb.Modelo.Util
{
    public static class LoginValidador
    {
        public static bool LoginValido(string login)
        {
            if (string.IsNullOrEmpty(login))
                return false;

            // No minimo 6 caracteres ex:usario1010
            const string regexString = @"(?=.{6,})[a-zA-Z]+[^a-zA-Z]+|[^a-zA-Z]+[a-zA-Z]+";

            Regex regex = new Regex(regexString);

            return regex.IsMatch(login);
        }
    }
}

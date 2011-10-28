using System.Text.RegularExpressions;

namespace TWeb.Modelo.Util
{
    public class EmailValidator
    {
        public static bool EmailValido(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            const string regexString = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            Regex regex = new Regex(regexString);

            return regex.IsMatch(email);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Shared.Comum.Extensions
{
    public static class StringExtension
    {
        public static string RmCodigoFormatar(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto) || texto.Length < 5)
                throw new FormatException("A matrícula é inválida");

            return texto.Substring(2, 4);
        }

        public static string GetUntilOrEmpty(this string text, string stopAt = "-")
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int charLocation = text.IndexOf(stopAt, StringComparison.Ordinal);

                if (charLocation > 0)
                    return text.Substring(0, charLocation);
            }

            return string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniocps.Shared.Comum.Collection
{
    public static class ListExtension
    {
        public static string StringMultiline(this List<string> lista)
        {
            if (lista == null || lista.Count == 0)
                return String.Empty;

            return string.Join(Environment.NewLine, lista);
        }
    }
}

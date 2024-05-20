using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Shared.Comum.Extensions
{
    public static class ListExtension
    {
        public static string StringMultiline(this List<string> lista)
        {
            if (lista == null || lista.Count == 0)
                return string.Empty;

            return string.Join(Environment.NewLine, lista);
        }
    }
}

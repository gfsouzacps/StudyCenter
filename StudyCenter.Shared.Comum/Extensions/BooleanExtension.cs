using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCenter.Shared.Comum.Extensions
{
    public static class BooleanExtension
    {
        public static int ToInt(this bool valor)
        {
            return valor ? 1 : 0;
        }
    }
}

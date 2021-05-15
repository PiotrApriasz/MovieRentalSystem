using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class NumberExtensions
    {
        public static int? NullNumber(this string s)
        {
            if (int.TryParse(s, out var i)) return i;
            return null;
        }
    }
}

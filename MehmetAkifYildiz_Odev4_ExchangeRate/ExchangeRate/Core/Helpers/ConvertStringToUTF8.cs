using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public static class ConvertStringToUTF8
    {
        public static string ToUTF8(this string text)
        {
            return Encoding.UTF8.GetString(Encoding.Latin1.GetBytes(text));
        }
    }
}

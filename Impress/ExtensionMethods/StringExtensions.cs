using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Impress.ExtensionMethods
{
    static class StringExtensions
    {
        public static IEnumerable<string> SplitByLength(this string str, int maxLength)
        {
            for (int index = 0; index < str.Length; index += maxLength)
            {
                yield return str.Substring(index, Math.Min(maxLength, str.Length - index));
            }
        }
    }
}

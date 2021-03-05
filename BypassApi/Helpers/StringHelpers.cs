using BypassApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BypassApi.Helpers
{
    public class StringHelpers: IStringHelpers
    {
        public string InvertString(string toInvert)
        {
            if (toInvert == null) return null;
            char[] toInvertArray = toInvert.ToCharArray();
            Array.Reverse(toInvertArray);
            return new string(toInvertArray);
        }
    }
}

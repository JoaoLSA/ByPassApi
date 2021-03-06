using BypassApi.Interfaces;
using System;

namespace BypassApi.Helpers
{
    public class StringHelpers : IStringHelpers
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

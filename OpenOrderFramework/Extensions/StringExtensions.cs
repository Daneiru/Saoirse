using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenOrderFramework.Extensions
{
    public static class StringExtensions
    {
        public static String CleanString(this String inputString) {
            var cleanString = inputString.Replace("(", "")
                                         .Replace(")", "")
                                         .Replace("&", "")
                                         .Replace("-", "")
                                         .Replace(":", "")
                                         .Replace("+", "")
                                         .Replace(",", "")
                                         .Replace(".", "")
                                         .Replace(" ", "")
                                         .Replace("#", "");
            return cleanString;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcVBlog19301330222_2020.Helpers
{
    public static class StringHelper
    {
        public static string Truncate(this String str, int length)
        {
            if (str.Length <= length)
                return str;
            else
                return str.Substring(0, length - 3) + "...";
        }
    }
}
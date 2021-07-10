using System;

namespace VBlog.Helpers
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

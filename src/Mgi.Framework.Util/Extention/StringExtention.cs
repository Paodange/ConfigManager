using System;
using System.Text.RegularExpressions;

namespace Mgi.Framework.Util.Extention
{
    public static class StringExtention
    {
        /// <summary>
        /// 忽略大小写比较
        /// </summary>
        /// <param name="s"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string s, string other)
        {
            if (s == null)
            {
                return false;
            }
            return s.Equals(other, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 正则匹配
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool IsMatch(this string s, string pattern)
        {
            return Regex.IsMatch(s, pattern);
        }

        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}

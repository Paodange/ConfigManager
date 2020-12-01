using System;
using System.Globalization;

namespace Mgi.Framework.Util.Extention
{
    public static class DateTimeExtention
    {
        /// <summary>
        /// 忽略区域选项格式化日期
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string ToStringIgnoreCulture(this DateTime dateTime, string format)
        {
            return dateTime.ToString(format, CultureInfo.InvariantCulture);
        }
    }
}

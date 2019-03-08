using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// EntityHelper 的摘要说明
/// </summary>
namespace SugarDemo.DB
{
    public static class ExtendHelper
    {
        public static string ToStr(this object obj, string def = "")
        {
            if (obj == null) return def;
            else return obj.ToString().Trim();
        }

        /// <summary>
        /// object转换整型，转换失败返回默认值
        /// </summary>
        /// <param name="obj">object对象</param>
        /// <param name="def">默认值为0，可选</param>
        /// <returns></returns>
        public static int ToInt(this object obj, int def = 0)
        {
            if (obj == null) return def;
            try
            {
                return Convert.ToInt32(obj);
            }
            catch (Exception ex)
            {
                int result = 0;
                if (int.TryParse(obj.ToString(), out result)) return result;
                else return def;
            }
        }

        /// <summary>
        /// 判断指定的字符串否空字符串
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static int YearMonthDayToInt(this DateTime date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
        }


    }

}
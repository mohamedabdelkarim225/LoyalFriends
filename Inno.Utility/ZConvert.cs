
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using System.Web;

namespace Inno.Utility
{
    /// <summary>
    /// Convert data type
    /// </summary>
    public static class ZConvert
    {
        #region -- Methods --

        #region -- Numeric --
        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 32-bit signed integer
        /// </summary>
        /// <param name="s">String number</param>
        /// <returns>Return the number</returns>
        public static int ToInt32(this string s)
        {
            int i = 0;
            Int32.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified nullable int representation of a number to an equivalent string 32-bit signed integer
        /// Converts the specified string representation of a number to an equivalent 32-bit signed integer
        /// </summary>
        /// <param name="s">String number</param>
        /// <returns>Return the number (nullable)</returns>
        public static int? ToInt32Null(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return null;
            }
            else
            {
                return s.ToInt32();
            }
        }

        /// <summary>
        /// Converts the specified object representation of a number to an equivalent 32-bit signed integer
        /// </summary>
        /// <param name="o">Object number</param>
        /// <returns>Return the number</returns>
        public static int ToInt32(this object o)
        {
            int i = 0;
            var s = o + string.Empty;
            Int32.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent 64-bit signed integer
        /// </summary>
        /// <param name="s">String number</param>
        /// <returns>Return the number</returns>
        public static long ToInt64(this string s)
        {
            long i = 0;
            Int64.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified object representation of a number to an equivalent 64-bit signed integer
        /// </summary>
        /// <param name="o">Object number</param>
        /// <returns>Return the number</returns>
        public static long ToInt64(this object o)
        {
            long i = 0;
            var s = o + string.Empty;
            Int64.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent float number
        /// </summary>
        /// <param name="s">String number</param>
        /// <returns>Return the number</returns>
        public static float ToFloat(this string s)
        {
            float i = 0;
            Single.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified object representation of a number to an equivalent float number
        /// </summary>
        /// <param name="o">Object number</param>
        /// <returns>Return the number</returns>
        public static float ToFloat(this object o)
        {
            float i = 0;
            var s = o + string.Empty;
            Single.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent double number
        /// </summary>
        /// <param name="s">String number</param>
        /// <returns>Return the number</returns>
        public static double ToDouble(this string s)
        {
            double i = 0;
            Double.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified object representation of a number to an equivalent double number
        /// </summary>
        /// <param name="o">Object number</param>
        /// <returns>Return the number</returns>
        public static double ToDouble(this object o)
        {
            double i = 0;
            var s = o + string.Empty;
            Double.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent decimal number
        /// </summary>
        /// <param name="s">String number</param>
        /// <returns>Return the number</returns>
        public static decimal ToDecimal(this string s)
        {
            decimal i = 0;
            Decimal.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified object representation of a number to an equivalent decimal number
        /// </summary>
        /// <param name="o">Object number</param>
        /// <returns>Return the number</returns>
        public static decimal ToDecimal(this object o)
        {
            decimal i = 0;
            var s = o + string.Empty;
            Decimal.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified string representation of a number to an equivalent boolean
        /// </summary>
        /// <param name="s">String boolean</param>
        /// <returns>Return the boolean</returns>
        public static bool ToBoolean(this string s)
        {
            bool i = false;
            Boolean.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified object representation of a number to an equivalent boolean
        /// </summary>
        /// <param name="o">Object boolean</param>
        /// <returns>Return the boolean</returns>
        public static bool ToBoolean(this object o)
        {
            bool i = false;
            var s = o + string.Empty;
            Boolean.TryParse(s, out i);
            return i;
        }
        #endregion

        #region -- DateTime --
        /// <summary>
        /// Converts the specified string representation of a number to an equivalent date and time
        /// </summary>
        /// <param name="s">String DateTime</param>
        /// <returns>Return the DateTime</returns>
        public static DateTime ToDateTime(this string s)
        {
            var i = DateTime.Now;
            DateTime.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified object representation of a number to an equivalent date and time
        /// </summary>
        /// <param name="o">Object DateTime</param>
        /// <returns>Return the DateTime</returns>
        public static DateTime ToDateTime(this object o)
        {
            var i = DateTime.Now;
            var s = o + string.Empty;
            DateTime.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Convert DateTime to string with format dd-MMM-yyyy
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrDate(this DateTime d)
        {
            var res = d.ToString(DateTimeFormat.Date);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format hh:mm tt
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrTime(this DateTime d)
        {
            var res = d.ToString(DateTimeFormat.TimeNoSec);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format hh:mm tt
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrTime(this DateTime? d)
        {
            if (d == null)
            {
                return string.Empty;
            }
            var res = d.Value.ToString(DateTimeFormat.TimeNoSec);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format dd-MMM-yyyy hh:mm tt
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrDateTime(this DateTime d)
        {
            var res = d.ToString(DateTimeFormat.DateTimeNoSecond);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format dd-MM-yyyy hh:mm tt
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrDateTime(this DateTime? d)
        {
            if (d == null)
            {
                return string.Empty;
            }
            var res = d.Value.ToString(DateTimeFormat.DateTimeNoSecond);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format dd-MMM-yyyy
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrDate(this DateTime? d)
        {
            if (d == null)
            {
                return string.Empty;
            }
            var res = d.Value.ToString(DateTimeFormat.Date);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrSqlDateTime(this DateTime d)
        {
            var res = d.ToString(DateTimeFormat.SqlDateTime);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrSqlDateTime(this DateTime? d)
        {
            var res = d == null ? string.Empty : d.Value.ToString(DateTimeFormat.SqlDateTime);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format yyyy/MM/dd HH:mm:ss
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrIsoDateTime(this DateTime d)
        {
            var res = d.ToString(DateTimeFormat.IsoDateTime);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format yyyy/MM/dd HH:mm:ss
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrIsoDateTime(this DateTime? d)
        {
            var res = d == null ? string.Empty : d.Value.ToString(DateTimeFormat.IsoDateTime, CultureInfo.InvariantCulture);
            return res;
        }
        /// <summary>
        /// SubtracionTwoDate
        /// </summary>
        /// <param name="a, b">Two DateTime object</param>
        /// <returns>Return the string day hrs mins</returns>
        public static string SubtracionTwoDate(DateTime a, DateTime b)
        {
            if (a == null || b == null)
            {
                return SpecialString.Hyphen;
            }
            var res = a - b;
            string strRes = string.Empty;
            if (res.Days > 0)
            {
                strRes = String.Format("{0} day {1} hrs {2} mins", res.Days, res.Hours, res.Minutes);
            }
            else if (res.Days <= 0 && res.Hours > 0)
            {
                strRes = String.Format("{0} hrs {1} mins", res.Hours, res.Minutes);
            }
            else
            {
                strRes = String.Format("{0} mins", res.Minutes);
            }
            return strRes;
        }

        /// <summary>
        /// Convert DateTime to string with format yyyy/MM/dd HH:mm
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrDateTimeNoSecond(this DateTime d)
        {
            var res = d.ToString(DateTimeFormat.SqlDateTimeNoSecond);
            return res;
        }

        /// <summary>
        /// Convert DateTime to string with format yyyy/MM/dd HH:mm
        /// </summary>
        /// <param name="d">DateTime object</param>
        /// <returns>Return the string</returns>
        public static string ToStrDateTimeNoSecond(this DateTime? d)
        {
            var res = d == null ? string.Empty : d.Value.ToString(DateTimeFormat.SqlDateTimeNoSecond, CultureInfo.InvariantCulture);
            return res;
        }

        #endregion

        #region -- String --
        /// <summary>
        /// Return a copy of this string with first letter converted to uppercase
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>Return uppercase first letter</returns>
        public static string ToUpperFirst(this string s)
        {
            try
            {
                s = s.Trim();
                if (String.IsNullOrEmpty(s)) return String.Empty;
                return Char.ToUpper(s[0]) + s.Substring(1);
            }
            catch { return s; }
        }

        /// <summary>
        /// Return a copy of this string with first letter of each word converted to uppercase
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>Return uppercase first letter of any words</returns>
        public static string ToUpperWords(this string s)
        {
            try
            {
                s = s.Trim();
                var arr = s.ToCharArray();
                if (arr.Length >= 1)
                    if (Char.IsLower(arr[0]))
                        arr[0] = Char.ToUpper(arr[0]);
                for (var i = 1; i < arr.Length; i++)
                {
                    if (arr[i - 1] == SpecialChar.Space)
                        if (Char.IsLower(arr[i]))
                            arr[i] = Char.ToUpper(arr[i]);
                }
                return new string(arr);
            }
            catch { return s; }
        }

        /// <summary>
        /// Convert the object to string with format
        /// </summary>
        /// <param name="o">Object</param>
        /// <param name="f">Format type</param>
        /// <returns>Return the string</returns>
        public static string ToStr(this object o, Format f = Format.Orginal)
        {
            try
            {
                var c = o.ToStr();
                switch (f)
                {
                    case Format.Sentence: return c.ToUpperFirst();
                    case Format.Lower: return c.ToLower();
                    case Format.Upper: return c.ToUpper();
                    case Format.Capitalized: return c.ToUpperWords();
                    default: return c;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Convert the object to string
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>Return the string</returns>
        public static string ToStr(this object o)
        {
            var s = o == null ? string.Empty : o.ToString();
            return s;
        }

        /// <summary>
        /// Add one space AbCd to Ab Cd
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns>Return string with space</returns>
        public static string ToAddSpace(this string s)
        {
            var c = string.Empty;
            for (int i = 0; i < s.Length; i++)
            {
                if ('A' <= s[i] && s[i] <= 'Z')
                {
                    c += SpecialString.Space;
                }
                c += s[i];
            }
            return c.Trim();
        }

        /// <summary>
        /// Standardize string
        /// </summary>
        /// <param name="s">A string</param>
        /// <returns>Return the standardized string</returns>
        public static string Standardize(this string s)
        {
            s = s + string.Empty;
            s = s.Replace(SpecialString.Quotation, string.Empty);
            s = s.Replace(SpecialString.LeftSquare, string.Empty);
            s = s.Replace(SpecialString.RightSquare, string.Empty);
            return s;
        }

        /// <summary>
        /// Remove string at last
        /// </summary>
        /// <param name="s">String data</param>
        /// <param name="remove">String need to remove</param>
        /// <param name="replace">String will replace</param>
        /// <returns>Return the string removed</returns>
        public static string RemoveLast(this string s, string remove,
            string replace = SpecialString.Blank)
        {
            try
            {
                var i = s.LastIndexOf(remove);
                if (i >= 0 && s.Length >= i)
                {
                    s = s.Substring(0, i) + replace;
                }
            }
            catch
            {
                s = replace;
            }
            return s;
        }

        /// <summary>
        /// Get default value if input null or empty
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d">Default value</param>
        /// <returns>Return the string</returns>
        public static string ToStrDefault(this string s, string d = SpecialString.Hyphen)
        {
            s = (s + string.Empty).Trim();
            if (string.IsNullOrEmpty(s))
            {
                s = d;
            }
            return s;
        }

        /// <summary>
        /// Converts the specified nullable int representation of a number to an equivalent string 32-bit signed integer
        /// </summary>
        /// <param name="i">Nullable number</param>
        /// <returns>Return the string number</returns>
        public static string ToStrInt32(this int? i)
        {
            var j = i.ToInt32();
            return j == 0 ? string.Empty : j.ToString();
        }

        /// <summary>
        /// Replace "\r\n" to br tag
        /// </summary>
        /// <param name="s">Input string</param>
        /// <returns>Return a string</returns>
        public static string ReplaceCRToBr(this string s)
        {
            s += string.Empty;
            return s.Replace(SpecialString.CarriageReturn, SpecialString.BrTag);
        }

        /// <summary>
        /// Convert number to string percent (e.g: 1.5 -> 1.5%)
        /// </summary>
        /// <param name="i">Number need to convert</param>
        /// <returns>Return the string percent</returns>
        public static string ToStrPercent(this double i)
        {
            return i.ToString("P1").Replace(SpecialString.Space, string.Empty);
        }
        #endregion

        #region -- Guid --
        /// <summary>
        /// Converts the specified string representation of a number to an equivalent Guid
        /// </summary>
        /// <param name="s">String</param>
        /// <returns>Return Guid (if error Guid.Empty)</returns>
        public static Guid ToGuid(this string s)
        {
            var i = Guid.Empty;
            Guid.TryParse(s, out i);
            return i;
        }

        /// <summary>
        /// Converts the specified object representation of a number to an equivalent Guid
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>Return Guid (if error Guid.Empty)</returns>
        public static Guid ToGuid(this object o)
        {
            var i = Guid.Empty;
            Guid.TryParse(o + SpecialString.Space, out i);
            return i;
        }
        #endregion

        #region -- Data --
        /// <summary>
        /// Convert a string number with separation to list number
        /// </summary>
        /// <param name="s">String number separation</param>
        /// <param name="sep">Separation (default is semicolon)</param>
        /// <returns>Return list number</returns>
        public static List<int> ToListInt32(this string s, char sep = SpecialChar.Semicolon)
        {
            s += string.Empty;
            var c = new char[] { sep };
            var res = new List<int>();
            var arr = s.Split(c, StringSplitOptions.RemoveEmptyEntries);

            foreach (var i in arr)
            {
                res.Add(i.ToInt32());
            }

            return res;
        }

        /// <summary>
        /// Convert a list number to string number with separation
        /// </summary>
        /// <param name="list">List number</param>
        /// <param name="sep">Separation (default is semicolon)</param>
        /// <returns>Return the string number with separation</returns>
        public static string ToStrSeparation(this List<int> list, char sep = SpecialChar.Semicolon)
        {
            var res = string.Empty;

            if (list == null)
            {
                list = new List<int>();
            }

            foreach (var i in list)
            {
                res += i + sep;
            }

            return res;
        }

        /// <summary>
        /// Convert from IEnumerable (LINQ, List object) to DataTable
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="d">Data</param>
        /// <param name="s">Table name</param>
        /// <returns>Return a DataTable</returns>
        public static DataTable ToDataTable<T>(this IEnumerable<T> d, string s = SpecialString.Blank)
        {
            var properties = typeof(T).GetProperties();
            var dt = new DataTable(s);

            // Add columns
            foreach (var i in properties)
            {
                var c = new DataColumn(i.Name, GetNullableType(i.PropertyType));
                dt.Columns.Add(c);
            }

            // Add rows
            foreach (T t in d)
            {
                var row = dt.NewRow();
                foreach (var i in properties)
                {
                    if (!IsNullableType(i.PropertyType))
                    {
                        row[i.Name] = i.GetValue(t, null);
                    }
                    else
                    {
                        row[i.Name] = (i.GetValue(t, null) ?? DBNull.Value);
                    }
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        /// <summary>
        /// Create CSV file from list
        /// </summary>
        /// <typeparam name="T">Data type</typeparam>
        /// <param name="list">Data list</param>
        /// <param name="file">Full path file name</param>
        /// <returns>Return status can create or not</returns>
        public static bool ToCSV<T>(this List<T> list, string file)
        {
            try
            {
                if (list == null || list.Count == 0)
                {
                    var sw = new StreamWriter(file);
                    sw.Write("No data");
                }

                // Get type from 0th member
                var t = list[0].GetType();
                var newLine = Environment.NewLine;

                using (var sw = new StreamWriter(file))
                {
                    // Make a new instance of the class name we figured out to get its props
                    var o = Activator.CreateInstance(t);

                    // Gets all properties
                    var props = o.GetType().GetProperties();

                    // Foreach of the properties in class above, write out properties
                    // this is the header row
                    foreach (var pi in props)
                    {
                        sw.Write(pi.Name.ToUpper() + SpecialString.Comma);
                    }
                    sw.Write(newLine);

                    // This acts as datarow
                    foreach (T item in list)
                    {
                        // This acts as datacolumn
                        foreach (PropertyInfo pi in props)
                        {
                            // This is the row+col intersection (the value)
                            var tmp = item.GetType().GetProperty(pi.Name).GetValue(item, null)
                                + string.Empty;
                            var res = tmp.Replace(SpecialChar.Comma, SpecialChar.Space)
                                + SpecialChar.Comma;

                            sw.Write(res);
                        }
                        sw.Write(newLine);
                    }
                }
            }
            catch { return false; }
            return true;
        }

        /// <summary>
        /// Convert from DataTable to HTML table
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>Return the HTML table</returns>
        public static string ToHTML(this DataTable dt)
        {
            string html = "<table>";

            // Add header row
            html += "<tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            }
            html += "</tr>";

            // Add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                }
                html += "</tr>";
            }
            html += "</table>";

            return html;
        }

        /// <summary>
        /// Get nullable type
        /// </summary>
        /// <param name="t">Class type</param>
        /// <returns>Return the Type</returns>
        private static Type GetNullableType(Type t)
        {
            var res = t;
            if (t.IsGenericType
                && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                res = Nullable.GetUnderlyingType(t);
            }
            return res;
        }

        /// <summary>
        /// Is nullable type
        /// </summary>
        /// <param name="type">Class type</param>
        /// <returns>Return the result</returns>
        private static bool IsNullableType(Type type)
        {
            var res = type == typeof(string)
                || type.IsArray
                || (type.IsGenericType
                    && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
            return res;
        }
        #endregion

        #region -- Enums --
        /// <summary>
        /// Convert a string value to enum value
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="value">Value need to convert</param>
        /// <param name="defaultValue">Default value</param>
        /// <returns>Return the enum value</returns>
        public static T ToEnum<T>(this string value, T defaultValue)
        {
            if (!typeof(T).IsEnum)
            {
                return defaultValue;
            }

            try
            {
                return (T)Enum.Parse(typeof(T), value);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static T ToEnumFromDesc<T>(this string description, T defaultValue)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            return defaultValue;
        }

        /// <summary>
        /// Get enum description
        /// </summary>
        /// <param name="value">Value of enum</param>
        /// <returns>Return the description</returns>
        public static string ToDescription(this Enum value)
        {
            var val = value.ToString();
            var fi = value.GetType().GetField(val);
            var attributes = (DescriptionAttribute[])fi
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                val = attributes[0].Description;
            }
            return val;
        }
        

        /// <summary>
        /// Get enum description
        /// </summary>
        /// <typeparam name="T">Enum type</typeparam>
        /// <param name="value">Value of enum</param>
        /// <returns>Return the description</returns>
        public static string ToDescription<T>(this string value)
        {
            var type = typeof(T);
            var name = Enum.GetNames(type)
                .Where(p => p.Equals(value, StringComparison.CurrentCultureIgnoreCase))
                .Select(p => p)
                .FirstOrDefault();

            if (name == null)
            {
                return value;
            }

            var field = type.GetField(name);
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : name;
        }
        #endregion

        #region -- PredicateBuilder --
        /// <summary>
        /// Get null expression
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <returns>Return the null expression</returns>
        public static Expression<Func<T, bool>> Get<T>()
        {
            return null;
        }

        /// <summary>
        /// Get expression
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="predicate">Predicate expression</param>
        /// <returns>Return the expression</returns>
        public static Expression<Func<T, bool>> Get<T>(this Expression<Func<T, bool>> predicate)
        {
            return predicate;
        }

        /// <summary>
        /// Get And expression
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="or">Or expression</param>
        /// <returns>Return the Or expression</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr,
            Expression<Func<T, bool>> or)
        {
            if (expr == null)
            {
                return or;
            }

            Replace(or, or.Parameters[0], expr.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.Or(expr.Body, or.Body), expr.Parameters);
        }

        /// <summary>
        /// Get And expression
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="expr">Expression</param>
        /// <param name="and">And expression</param>
        /// <returns>Return the And expression</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr,
            Expression<Func<T, bool>> and)
        {
            if (expr == null)
            {
                return and;
            }

            Replace(and, and.Parameters[0], expr.Parameters[0]);
            return Expression.Lambda<Func<T, bool>>(Expression.And(expr.Body, and.Body), expr.Parameters);
        }

        /// <summary>
        /// Sort query
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="q">Query</param>
        /// <param name="sorts">List field sort</param>
        /// <returns>Return the sort query</returns>
        public static IOrderedQueryable<T> Sort<T>(this IOrderedQueryable<T> q, List<ZPaging.Sort> sorts)
        {
            var param = Expression.Parameter(typeof(T));

            if (sorts == null)
            {
                sorts = new List<ZPaging.Sort>();
            }

            foreach (var s in sorts)
            {
                var property = Expression.PropertyOrField(param, s.Field);
                var sort = Expression.Lambda(property, param);

                var direction = s.Direction == ListSortDirection.Ascending.ToString()
                    ? string.Empty : ListSortDirection.Descending.ToString();

                var method = sorts.IndexOf(s) == 0 ? OrderBy : ThenBy;
                method += direction;

                var call = Expression.Call(typeof(Queryable),
                    method, new[] { typeof(T), property.Type },
                    q.Expression, Expression.Quote(sort));
                q = (IOrderedQueryable<T>)q.Provider.CreateQuery<T>(call);
            }

            return q;
        }

        /// <summary>
        /// Sort query 2
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="q">Query</param>
        /// <param name="sorts">List field sort</param>
        /// <returns>Return IQueryable the sort query</returns>
        public static IQueryable<T> Sort2<T>(this IQueryable<T> q, List<ZPaging.Sort> sorts)
        {
            var param = Expression.Parameter(typeof(T));

            if (sorts == null)
            {
                sorts = new List<ZPaging.Sort>();
            }

            foreach (var s in sorts)
            {
                var property = Expression.PropertyOrField(param, s.Field);
                var sort = Expression.Lambda(property, param);

                var direction = s.Direction == ListSortDirection.Ascending.ToString()
                    ? string.Empty : ListSortDirection.Descending.ToString();

                var method = sorts.IndexOf(s) == 0 ? OrderBy : ThenBy;
                method += direction;

                var call = Expression.Call(typeof(Queryable),
                    method, new[] { typeof(T), property.Type },
                    q.Expression, Expression.Quote(sort));
                q = (IQueryable<T>)q.Provider.CreateQuery<T>(call);
            }

            return q;
        }

        /// <summary>
        /// Replace object support Or method
        /// </summary>
        /// <param name="o">Current instance object</param>
        /// <param name="old">Old object</param>
        /// <param name="new">New object</param>
        private static void Replace(this object o, object old, object @new)
        {
            for (var t = o.GetType(); t != null; t = t.BaseType)
            {
                var flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
                var fInfo = t.GetFields(flag);

                foreach (var fi in fInfo)
                {
                    object val = fi.GetValue(o);
                    if (val != null && val.GetType().Assembly == typeof(Expression).Assembly)
                    {
                        if (object.ReferenceEquals(val, old))
                        {
                            fi.SetValue(o, @new);
                        }
                        else
                        {
                            Replace(val, old, @new);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// OrderBy support Sort method
        /// </summary>
        private const string OrderBy = "OrderBy";

        /// <summary>
        /// ThenBy support Sort method
        /// </summary>
        private const string ThenBy = "ThenBy";
        #endregion


        #region -- File --

        /// <summary>
        /// Convert size to string file size
        /// </summary>
        /// <param name="size">Size</param>
        /// <returns>Return string file size</returns>
        public static string ToFileSize(this decimal size)
        {
            if (size >= MB)
            {
                size = Math.Round(size / MB, 2);
                return string.Format("{0:0.##} MB", size);
            }
            else if (size >= KB)
            {
                size = Math.Round(size / KB, 2);
                return string.Format("{0:0.##} KB", size);
            }

            return string.Format("{0} bytes", size);
        }

        /// <summary>
        /// Convert to mime type
        /// </summary>
        /// <param name="s">File extension</param>
        /// <returns>Return the mime type</returns>
        public static string ToMimeType(this string s)
        {
            s = s.ToStr(Format.Lower);
            var res = MimeType.Where(p => s.Equals(p.Suffixes)).Select(p => p.Mime);
            return res.FirstOrDefault();
        }

        /// <summary>
        /// Convert to base64 string from the image path file name
        /// </summary>
        /// <param name="pathFile">The image path file name</param>
        /// <returns>Return base64 string</returns>
        public static string ToBase64Image(this string pathFile)
        {
            var res = string.Empty;

            if (File.Exists(pathFile))
            {
                var bytes = File.ReadAllBytes(pathFile);
                var base64 = Convert.ToBase64String(bytes);
                res = string.Format(StringFormat.ImageBase64, base64);
            }

            return res;
        }

        /// <summary>
        /// Returns the names of files (including their paths)
        /// that match the specified search pattern in the specified directory,
        /// using a value to determine whether to search subdirectories
        /// </summary>
        /// <param name="strPath">Path</param>
        /// <param name="strPattern">Filter condition</param>
        /// <param name="optSearch">Search option</param>
        /// <param name="strFilter">Array skip</param>
        /// <param name="booSkip">Skip or take filter condition</param>
        /// <returns>Return the list files</returns>
        public static List<string> ToFiles(this string strPath, string strPattern,
            SearchOption optSearch, string[] strFilter, bool booSkip = true)
        {
            var list = new List<string>();
            try
            {
                var files = Directory.GetFiles(strPath, strPattern, optSearch);
                foreach (var i in files)
                {
                    bool next = false;
                    if (booSkip)
                    {
                        foreach (var s in strFilter)
                            if (i.Contains(s) == booSkip)
                            {
                                next = true;
                                break;
                            };
                        if (next) continue;
                        list.Add(i);
                    }
                    else
                    {
                        foreach (var s in strFilter)
                            if (i.Contains(s) == booSkip)
                            {
                                next = true;
                                break;
                            }
                            else list.Add(i);
                        if (next) continue;
                    }
                }
            }
            catch { }

            return list;
        }

        /// <summary>
        /// Get list mime type from XML file
        /// </summary>
        private static List<Extension> MimeType
        {
            get
            {
                if (_mimeType != null && _mimeType.Count > 0)
                {
                    return _mimeType;
                }
                else
                {
                    try
                    {
                        var a = AppDomain.CurrentDomain.BaseDirectory + "/bin/";
                        var xdoc = XDocument.Load(a + "FileExtensions.xml");
                        var res = from lv1 in xdoc.Descendants("Extension")
                                  select new Extension
                                  {
                                      Suffixes = lv1.Attribute("Suffixes").Value,
                                      Mime = lv1.Attribute("Mime").Value
                                  };
                        _mimeType = res.ToList();
                    }
                    catch
                    {
                        _mimeType = new List<Extension>();
                    }
                    return _mimeType;
                }
            }
        }

        /// <summary>
        /// List mime type
        /// </summary>
        private static List<Extension> _mimeType;

        /// <summary>
        /// Byte size
        /// </summary>
        private const decimal KB = 1024, MB = KB * 1024;

        /// <summary>
        /// Extension
        /// </summary>
        private class Extension
        {
            /// <summary>
            /// Suffixes
            /// </summary>
            public string Suffixes { get; set; }

            /// <summary>
            /// Mime file type
            /// </summary>
            public string Mime { get; set; }
        }

        #endregion

       

       
        

        /// <summary>
        /// Convert Yes or No to boolean
        /// </summary>
        /// <param name="s">Input Yes or No</param>
        /// <returns>Return a boolean value</returns>
        public static bool ToBool(this string s)
        {
            var a = DefaultValue.Yes.ToString().ToLower();
            var b = (s + string.Empty).ToLower();
            return a.Equals(b);
        }

        /// <summary>
        /// Convert boolean to Yes or No
        /// </summary>
        /// <param name="b">Boolean value</param>
        /// <returns>Return a string Yes or No</returns>
        public static string ToYesNo(this bool? b)
        {
            var a = b ?? false;
            return a.ToYesNo();
        }

        /// <summary>
        /// Convert boolean to Yes or No
        /// </summary>
        /// <param name="b">Boolean value</param>
        /// <returns>Return a string Yes or No</returns>
        public static string ToYesNo(this bool b)
        {
            var a = b ? DefaultValue.Yes : DefaultValue.No;
            return a.ToString();
        }


        public static List<string> ListContentType()
        {
            var list = new List<string> {
                "application/msword",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/vnd.ms-excel",
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "application/vnd.ms-powerpoint",
                "application/vnd.openxmlformats-officedocument.presentationml.presentation",
                "application/pdf",
                "text/plain",
                "image/bmp",
                "image/png",
                "image/gif",
                "image/jpeg",
                "video/mp4", //20180601 Frederick
            };
            return list;
        }

        public static DateTime? AddLocalTimeOffset(this DateTime? serverDate, int offset, string columnName)
        {
            if (!serverDate.HasValue) return serverDate;
            if (serverDate.HasValue)
            {
                if (serverDate.Value.Date == DateTime.MinValue) return serverDate;
                if (serverDate.Value.Date == DateTime.MaxValue) return serverDate;

                if (serverDate.Value.TimeOfDay == TimeSpan.Zero) return serverDate;

                if(string.IsNullOrEmpty(columnName) || !IgnoreAddLocalTimeOffset.Columns.Contains(columnName))
                {
                    return new DateTime((serverDate.Value.AddMinutes(offset).Ticks / 100000 * 100000) + 12345, serverDate.Value.Kind);
                }
            }

            return serverDate;
        }

    
        #endregion
    }
}
#region Information
/*
 * Author       : Zng Tfy
 * Email        : nvt87x@gmail.com
 * Phone        : +84 1645 515 010
 * ------------------------------- *
 * Create       : 13/10/2015 19:25
 * Update       : 01/03/2017 20:12
 * Checklist    : 1.0
 * Status       : OK
 */
#region License
/**************************************************************************************************************
 * Copyright © 2012-2017 SKG™ all rights reserved
 **************************************************************************************************************/
#endregion
#region Description
/**************************************************************************************************************
 * Time
 **************************************************************************************************************/
#endregion
#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Inno.Utility
{
    /// <summary>
    /// Time
    /// </summary>
    public static class ZTime
    {
        #region -- Methods --

        #region -- Checks --
        /// <summary>
        /// Check between from and to date time
        /// </summary>
        /// <param name="d">Date time need to check</param>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <returns>Return the result checked</returns>
        public static bool CheckBetween(this DateTime d, DateTime fr, DateTime to)
        {
            return (d >= fr && d <= to);
        }

        /// <summary>
        /// Check same day
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <returns>Return the result checked</returns>
        public static bool CheckSameDay(this DateTime fr, DateTime to)
        {
            var a = (fr.Date == to.Date);
            return a;
        }

        /// <summary>
        /// Check same month
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <returns>Return the result checked</returns>
        public static bool CheckSameMonth(this DateTime fr, DateTime to)
        {
            var a = (fr.Month == to.Month && fr.Year == to.Year);
            return a;
        }

        /// <summary>
        /// Check same year
        /// </summary>
        /// <param name="fr">From date time</param>
        /// <param name="to">To date time</param>
        /// <returns>Return the result checked</returns>
        public static bool CheckSameYear(this DateTime fr, DateTime to)
        {
            var a = (fr.Year == to.Year);
            return a;
        }
        #endregion

        #region -- Runs --
        /// <summary>
        /// Increment a second
        /// </summary>
        private static void Increment()
        {
            if (Now == new DateTime()) Now = DateTime.Now;
            if (Now.Millisecond >= 500) Now = Now.AddSeconds(1);

            while (!_stop)
            {
                Thread.Sleep(1000);
                Now = Now.AddSeconds(1);
            }
        }

        /// <summary>
        /// Start counter
        /// </summary>
        public static void Start()
        {
            var a = new ThreadStart(Increment);
            var b = new Thread(a);
            b.Start();
        }

        /// <summary>
        /// Stop counter
        /// </summary>
        public static void Stop() { _stop = true; }
        #endregion

        #region -- Years --
        /// <summary>
        /// Return a start of year of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <returns>Return a start of year</returns>
        public static DateTime ToStartOfYear(this int y)
        {
            return new DateTime(y, 1, 1).Date;
        }

        /// <summary>
        /// Return a end of year of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <returns>Return a end of year</returns>
        public static DateTime ToEndOfYear(this int y)
        {
            return new DateTime(y, 12, 31).ToEndOfDay();
        }

        /// <summary>
        /// Return a copy of this DateTime to start of year
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns>Return a start of year</returns>
        public static DateTime ToStartOfYear(this DateTime d)
        {
            return d.Year.ToStartOfYear();
        }

        /// <summary>
        /// Return a copy of this DateTime to end of year
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns>Return a end of year</returns>
        public static DateTime ToEndOfYear(this DateTime d)
        {
            return d.Year.ToEndOfYear();
        }

        /// <summary>
        /// Get year list from to
        /// </summary>
        /// <param name="fr">From year</param>
        /// <param name="to">To year</param>
        /// <returns>Return the list of year</returns>
        public static List<int> ToYearList(int fr, int to)
        {
            if (fr < DefaultValue.MinYear)
            {
                fr = DefaultValue.MinYear;
            }
            if (to > DefaultValue.MaxYear)
            {
                to = DefaultValue.MaxYear;
            }
            var a = new List<int>();
            for (int i = fr; i <= to; i++)
            {
                a.Add(i);
            }
            return a;
        }
        #endregion

        #region -- Quarters --
        /// <summary>
        /// Return a start of quarter of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="q">Quarter</param>
        /// <returns>Return a start of quarter</returns>
        public static DateTime ToStartOfQuarter(this int y, int q)
        {
            switch (q)
            {
                case 1: // 1st Quarter = January 1 to March 31
                    return new DateTime(y, 1, 1).Date;

                case 2: // 2nd Quarter = April 1 to June 30
                    return new DateTime(y, 4, 1).Date;

                case 3: // 3rd Quarter = July 1 to September 30
                    return new DateTime(y, 7, 1).Date;

                default: // 4th Quarter = October 1 to December 31
                    return new DateTime(y, 10, 1).Date;
            }
        }

        /// <summary>
        /// Return a end of quarter of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="q">Quarter</param>
        /// <returns>Return a end of quarter</returns>
        public static DateTime ToEndOfQuarter(this int y, int q)
        {
            switch (q)
            {
                case 1: // 1st Quarter = January 1 to March 31
                    return new DateTime(y, 3, 31).ToEndOfDay();

                case 2: // 2nd Quarter = April 1 to June 30
                    return new DateTime(y, 6, 30).ToEndOfDay();

                case 3: // 3rd Quarter = July 1 to September 30
                    return new DateTime(y, 9, 30).ToEndOfDay();

                default: // 4th Quarter = October 1 to December 31
                    return new DateTime(y, 12, 31).ToEndOfDay();
            }
        }

        /// <summary>
        /// Return a quarter of this month
        /// </summary>
        /// <param name="m">Month</param>
        /// <returns>Return a quarter</returns>
        public static int ToQuarter(this int m)
        {
            if (m <= 3) return 1; // 1st Quarter = January 1 to March 31
            else if ((m >= 4) && (m <= 6)) return 2; // 2nd Quarter = April 1 to June 30
            else if ((m >= 7) && (m <= 9)) return 3; // 3rd Quarter = July 1 to September 30
            else return 4; // 4th Quarter = October 1 to December 31
        }

        /// <summary>
        /// Return a copy of this DateTime to start of quarter
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns>Return a start of quarter</returns>
        public static DateTime ToStartOfQuarter(this DateTime d)
        {
            var q = d.Month.ToQuarter();
            return d.Year.ToStartOfQuarter(q);
        }

        /// <summary>
        /// Return a copy of this DateTime to end of quarter
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns>Return a end of quarter</returns>
        public static DateTime ToEndOfQuarter(this DateTime d)
        {
            var q = d.Month.ToQuarter();
            return d.Year.ToEndOfQuarter(q);
        }

        /// <summary>
        /// Return a quarter of this DateTime
        /// </summary>
        /// <param name="m">Month</param>
        /// <returns>Return a quarter</returns>
        public static Quarter ToQuarter(this DateTime d)
        {
            return (Quarter)d.Month.ToQuarter();
        }
        #endregion

        #region -- Months --
        /// <summary>
        /// Return a start of month of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="m">Month</param>
        /// <returns>Return a start of month</returns>
        public static DateTime ToStartOfMonth(this int y, int m)
        {
            return new DateTime(y, m, 1).Date;
        }

        /// <summary>
        /// Return a end of month of this integer
        /// </summary>
        /// <param name="y">Year</param>
        /// <param name="m">Month</param>
        /// <returns>Return a end of month</returns>
        public static DateTime ToEndOfMonth(this int y, int m)
        {
            var a = DateTime.DaysInMonth(y, m);
            var b = new DateTime(y, m, a).ToEndOfDay();
            return b;
        }

        /// <summary>
        /// Return a copy of this DateTime to start of month
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns>Return a start of month</returns>
        public static DateTime ToStartOfMonth(this DateTime d)
        {
            return d.Year.ToStartOfMonth(d.Month);
        }

        /// <summary>
        /// Return a copy of this DateTime to end of month
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <returns>Return a end of month</returns>
        public static DateTime ToEndOfMonth(this DateTime d)
        {
            return d.Year.ToEndOfMonth(d.Month);
        }

        /// <summary>
        /// Return a quarter of this DateTime
        /// </summary>
        /// <param name="m">Date and time</param>
        /// <returns>Return a quarter</returns>
        public static Month ToMonth(this DateTime d)
        {
            return (Month)d.Month;
        }
        #endregion

        #region -- Weeks --
        /// <summary>
        /// Return a copy of this DateTime to start of week
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <param name="startOfWeek">Day start of week</param>
        /// <returns>Return a start of week</returns>
        public static DateTime ToStartOfWeek(this DateTime d, DayOfWeek startOfWeek)
        {
            int diff = d.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }
            return d.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Return a copy of this DateTime to end of week
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <param name="startOfWeek">Day start of week</param>
        /// <returns>Return a end of week</returns>
        public static DateTime ToEndOfWeek(this DateTime d, DayOfWeek startOfWeek)
        {
            var a = d.ToStartOfWeek(startOfWeek);
            var b = a.AddDays(6);
            return b.ToEndOfDay();
        }

        /// <summary>
        /// Return a copy of this DateTime to start of week
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <param name="week">Number of week</param>
        /// <param name="startOfWeek">Day start of week</param>
        /// <returns>Return a start of week</returns>
        public static DateTime ToStartOfWeek(this DateTime d, int week, DayOfWeek startOfWeek)
        {
            var a = d.ToStartOfWeek(startOfWeek).AddDays(7 * week);
            return a.Date;
        }

        /// <summary>
        /// Return a copy of this DateTime to end of week
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <param name="week">Number of week</param>
        /// <param name="startOfWeek">Day start of week</param>
        /// <returns>Return a end of week</returns>
        public static DateTime ToEndOfWeek(this DateTime d, int week, DayOfWeek startOfWeek)
        {
            var a = d.ToStartOfWeek(week, startOfWeek);
            var b = a.AddDays(6);
            return b.ToEndOfDay();
        }

        /// <summary>
        /// Return week of year
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <param name="startOfWeek">Day start of week</param>
        /// <returns>Return number week of year</returns>
        public static int ToWeekOfYear(this DateTime d, DayOfWeek startOfWeek)
        {
            var a = DateTimeFormatInfo.CurrentInfo;
            var b = a.Calendar;
            var c = b.GetWeekOfYear(d, CalendarWeekRule.FirstFullWeek, startOfWeek);
            return c;
        }

        /// <summary>
        /// Return week of month
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <param name="startOfWeek">Day start of week</param>
        /// <returns>Return number week of month</returns>
        public static int ToWeekOfMonth(this DateTime d, DayOfWeek startOfWeek)
        {
            var a = d.ToStartOfMonth();
            var x = d.ToWeekOfYear(startOfWeek);
            var y = a.ToWeekOfYear(startOfWeek);
            var b = x - y + 1;
            return b;
        }
        #endregion

        #region -- Days --
        /// <summary>
        /// Return a copy of this DateTime to start of day
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <param name="isUTC">Will convert to UTC if true</param>
        /// <returns>Return a start of day</returns>
        public static DateTime ToStartOfDay(this DateTime d, bool isUTC = false)
        {
            var tmp = isUTC ? d.ToUniversalTime() : d;
            var res = tmp.Date;
            return res;
        }

        /// <summary>
        /// Return a copy of this DateTime to end of day
        /// </summary>
        /// <param name="d">Date and time</param>
        /// <param name="isUTC">Will convert to UTC if true</param>
        /// <returns>Return a end of day</returns>
        public static DateTime ToEndOfDay(this DateTime d, bool isUTC = false)
        {
            var tmp = isUTC ? d.ToUniversalTime() : d;
            var res = tmp.Date.AddDays(1).AddTicks(-1);
            return res;
        }
        #endregion

        #region -- Ages --
        /// <summary>
        /// Calculate age
        /// </summary>
        /// <param name="d">Birthday</param>
        /// <param name="now">Current year</param>
        /// <returns>Return the age</returns>
        public static int ToAge(this DateTime d, DateTime now)
        {
            if (d < now)
            {
                return 0;
            }
            int years = now.Year - d.Year;
            if (now.Month < d.Month || (now.Month == d.Month && now.Day < d.Day)) years--;
            return years;
        }

        /// <summary>
        /// Return a copy of this DateTime to enough age
        /// </summary>
        /// <param name="d">Birthday</param>
        /// <param name="age">Age</param>
        /// <returns>Return the birthday</returns>
        public static DateTime ToBirth(this DateTime d, int age)
        {
            if (age < 0 || age > 9999)
            {
                return Now;
            }
            if (d.Year - age < 1)
            {
                return Now;
            }
            var a = new DateTime(d.Year - age, d.Month, d.Day,
                d.Hour, d.Minute, d.Second, d.Millisecond);
            return a;
        }
        #endregion

        /// <summary>
        /// Convert input DateTime to TotalMilliseconds
        /// </summary>
        /// <param name="d">DateTime</param>
        /// <returns>Return TotalMilliseconds</returns>
        public static double ToTime(this DateTime? d)
        {
            var st = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            if (d == null)
            {
                d = DateTime.Now;
            }
            var t = d.Value.ToUniversalTime() - st;
            return t.TotalMilliseconds;
        }

        /// <summary>
        /// Add time to input DateTime
        /// </summary>
        /// <param name="d">DateTime</param>
        /// <param name="now">Now</param>
        /// <returns>Return the result</returns>
        public static DateTime AddTime(this DateTime d, DateTime now)
        {
            var res = new DateTime(d.Year, d.Month, d.Day,
                now.Hour, now.Minute, now.Second, now.Millisecond);
            return res;
        }

        #endregion

        #region -- Properties --

        /// <summary>
        /// Get month list
        /// </summary>
        public static List<int> MonthList
        {
            get
            {
                var a = new List<int>();
                for (int i = 1; i <= 12; i++)
                {
                    a.Add(i);
                }
                return a;
            }
        }

        /// <summary>
        /// Get current time
        /// </summary>
        public static DateTime Now
        {
            get
            {
                if (_now == new DateTime())
                {
                    _now = DateTime.Now;
                }
                return _now;
            }
            set { _now = value; }
        }

        /// <summary>
        /// First day of week
        /// </summary>
        public static DayOfWeek FirstDayOfWeek
        {
            get
            {
                var a = DateTimeFormatInfo.CurrentInfo;
                return a.FirstDayOfWeek;
            }
        }

        /// <summary>
        /// Calendar week rule
        /// </summary>
        public static CalendarWeekRule CalendarWeekRule
        {
            get
            {
                var a = DateTimeFormatInfo.CurrentInfo;
                return a.CalendarWeekRule;
            }
        }

        #endregion

        #region -- Fields --

        /// <summary>
        /// Stop timer
        /// </summary>
        private static bool _stop = false;

        /// <summary>
        /// Now
        /// </summary>
        private static DateTime _now;

        #endregion
    }
}
#region Information
/*
 * Author       : Zng Tfy
 * Email        : nvt87x@gmail.com
 * Phone        : +84 1645 515 010
 * ------------------------------- *
 * Create       : 29/03/2017 07:02
 * Update       : 29/03/2017 07:02
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
 * All enums
 **************************************************************************************************************/
#endregion
#endregion

namespace Inno.Utility
{
    /// <summary>
    /// Text format
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// Sentence case
        /// </summary>
        Sentence,

        /// <summary>
        /// lower case
        /// </summary>
        Lower,

        /// <summary>
        /// UPPER CASE
        /// </summary>
        Upper,

        /// <summary>
        /// Capitalized Case
        /// </summary>
        Capitalized,

        /// <summary>
        /// Orginal string
        /// </summary>
        Orginal
    }

    #region -- Date --

    /// <summary>
    /// Enums of quarter
    /// </summary>
    public enum Quarter
    {
        /// <summary>
        /// First
        /// </summary>
        First = 1,

        /// <summary>
        /// Second
        /// </summary>
        Second = 2,

        /// <summary>
        /// Third
        /// </summary>
        Third = 3,

        /// <summary>
        /// Fourth
        /// </summary>
        Fourth = 4
    }

    /// <summary>
    /// Enums of month
    /// </summary>
    public enum Month
    {
        /// <summary>
        /// January
        /// </summary>
        January = 1,

        /// <summary>
        /// February
        /// </summary>
        February = 2,

        /// <summary>
        /// March
        /// </summary>
        March = 3,

        /// <summary>
        /// April
        /// </summary>
        April = 4,

        /// <summary>
        /// May
        /// </summary>
        May = 5,

        /// <summary>
        /// June
        /// </summary>
        June = 6,

        /// <summary>
        /// July
        /// </summary>
        July = 7,

        /// <summary>
        /// August
        /// </summary>
        August = 8,

        /// <summary>
        /// September
        /// </summary>
        September = 9,

        /// <summary>
        /// October
        /// </summary>
        October = 10,

        /// <summary>
        /// November
        /// </summary>
        November = 11,

        /// <summary>
        /// December
        /// </summary>
        December = 12
    }

    #endregion

    /// <summary>
    /// Priority
    /// </summary>
    public enum Priority
    {
        /// <summary>
        /// Normal
        /// </summary>
        NOR,

        /// <summary>
        /// Urgent
        /// </summary>
        URG
    }
}
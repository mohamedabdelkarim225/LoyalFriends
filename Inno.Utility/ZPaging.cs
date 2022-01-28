#region Information
/*
 * Author       : Zng Tfy
 * Email        : nvt87x@gmail.com
 * Phone        : +84 1645 515 010
 * ------------------------------- *
 * Create       : 25/03/2016 22:08
 * Update       : 25/03/2016 22:08
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
 * Support paging on server
 **************************************************************************************************************/
#endregion
#endregion

using System.Collections.Generic;

namespace Inno.Utility
{
    /// <summary>
    /// Support paging on server
    /// </summary>
    public class ZPaging
    {
        /// <summary>
        /// Current page
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total records first paging
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// List sorts information
        /// </summary>
        public List<Sort> Sorts { get; set; }

        /// <summary>
        /// Sort information
        /// </summary>
        public class Sort
        {
            #region -- Properties --

            /// <summary>
            /// Sort direction
            /// </summary>
            public string Field { get; set; }

            /// <summary>
            /// Sort direction
            /// </summary>
            public string Direction { get; set; }

            #endregion
        }
    }
}
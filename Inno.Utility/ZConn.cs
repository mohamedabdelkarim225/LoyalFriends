#region Information
/*
 * Author       : Zng Tfy
 * Email        : nvt87x@gmail.com
 * Phone        : +84 1645 515 010
 * ------------------------------- *
 * Create       : 14/03/2017 22:36
 * Update       : 14/03/2017 22:36
 * Checklist    : 1.0
 * Status       : NO
 */
#region License
/**************************************************************************************************************
 * Copyright © 2012-2017 SKG™ all rights reserved
 **************************************************************************************************************/
#endregion
#region Description
/**************************************************************************************************************
 * Connection
 **************************************************************************************************************/
#endregion
#endregion

using System.Data;
using System.Data.SqlClient;

namespace Inno.Utility
{
    /// <summary>
    /// Connection
    /// </summary>
    public class ZConn
    {
        #region -- Methods --

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="s">String connection</param>
        public ZConn(string s)
        {
            _cnn = new SqlConnection(s);
        }

        /// <summary>
        /// Open connection
        /// </summary>
        /// <returns>Return status</returns>
        public bool Open()
        {
            try
            {
                if (_cnn.State == ConnectionState.Closed)
                    _cnn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Close connection
        /// </summary>
        /// <returns>Return status</returns>
        public bool Close()
        {
            try
            {
                if (_cnn.State != ConnectionState.Closed)
                    _cnn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Execute with query
        /// </summary>
        /// <param name="query">String command</param>
        /// <param name="name">Table name</param>
        /// <returns>Return the data</returns>
        public DataTable ExecuteQuery(string query, string name = SpecialString.Blank)
        {
            var tb = new DataTable(name);
            try
            {
                Open();

                var cmd = _cnn.CreateCommand();
                cmd.CommandText = query;
                tb.Load(cmd.ExecuteReader());
            }
            catch { }
            finally { Close(); }

            return tb;
        }

        #endregion

        #region -- Fields --

        /// <summary>
        /// Access the database
        /// </summary>
        private SqlConnection _cnn;

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SoliteraxLibrary.SQLSystem
{
    public class ManageSQL
    {
        ConnectSQL connection;
        public ManageSQL(ConnectSQL sql)
        {
            connection = sql;
        }
        #region SendData
        
        /// <summary>
        /// Send sql command and change sql server databases
        /// </summary>
        /// <param name="data">Sql Command writable area</param>
        public void SendData(string data)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = data;
            command.Connection = connection.GetConnection();

            command.ExecuteNonQuery();
            command.Dispose();
            
        }
        #endregion

        #region UpdateData
        /// <summary>
        /// Database data update command using SQLConnection
        /// </summary>
        /// <param name="table">table name</param>
        /// <param name="columnValue">changes will be posted here</param>
        /// <param name="condition">Where to change condition</param>
        /// <returns></returns>
        public bool UpdateData(string table, SQLCondition[] columnValue, SQLCondition condition)
        {
            try
            {
                string command = $"update {table} set";

                foreach (SQLCondition value in columnValue)
                {
                    command += $" {value.title} = '{value.value}',";
                }

                command = command.Substring(0, command.Length - 1);

                command += " where " + condition.title + "=" + condition.value;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = command;
                cmd.Connection = connection.GetConnection();

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region RemoveData
        /// <summary>
        /// Remove data Command 
        /// Maintenance!
        /// </summary>
        /// <returns></returns>
        public bool RemoveData()
        {
            return false;
        }
        #endregion

        #region GetData
        /// <summary>
        /// Get wished data from sql server
        /// </summary>
        /// <param name="command">Sql Command writable area</param>
        /// <returns></returns>
        public DataTable GetData(string command)
        {
            SqlCommand cCommand = new SqlCommand();
            cCommand.CommandText = command;
            cCommand.Connection = connection.GetConnection();

            SqlDataAdapter adapter = new SqlDataAdapter(cCommand);
            DataTable table = new DataTable();

            adapter.Fill(table);
            cCommand.Dispose();
            adapter.Dispose();

            return table;
        }
        #endregion

        #region GetSingleData
        /// <summary>
        /// if condition met first row return
        /// </summary>
        /// <param name="command">Sql Command writable area</param>
        /// <returns></returns>
        public object GetSingleData(string command)
        {
            SqlCommand cCommand = new SqlCommand();
            cCommand.CommandText = command;
            cCommand.Connection = connection.GetConnection();
            object returnValue = cCommand.ExecuteScalar();
            cCommand.Dispose();

            return returnValue;
        } 
        #endregion

        public class SQLCondition
        {
            public string title;
            public object value;
        }
    }
}

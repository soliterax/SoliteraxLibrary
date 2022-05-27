using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using static SoliteraxLibrary.SoliteraxConnection;

namespace SoliteraxLibrary.SQLSystem
{
    public class DatabaseManager
    {
        ConnectDatabase connection;
        ConnectionType type;
        public DatabaseManager(ConnectDatabase sql, ConnectionType type)
        {
            connection = sql;
            this.type = type;
        }
        #region SendData

        /// <summary>
        /// Send sql command and change sql server databases
        /// </summary>
        /// <param name="data">Sql Command writable area</param>
        public void SendData(string data)
        {
            if (type == ConnectionType.SQL)
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = data;
                command.Connection = (SqlConnection)connection.GetConnection();

                command.ExecuteNonQuery();
                command.Dispose();
            } else
            {
                OleDbCommand command = new OleDbCommand();
                command.CommandText = data;
                command.Connection = (OleDbConnection)connection.GetConnection();

                command.ExecuteNonQuery();
                command.Dispose();
            }

        }

        public void SendData(SqlCommand data)
        {

            data.Connection = (SqlConnection)connection.GetConnection();
            data.ExecuteNonQuery();
            data.Dispose();
        }

        public void SendData(OleDbCommand data)
        {
            data.Connection = (OleDbConnection)connection.GetConnection();
            data.ExecuteNonQuery();
            data.Dispose();
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
        public bool UpdateData(string table, DataCondition[] columnValue, DataCondition condition)
        {
            try
            {
                string command = $"update {table} set";

                foreach (DataCondition value in columnValue)
                {
                    command += $" {value.title} = '{value.value}',";
                }

                command = command.Substring(0, command.Length - 1);

                command += " where " + condition.title + "=" + condition.value;
                if (type == ConnectionType.SQL)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = command;
                    cmd.Connection = (SqlConnection)connection.GetConnection();

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                else
                {
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.CommandText = command;
                    cmd.Connection = (OleDbConnection)connection.GetConnection();
                }
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
            DataTable table = new DataTable();
            if (type == ConnectionType.SQL)
            {
                SqlCommand cCommand = new SqlCommand();
                cCommand.CommandText = command;
                cCommand.Connection = (SqlConnection)connection.GetConnection();

                SqlDataAdapter adapter = new SqlDataAdapter(cCommand);
                

                adapter.Fill(table);
                cCommand.Dispose();
                adapter.Dispose();
            }
            else
            {
                OleDbCommand cCommand = new OleDbCommand();
                cCommand.CommandText = command;
                cCommand.Connection = (OleDbConnection)connection.GetConnection();

                OleDbDataAdapter adapter = new OleDbDataAdapter(cCommand);

                adapter.Fill(table);
                cCommand.Dispose();
                adapter.Dispose();
            }


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
            object returnValue;
            if (type == ConnectionType.SQL)
            {
                SqlCommand cCommand = new SqlCommand();
                cCommand.CommandText = command;
                cCommand.Connection = (SqlConnection)connection.GetConnection();
                returnValue = cCommand.ExecuteScalar();
                cCommand.Dispose();
            }
            else
            {
                OleDbCommand cCommand = new OleDbCommand();
                cCommand.CommandText = command;
                cCommand.Connection = (OleDbConnection)connection.GetConnection();
                returnValue = cCommand.ExecuteScalar();
                cCommand.Dispose();
            }

            return returnValue;
        }
        #endregion

        public class DataCondition
        {
            public string title;
            public object value;
        }
    }
}

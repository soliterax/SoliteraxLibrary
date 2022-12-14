using System;
using System.Data.SqlClient;
using System.Data.OleDb;
using static SoliteraxLibrary.SoliteraxConnection;

namespace SoliteraxLibrary.SQLSystem
{
    public class ConnectDatabase
    {

        string ConnectionKey;

        //Access Database Fields
        OleDbConnection accessConnection;

        //SQL Database Fields
        SqlConnection sqlConnection;
        DatabaseManager databaseManager;
        DatabaseStorage databaseStorage;

        ConnectionType type;
        public ConnectDatabase(string ConnectionKey, ConnectionType type)
        {
            this.ConnectionKey = ConnectionKey;
            this.type = type;
        }

        public ConnectDatabase(string IPAdress, string dbname, string charset, string username, string password, ConnectionType type)
        {
            throw new System.Exception();
            this.type = type;
            if (this.type == ConnectionType.SQL)
                this.ConnectionKey = "";
        }

        public static string CreateConnectionString(string IpAdress, string databaseName, string charset, string username, string password, ConnectionType type)
        {
            if (type == ConnectionType.SQL)
                return $"Data Source = {IpAdress}; Initial Catalog = {databaseName}; User ID = {username}; Password = {password}; charset={charset}";
            else
                throw new NotImplementedException();
        }


        public ConnectDatabase Connect()
        {
            if(type == ConnectionType.SQL)
            {
                sqlConnection = new SqlConnection(ConnectionKey);
                sqlConnection.Open();
                databaseManager = new DatabaseManager(this, type);
                databaseStorage = new DatabaseStorage();
            }else
            {
                accessConnection = new OleDbConnection(ConnectionKey);
                accessConnection.Open();
                databaseManager = new DatabaseManager(this, type);
                databaseStorage = new DatabaseStorage();
            }
            return this;
        }

        

        public void DisConnect()
        {
            if (type == ConnectionType.SQL)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            else
            {
                accessConnection.Close();
                accessConnection.Dispose();
            }
        }

        public DatabaseManager GetManager()
        {
            return databaseManager;
        }

        public DatabaseStorage GetStorage()
        {
            return databaseStorage;
        }

        public object GetConnection()
        {
            if (type == ConnectionType.SQL)
                return sqlConnection;
            else
                return accessConnection;
        }

    }
}

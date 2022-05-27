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


        public void Connect()
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

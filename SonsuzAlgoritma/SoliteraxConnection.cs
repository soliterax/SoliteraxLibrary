using SoliteraxLibrary.Soliterax_Hub;
using SoliteraxLibrary.SQLSystem;
using System;

namespace SoliteraxLibrary
{
    public class SoliteraxConnection
    {

        ConnectDatabase database;
        Server server;
        Client client;
        ConnectionType type;

        public SoliteraxConnection(ConnectionType type)
        {
            this.type = type;
        }
        #region Connect
        public void Connect(string connectionString)
        {
            switch (type)
            {
                case ConnectionType.SQL:
                    database = new ConnectDatabase(connectionString, type);
                    database.Connect();
                    break;
                case ConnectionType.Server:
                    break;
                case ConnectionType.Client:
                    break;
                case ConnectionType.Access:
                    database = new ConnectDatabase(connectionString, type);
                    database.Connect();
                    break;
                default:
                    return;
            }
        }
        #endregion

        #region Get Connection
        public Object GetConnection()
        {
            switch (type)
            {
                case ConnectionType.SQL:
                    return database;
                case ConnectionType.Server:
                    return server;
                case ConnectionType.Client:
                    return client;
                case ConnectionType.Access:
                    return database;
                default:
                    return null;
            }
        }
        #endregion

        #region Set Connection
        public void SetConnection(ConnectionType type, object obj)
        {
            switch (type)
            {
                case ConnectionType.SQL:
                    database = (ConnectDatabase)obj;
                    break;
                case ConnectionType.Server:
                    server = (Server)obj;
                    break;
                case ConnectionType.Client:
                    client = (Client)obj;
                    break;
                case ConnectionType.Access:
                    database = (ConnectDatabase)obj;
                    break;
                default:
                    return;
            }
        }
        #endregion

        public enum ConnectionType
        {
            SQL, Server, Client, Access
        }
    }
}

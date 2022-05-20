using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoliteraxLibrary.SQLSystem;
using SoliteraxLibrary.Soliterax_Hub;

namespace SoliteraxLibrary
{
    public class SoliteraxConnection
    {

        ConnectSQL sql;
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
            switch(type)
            {
                case ConnectionType.SQL:
                    sql = new ConnectSQL(connectionString);
                    sql.Connect();
                    break;
                case ConnectionType.Server:
                    break;
                case ConnectionType.Client:
                    break;
                default:
                    return;
            }
        }
        #endregion

        #region Get Connection
        public Object GetConnection()
        {
            switch(type)
            {
                case ConnectionType.SQL:
                    return sql;
                case ConnectionType.Server:
                    return server;
                case ConnectionType.Client:
                    return client;
                default:
                    return null;
            }
        }
        #endregion

        #region Set Connection
        public void SetConnection(ConnectionType type, object obj)
        {
            switch(type)
            {
                case ConnectionType.SQL:
                    sql = (ConnectSQL)obj;
                    break;
                case ConnectionType.Server:
                    server = (Server)obj;
                    break;
                case ConnectionType.Client:
                    client = (Client)obj;
                    break;
                default:
                    return;
            }
        }
        #endregion

        public enum ConnectionType
        {
            SQL, Server, Client
        }
    }
}

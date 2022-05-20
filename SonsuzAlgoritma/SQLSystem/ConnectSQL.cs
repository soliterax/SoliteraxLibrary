using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SoliteraxLibrary.SQLSystem
{
    public class ConnectSQL
    {

        string ConnectionKey;
        
        SqlConnection connection;
        ManageSQL manage;
        StorageSQL storage;
        public ConnectSQL(string ConnectionKey)
        {
            this.ConnectionKey = ConnectionKey;
        }


        public void Connect()
        {
            connection = new SqlConnection(ConnectionKey);
            connection.Open();
            manage = new ManageSQL(this);
            storage = new StorageSQL();
        }

        public void DisConnect()
        {
            connection.Close();
            connection.Dispose();
        }

        public ManageSQL GetManager()
        {
            return manage;
        }

        public StorageSQL GetStorage()
        {
            return storage;
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }

    }
}

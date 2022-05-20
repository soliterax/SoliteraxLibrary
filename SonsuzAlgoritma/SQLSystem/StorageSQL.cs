using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoliteraxLibrary.SQLSystem
{
    public class StorageSQL
    {

        List<Storage> tables = new List<Storage>();

        public void addTable(DataTable table)
        {
            Storage st1 = new Storage();
            st1.dataTable = table;
            foreach (Storage st in tables)
            {
                if(st.dataTable == table)
                {
                    
                    st1.id = st.id;
                    
                    tables.Remove(st);
                    tables.Add(st1);

                    return;
                }
            }

            st1.id = tables[tables.Count - 1].id + 1;
            tables.Add(st1);
            return;
        }

        public void RemoveTable(int id)
        {
            foreach(Storage st in tables)
            {
                if(st.id == id)
                {
                    tables.Remove(st);
                    break;
                }
            }
            return;
        }

        public void RemoveTable(DataTable table)
        {
            foreach(Storage st in tables)
            {
                if(st.dataTable == table)
                {
                    tables.Remove(st);
                    break; ;
                }
            }
            return;
        }

        public class Storage
        {
            public int id { get; set; }
            public DataTable dataTable { get; set; }
        }

    }
}

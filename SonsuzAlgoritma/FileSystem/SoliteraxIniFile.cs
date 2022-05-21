using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SoliteraxLibrary.FileSystem
{
    public class SoliteraxIniFile
    {
        string path;
        LinkedList<string> data = new LinkedList<string>();
        LinkedList<object> value = new LinkedList<object>();

        public SoliteraxIniFile(string path)
        {
            try
            {
                if(!File.Exists(path))
                    File.Create(path);
            } catch(DirectoryNotFoundException)
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.Delete();
                File.Create(path);
            } catch(UnauthorizedAccessException)
            {

            }
            this.path = path;
        }

        public bool ReadBoolean(string data)
        {
            for(int i = 0; i < this.data.ToArray().Length; i++)
            {
                if (this.data.ToArray()[i].Equals(data)) return (bool)value.ToArray()[i];
            }
            throw new Exception();
        }

        public string ReadText(string data)
        {
            for (int i = 0; i < this.data.ToArray().Length; i++)
            {
                if (this.data.ToArray()[i].Equals(data)) return (string)value.ToArray()[i];
            }
            throw new Exception();
        }

        public short ReadShort(string data)
        {
            for (int i = 0; i < this.data.ToArray().Length; i++)
            {
                if (this.data.ToArray()[i].Equals(data)) return (short)value.ToArray()[i];
            }
            throw new Exception();
        }

        public long ReadLong(string data)
        {
            for (int i = 0; i < this.data.ToArray().Length; i++)
            {
                if (this.data.ToArray()[i].Equals(data)) return (long)value.ToArray()[i];
            }
            throw new Exception();
        }

        public char ReadChar(string data)
        {
            for (int i = 0; i < this.data.ToArray().Length; i++)
            {
                if (this.data.ToArray()[i].Equals(data)) return (char)value.ToArray()[i];
            }
            throw new Exception();
        }

        public int ReadInt(string data)
        {
            for (int i = 0; i < this.data.ToArray().Length; i++)
            {
                if (this.data.ToArray()[i].Equals(data)) return (int)value.ToArray()[i];
            }
            throw new Exception();
        }

        public List<object> ReadList(string data)
        {
            for (int i = 0; i < this.data.ToArray().Length; i++)
            {
                if (this.data.ToArray()[i].Equals(data)) return (List<object>)value.ToArray()[i];
            }
            throw new Exception();
        }


        public void Write(string data, object value)
        {
            if (!this.data.Contains(data))
                AddList(data, value);
            else
            {
                ChangeList(data, value);
            }
                
        }

        public void WriteList(string data, object value)
        {
            string alltext = "";
            foreach(object s in ((List<object>)value))
            {
                
            }
        }

        public void OverWriteList(string data, object value)
        {

        }

        void AddList(string data, object value)
        {
            this.data.AddLast(data);
            this.value.AddLast(value);
        }

        void ChangeList(string data, object value)
        {
            for (int i = 0; i < this.data.ToArray().Length; i++)
            {
                if (this.data.ToArray()[i].Equals(data))
                {
                    this.value.ToArray()[i] = value;
                    return;
                }
            }
        }

        public void SaveFile()
        {
            string allText = "";
            for(int i = 0; i < this.data.Count; i++)
            {
                allText += this.data.ToArray()[i].ToString() + "=" + this.value.ToArray()[i].ToString() + Environment.NewLine;
            }
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(allText);
                sw.Flush();
                sw.Close();
            }
        }

        public void ClearFile()
        {
            using(StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("");
                sw.Flush();
                sw.Close();
            }
        }


    }
}

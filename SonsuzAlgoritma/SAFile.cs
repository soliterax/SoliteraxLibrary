using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SoliteraxLibrary
{
    public class SAFile
    {

        string path;

        public SAFile(string path)
        {
            try
            {
                if (!File.Exists(path))
                    File.Create(path).Close();
            }
            catch (DirectoryNotFoundException)
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
                di.Delete();
                File.Create(path).Close();
            }
            catch (UnauthorizedAccessException)
            {

            }
            this.path = path;

        }

        public void Write(string text)
        {

            StreamWriter sr = new StreamWriter(path);

            sr.WriteLine(text);
            sr.Flush();
            sr.Close();
        }

        public void OverWrite(string text)
        {
            StreamReader sr = new StreamReader(path);
            string allText = sr.ReadToEnd();
            sr.Close();
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine(allText + text);
            sw.Flush();
            sw.Close();
        }

        public void ClearFile()
        {
            StreamWriter sw = new StreamWriter(path);

            sw.Write("");
            sw.Flush();
            sw.Close();
        }

        public string Read()
        {

            StreamReader sr = new StreamReader(path);

            string all = sr.ReadToEnd();
            sr.Close();

            return all;

        }

        public string Read(int satir)
        {
            StreamReader reader = new StreamReader(path);
            List<string> all = new List<string>();
            string allraw = reader.ReadToEnd();
            allraw = allraw.Replace(Environment.NewLine, "$");

            string test = "";
            for (int i = 0; i < allraw.ToCharArray().Length; i++)
            {
                if (allraw.ToCharArray()[i].Equals('$'))
                {
                    all.Add(test);
                    test = "";
                }
                else
                {
                    test += allraw.ToCharArray()[i];
                }
            }

            return all[satir - 1];

        }

    }
}

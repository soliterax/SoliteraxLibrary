using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SoliteraxLibrary.FileSystem
{
    public class SoliteraxFile
    {

        string path;

        public SoliteraxFile(string path)
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
                Console.WriteLine("Unauthorized Access Detected!");
            }
            this.path = path;

        }

        public void Write(string text)
        {
            using (StreamWriter sr = new StreamWriter(path))
            {
                sr.WriteLine(text);
                sr.Flush();
                sr.Close();
            }
        }

        public void OverWrite(string text)
        {
            string allText;
            using (StreamReader sr = new StreamReader(path))
            {
                allText = sr.ReadToEnd();
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(allText + text);
                sw.Flush();
                sw.Close();
            }
        }

        public void WriteLast(string text)
        {
            string allText;
            using (StreamReader sr = new StreamReader(path))
            {
                allText = sr.ReadToEnd();
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(allText + text);
                sw.Flush();
                sw.Close();
            }
        }

        public void WriteFirst(string text)
        {
            string allText;
            using (StreamReader sr = new StreamReader(path))
            {
                allText = sr.ReadToEnd();
                sr.Close();
            }
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(text + allText);
                sw.Flush();
                sw.Close();
            }
        }

        public void ClearFile()
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write("");
                sw.Flush();
                sw.Close();
            }
        }

        public string Read()
        {

            using (StreamReader sr = new StreamReader(path))
            {

                string all = sr.ReadToEnd();
                sr.Close();

                return all;
            }

        }

        public string Read(int satir)
        {
            using (StreamReader reader = new StreamReader(path))
            {
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
}

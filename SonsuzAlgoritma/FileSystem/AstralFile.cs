using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace SoliteraxLibrary.FileSystem
{
    public class AstralFile
    {

        //Kalıcı olması gereken değişkenleri tanıtma yeri
        public static FileStream dosyayol;

        private static LinkedList<String> dataName = new LinkedList<String>();
        private static LinkedList<String> dataValue = new LinkedList<String>();
        private static LinkedList<String> lines = new LinkedList<String>();
        public static void Write(string metin)
        {

            //Dosyaya yazmak için kullanacağımız sınıfı dahil ettik
            using (StreamWriter sw = new StreamWriter(dosyayol))
            {
                //enter yapılan yerleri '$' ile değiştirme
                metin = metin.Replace(System.Environment.NewLine, "$");
                //Değiştirilen metni dosyaya yazma
                sw.Write(metin);
                //Writerı kapama ve aldıklarını serbest bırakma
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
        }

        public static void Write(string DataName, string DataValue)
        {

            //Dosyaya yazmak için kullanacağımız sınıfı dahil ettik
            using (StreamWriter sw = new StreamWriter(dosyayol))
            {

                string data = DataName + "=" + DataValue + "$";

                sw.Write(data);

                //Writerı kapama ve aldıklarını serbest bırakma
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
        }

        public  string Read(string data)
        {

            //Geçici listeye eklenecek değerin depolandığı yer
            string line = "";
            //Dosyadan Alma İşlemlerinin Yapıldığı yer
            using (StreamReader rd = new StreamReader(dosyayol))
            {
                //Dosyayı baştan sona okuma ve harf harf ayırma
                string metin = rd.ReadToEnd();

                char[] c = metin.ToCharArray();
                //döngülerle gerekli satırları Liste gönderme
                for (int i = 0; i < c.Length; i++)
                {
                    //Değerin null gönderip göndermemesini görme
                    if (c.GetValue(i) != null)
                    {
                        //Satır işareti konulmuşmu bakma
                        if (c.GetValue(i).Equals('$'))
                        {
                            dataValue.AddLast(line);
                            line = "";
                            continue;
                        }
                        //eşittir ifadesi varsa drek data name al
                        else if (c.GetValue(i).Equals('='))
                        {
                            dataName.AddLast(line);
                            line = "";
                            continue;
                        }
                        //değilse o harfi geçici belleğe ekleme
                        else
                        {
                            line += c.GetValue(i);
                        }
                    } //null gönderiyorsa döngüyü sonlandırma
                    else
                    {
                        break;
                    }

                }
            }

            if (dataName.Equals(data))
            {
                int istenen = 0;
                foreach (String dataValue in dataName)
                {
                    if (dataValue.Equals(data))
                    {
                        break;
                    }
                    else
                    {
                        istenen++;
                    }
                }
                int count = 0;
                foreach (String dataValue in dataValue)
                {
                    if (istenen == count)
                    {
                        return dataValue;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            return null;

        }

        public void Read()
        {

            //Geçici listeye eklenecek değerin depolandığı yer
            string line = "";
            //Dosyadan Alma İşlemlerinin Yapıldığı yer
            using (StreamReader rd = new StreamReader(dosyayol))
            {
                //Dosyayı baştan sona okuma ve harf harf ayırma
                string metin = rd.ReadToEnd();

                char[] c = metin.ToCharArray();
                //döngülerle gerekli satırları Liste gönderme
                for (int i = 0; i < c.Length; i++)
                {
                    //Değerin null gönderip göndermemesini görme
                    if (c.GetValue(i) != null)
                    {
                        //Satır işareti konulmuşmu bakma
                        if (c.GetValue(i).Equals('$'))
                        {
                            lines.AddLast(line);
                            line = "";
                            continue;
                        } //değilse o harfi geçici belleğe ekleme
                        else
                        {
                            line += c.GetValue(i);
                        }
                    } //null gönderiyorsa döngüyü sonlandırma
                    else
                    {
                        break;
                    }

                }
            }
        }

        public string Read(int count)
        {

            //Geçici listeye eklenecek değerin depolandığı yer
            string line = "";
            //Dosyadan Alma İşlemlerinin Yapıldığı yer
            using (StreamReader rd = new StreamReader(dosyayol))
            {
                //Dosyayı baştan sona okuma ve harf harf ayırma
                string metin = rd.ReadToEnd();

                char[] c = metin.ToCharArray();
                //döngülerle gerekli satırları Liste gönderme
                for (int i = 0; i < c.Length; i++)
                {
                    //Değerin null gönderip göndermemesini görme
                    if (c.GetValue(i) != null)
                    {
                        //Satır işareti konulmuşmu bakma
                        if (c.GetValue(i).Equals('$'))
                        {
                            lines.AddLast(line);
                            line = "";
                        } //değilse o harfi geçici belleğe ekleme
                        else
                        {
                            line += c.GetValue(i);
                        }
                    } //null gönderiyorsa döngüyü sonlandırma
                    else
                    {
                        break;
                    }

                }
            }
            //Alınan bilgilere göre kullanıcının istediği satırı gösterme
            int u = 0;
            foreach (String text in lines)
            {
                //sistemin izlediği değerle kullanıcın istediği derğer aynımı diye kontrol etme
                if (u == count)
                {
                    //doğruysa kullanıcıya değeri gönderme
                    return text;
                }
                else
                {
                    //değilse sistemin değerini 1 arttırma
                    u++;
                }


            }
            //eğer kullanıcın istediği satır yoksa null gönderme
            return null;

        }

        //fileStream Getter
        public FileStream getFileStream()
        {
            return dosyayol;
        }
        //File Stream Setter
        public void setFileStream(string fileLocation)
        {
            dosyayol = new FileStream(fileLocation, FileMode.Open, FileAccess.ReadWrite);
        }

        public void setFileStream(FileStream fileLocation)
        {
            dosyayol = fileLocation;
        }
        //Dosyadaki herşeyi döndürür
        public string getAllFileText()
        {
            Read();
            string ge = "";

            foreach (String m in lines)
            {
                ge += m;
            }
            return ge;
        }
        //Dosya oluşturma kodu
        public void createFile(FileStream fileLocationandName)
        {
            if (!File.Exists(fileLocationandName.ToString()))
            {
                File.Create(fileLocationandName.ToString());
            }
            else
            {
                return;
            }
        }

        public void createFile(string fileLocationandName)
        {
            if (!File.Exists(fileLocationandName))
            {
                File.Create(fileLocationandName);
            }
            else
            {
                return;
            }
        }
        //dosya silme kodu
        public void deleteFile(FileStream fileLocation)
        {
            if (File.Exists(fileLocation.ToString()))
                File.Delete(fileLocation.ToString());
        }

        public void deleteFile(string fileLocation)
        {
            if (File.Exists(fileLocation))
                File.Delete(fileLocation);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

        public void Yaz(string metin)
        {

            //Dosyaya yazmak için kullanacağımız sınıfı dahil ettik
            using (StreamWriter sw = new StreamWriter(dosyayol))
            {
                //enter yapılan yerleri '$' ile değiştirme
                metin = metin.Replace(System.Environment.NewLine, "$");
                //Değiştirilen metni dosyaya yazma
                sw.Write(metin);
                //Writerı kapama ve aldıklarını serbest bırakma
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
        }



        public void Oku()
        {

            //Geçici listeye eklenecek değerin depolandığı yer
            string line = "";
            //Dosyadan Alma İşlemlerinin Yapıldığı yer
            using (StreamReader rd = new StreamReader(dosyayol))
            {
                //Dosyayı baştan sona okuma ve harf harf ayırma
                string metin = rd.ReadToEnd();

                char[] c = metin.ToCharArray();
                //döngülerle gerekli satırları Liste gönderme
                for (int i = 0; i < c.Length; i++)
                {
                    //Değerin null gönderip göndermemesini görme
                    if (c.GetValue(i) != null)
                    {
                        //Satır işareti konulmuşmu bakma
                        if (c.GetValue(i).Equals('$'))
                        {
                            lines.AddLast(line);
                            line = "";
                            continue;
                        } //değilse o harfi geçici belleğe ekleme
                        else
                        {
                            line += c.GetValue(i);
                        }
                    } //null gönderiyorsa döngüyü sonlandırma
                    else
                    {
                        break;
                    }

                }
            }
        }

        public void Yaz(string DataName, string DataValue)
        {

            //Dosyaya yazmak için kullanacağımız sınıfı dahil ettik
            using (StreamWriter sw = new StreamWriter(dosyayol))
            {

                string data = DataName + "=" + DataValue + "$";

                sw.Write(data);

                //Writerı kapama ve aldıklarını serbest bırakma
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
        }

        public string Oku(string data)
        {

            //Geçici listeye eklenecek değerin depolandığı yer
            string line = "";
            //Dosyadan Alma İşlemlerinin Yapıldığı yer
            using (StreamReader rd = new StreamReader(dosyayol))
            {
                //Dosyayı baştan sona okuma ve harf harf ayırma
                string metin = rd.ReadToEnd();

                char[] c = metin.ToCharArray();
                //döngülerle gerekli satırları Liste gönderme
                for (int i = 0; i < c.Length; i++)
                {
                    //Değerin null gönderip göndermemesini görme
                    if (c.GetValue(i) != null)
                    {
                        //Satır işareti konulmuşmu bakma
                        if (c.GetValue(i).Equals('$'))
                        {
                            dataValue.AddLast(line);
                            line = "";
                            continue;
                        }
                        //eşittir ifadesi varsa drek data name al
                        else if (c.GetValue(i).Equals('='))
                        {
                            dataName.AddLast(line);
                            line = "";
                            continue;
                        }
                        //değilse o harfi geçici belleğe ekleme
                        else
                        {
                            line += c.GetValue(i);
                        }
                    } //null gönderiyorsa döngüyü sonlandırma
                    else
                    {
                        break;
                    }

                }
            }

            if (dataName.Equals(data))
            {
                int istenen = 0;
                foreach (String dataValue in dataName)
                {
                    if (dataValue.Equals(data))
                    {
                        break;
                    }
                    else
                    {
                        istenen++;
                    }
                }
                int count = 0;
                foreach (String dataValue in dataValue)
                {
                    if (istenen == count)
                    {
                        return dataValue;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            return null;

        }

        public string Oku(int count)
        {

            //Geçici listeye eklenecek değerin depolandığı yer
            string line = "";
            //Dosyadan Alma İşlemlerinin Yapıldığı yer
            using (StreamReader rd = new StreamReader(dosyayol))
            {
                //Dosyayı baştan sona okuma ve harf harf ayırma
                string metin = rd.ReadToEnd();

                char[] c = metin.ToCharArray();
                //döngülerle gerekli satırları Liste gönderme
                for (int i = 0; i < c.Length; i++)
                {
                    //Değerin null gönderip göndermemesini görme
                    if (c.GetValue(i) != null)
                    {
                        //Satır işareti konulmuşmu bakma
                        if (c.GetValue(i).Equals('$'))
                        {
                            lines.AddLast(line);
                            line = "";
                        } //değilse o harfi geçici belleğe ekleme
                        else
                        {
                            line += c.GetValue(i);
                        }
                    } //null gönderiyorsa döngüyü sonlandırma
                    else
                    {
                        break;
                    }

                }
            }
            //Alınan bilgilere göre kullanıcının istediği satırı gösterme
            int u = 0;
            foreach (String text in lines)
            {
                //sistemin izlediği değerle kullanıcın istediği derğer aynımı diye kontrol etme
                if (u == count)
                {
                    //doğruysa kullanıcıya değeri gönderme
                    return text;
                }
                else
                {
                    //değilse sistemin değerini 1 arttırma
                    u++;
                }


            }
            //eğer kullanıcın istediği satır yoksa null gönderme
            return null;

        }

        //fileStream Getter
        public FileStream Dosya_Adi_Al()
        {
            return dosyayol;
        }
        //File Stream Setter
        public void Dosya_Ayarla(string DosyaYolu)
        {
            dosyayol = new FileStream(DosyaYolu, FileMode.Open, FileAccess.ReadWrite);
        }

        public void Dosya_Ayarla(FileStream DosyaYol)
        {
            dosyayol = DosyaYol;
        }
        //Dosyadaki herşeyi döndürür
        public string Herseyi_Al()
        {
            Read();
            string ge = "";

            foreach (String m in lines)
            {
                ge += m + Environment.NewLine;

            }
            return ge;
        }
        //Dosya oluşturma kodu
        public void Dosya_Olustur(FileStream DosyaYol)
        {
            if (!File.Exists(DosyaYol.ToString()))
            {
                File.Create(DosyaYol.ToString());
            }
            else
            {
                return;
            }
        }

        public void Dosya_Olustur(string DosyaYol)
        {
            if (!File.Exists(DosyaYol))
            {
                File.Create(DosyaYol);
            }
            else
            {
                return;
            }
        }
        //dosya silme kodu
        public void Dosya_Sil(FileStream DosyaYol)
        {
            if (File.Exists(DosyaYol.ToString()))
                File.Delete(DosyaYol.ToString());
        }

        public void Dosya_Sil(string DosyaYol)
        {
            if (File.Exists(DosyaYol))
                File.Delete(DosyaYol);
        }

    }
}

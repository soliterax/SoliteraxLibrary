/*using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SoliteraxLibrary
{
    public class STranslate
    {
        private const string finalURL =
        "https://translate.yandex.net/api/v1.5/tr.json/translate?lang=COUNTRYKEY&key=" +
        "trnsl.1.1.20180403T234128Z.5790699ba62f5d0f.ba2a4bb3f66abe408a4b0d973f443a7a649054ff";
        public STranslate() { }

        public string cevir(string al,string girisdil,string verisdil)
        {


            return "";
        }
        private string doPost(string URL, string postData)
        {

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);

                request.Method = WebRequestMethods.Http.Post;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Referer = "https://soliterax.com/";
                request.UserAgent = "Mozilla/5.0";
                request.Proxy = null;

                var data = Encoding.UTF8.GetBytes(postData);

                using (Stream stream = request.GetRequestStream())
                {

                    stream.Write(data, 0, data.Length);
                    stream.Close();

                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    return "Hata Oluştu: #" + response.StatusCode.ToString();
                }

                Stream streamResponse = response.GetResponseStream();
                StreamReader streamRead = new StreamReader(streamResponse);

                Char[] readBuff = new Char[256];
                int count = streamRead.Read(readBuff, 0, 256);

                String responseStr = "";

                while (count > 0)
                {
                    String outputData = new String(readBuff, 0, count);
                    responseStr = responseStr + outputData;
                    count = streamRead.Read(readBuff, 0, 256);
                }

                streamResponse.Close();
                streamRead.Close();
                response.Close();
                request.Abort();

                responseStr = responseStr.ToString().Trim();

                if (responseStr.Replace(" ", "").Length < 1 || responseStr.ToLower().Contains("invalid") || responseStr.ToLower().Contains("error"))
                {
                    return "Bilinmeyen hata oluştu :/";
                }

                return responseStr;

            }
            catch (WebException we)
            {

                return "Hata oluştu: #" + ((HttpWebResponse)we.Response).StatusCode.ToString();

            }
            catch (Exception)
            {

                return "Bilinmeyen hata oluştu :/";

            }
        }

        private void cevirme()
        {

            String countryKey = "";

            String countryKey1 = "";
            String countryKey2 = "";

            countryKey = countryKey1 + "-" + countryKey2;

            if (runningTwo)
            {
                return;
            }

            if (textBox1.Text.Length < 1 || textBox1.Text.Equals("Çevirilecek metin..."))
            {
                MessageBox.Show("Lütfen çevirmek için bir metin girin!", "İşlem Başarısız", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            runningTwo = true;

            textBox2.Text = "Lütfen Bekleyin...";



            new Thread(() => {

                Thread.CurrentThread.IsBackground = true;

                this.Invoke(new MethodInvoker(() => textBox1.Text = FirstCharToUpper(textBox1.Text)));

                string resp = doPost(finalURL.Replace("COUNTRYKEY", countryKey + ""), "text=" + textBox1.Text);

                if (resp.ToString().ToLower().Contains("badrequest"))
                {

                    this.Invoke(new MethodInvoker(() => textBox2.Text = "Lütfen geçerli diller girin."));
                    runningTwo = false;
                    return;

                }

                if (resp.ToString().ToLower().Contains("hata"))
                {
                    this.Invoke(new MethodInvoker(() => textBox2.Text = resp));
                    runningTwo = false;
                    return;
                }

                var json = JsonConvert.DeserializeObject<dynamic>(resp.Replace("[", "").Replace("]", ""));
                string tr = json.text;

                tr = FirstCharToUpper(tr);

                this.Invoke(new MethodInvoker(() => textBox2.Text = tr));

                this.Invoke(new MethodInvoker(() => runningTwo = false));

            }).Start();

        }
    }
}
*/
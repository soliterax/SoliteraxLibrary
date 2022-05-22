using System;
using System.Security.Cryptography;
using System.Text;

namespace SoliteraxLibrary
{
    public class SonsuzLock
    {
        //Algorithm
        string hash;
        int tekrar;

        public void setHash(String hash)
        {
            this.hash = hash;
        }

        public void setTekrar(int tekrar)
        {
            this.tekrar = tekrar;
        }

        public SonsuzLock()
        {

        }

        public SonsuzLock(string hash)
        {

            this.hash = hash;

        }

        public SonsuzLock(string hash, int tekrar)
        {

            this.hash = hash;
            this.tekrar = tekrar;

        }
        //Encryption Point
        string encrypting(string metin)
        {

            byte[] data = UTF8Encoding.UTF8.GetBytes(metin);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {

                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {

                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);

                }

            }

        }
        //Decryption Point
        string decrypting(string metin)
        {

            byte[] data = Convert.FromBase64String(metin);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {

                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {

                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }

            }

        }
        //Encryption output Point
        public string sifrele(string metin)
        {
            tekrar++;
            string mo = metin;
            for (int i = 1; i < tekrar; i++)
            {

                mo = encrypting(mo);

            }
            return mo;

        }
        //Decryption output point
        public string sifrecoz(string metin)
        {

            tekrar++;
            string mo = metin;
            for (int i = 1; i < tekrar; i++)
            {

                mo = decrypting(mo);

            }
            return mo;

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.RiotDevPortal.FileManager
{
    public class Encryption
    {
        public static byte[] CreateVector()
        {
            using (Aes aes = Aes.Create())
            {
                var vector = aes.IV;

                if (File.Exists("vector"))
                {
                    return null;
                }

                try
                {
                    using (var fs = new FileStream("vector", FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(vector, 0, vector.Length);

                    }
                    return vector;
                }
                catch
                {

                    return null;
                }
            }
        }

        public static byte[] ReadVector()
        {
            try
            {
                var vector = File.ReadAllBytes("vector");

                return vector;

            }
            catch
            {
                return CreateVector();
            }
        }

        public static byte[] GetKey()
        {
            string key = null;
            foreach (NetworkInterface n in NetworkInterface.GetAllNetworkInterfaces())
            {

                if (n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    key = n.Id;
                    break;
                }

            }

            byte[] tempByteKey = Encoding.ASCII.GetBytes(key);

            byte[] byteKey;

            if (tempByteKey.Length > 32)
            {
                byteKey = new byte[32];
                for (int i = 0; i < 32; i++)
                {
                    byteKey[i] = tempByteKey[i];
                }
            }
            else if (tempByteKey.Length >= 24 && tempByteKey.Length < 32)
            {
                byteKey = new byte[24];

                for (int i = 0; i < 24; i++)
                {
                    byteKey[i] = tempByteKey[i];
                }
            }

            else
            {
                byteKey = new byte[16];

                for (int i = 0; i < 16; i++)
                {
                    byteKey[i] = tempByteKey[i];

                }
            }
            return byteKey;
        }

        public static bool Encrypt(string text, string path)
        {

            byte[] encrypted;

            using (Aes aes = Aes.Create())
            {
                aes.IV = ReadVector();
                aes.Key = GetKey();

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);

                        }

                        encrypted = msEncrypt.ToArray();

                    }
                }
            }

            File.WriteAllBytes(path, encrypted);

            return true;
        }

        public static string Decrypt(string path)
        {

            string text = null;

            using (Aes aes = Aes.Create())
            {

                aes.Key = GetKey();

                aes.IV = ReadVector();

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(File.ReadAllBytes(path)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            text = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return text;
        }
    }
}

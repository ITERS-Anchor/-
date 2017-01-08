using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Encryption
    {
        public static string MD5encryption(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Buffer = md5.ComputeHash(buffer);
            StringBuilder encryptData = new StringBuilder();
            foreach (byte b in md5Buffer)
            {
                encryptData.Append(b.ToString("x2"));
            }
            return encryptData.ToString();
        }
    }
}
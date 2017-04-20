using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MPocketCommon.Cryptography
{
    public class PasswordManager : ICryptography
    {
        public string Encrypt(string text)
        {
            string hash = null;
            using (MD5 md5 = MD5.Create())
            {
                hash = GetHash(md5, text);
                return hash;
            }
        }

        public bool IsMatch(string p1, string p2)
        {
            return p1.Equals(p2);
        }

        private string GetHash(HashAlgorithm hash, string text)
        {
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        
    }
}

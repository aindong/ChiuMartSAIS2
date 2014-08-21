using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ChiuMartSAIS2.Classes
{
    class StringHash
    {
        public string hashIt(string text)
        {
            string result = string.Empty;

            SHA256 mySha = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            byte[] hash = mySha.ComputeHash(bytes);

            foreach (byte x in hash)
            {
                result += string.Format("{0:x2}", x);
            }
            return result;
        }
    }
}

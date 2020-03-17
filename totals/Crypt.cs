using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace totals
{
    public static class Crypt
    {

        public static string Decrypting(string crypted)
        {
            byte[] data = System.Convert.FromBase64String(crypted);
            string res = System.Text.ASCIIEncoding.UTF8.GetString(data);
            return res;
        }
    }
}

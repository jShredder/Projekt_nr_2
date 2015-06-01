using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WpfProject2
{
    abstract class Veryfication
    {
        private MD5 md5;
        public abstract bool loginVeryfication(string login);
        public abstract bool passVeryfication(string pass);

        public string hashPass(string pass)
        {
            md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hashBytes = new MD5CryptoServiceProvider().ComputeHash(inputBytes);
            string hashPass = System.Text.Encoding.ASCII.GetString(hashBytes);
            return hashPass;
        }
    }
}

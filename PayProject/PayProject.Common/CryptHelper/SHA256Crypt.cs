using System;
using System.Collections.Generic;
using System.Text;

namespace PayProject.Common.CryptHelper
{
    public class SHA256Crypt
    {
        public static string Encrypt(string strPwd, string salt)
        {
            byte[] passwordAndSaltBytes = System.Text.Encoding.UTF8.GetBytes(strPwd + salt);
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);
            string hashString = Convert.ToBase64String(hashBytes);
            return hashString;
        }
    }
}

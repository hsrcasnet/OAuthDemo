using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace OAuthDemo.Providers
{
    public static class HashHelper
    {
        public static string GetHash(string input)
        {
            var hashAlgorithm = new SHA256CryptoServiceProvider();

            var byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            var byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }
    }
}
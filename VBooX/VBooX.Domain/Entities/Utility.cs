using System;
using System.Security.Cryptography;
using System.Text;

namespace VBooX.Domain.Entities
{
    public class Utility
    {
        public static string GenerateSHA512String(string inputString) => BitConverter.ToString(SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(inputString))).Replace("-", "").ToLower();

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int index = 0; index < hash.Length; ++index)
                stringBuilder.Append(hash[index].ToString());
            return stringBuilder.ToString();
        }
    }
}

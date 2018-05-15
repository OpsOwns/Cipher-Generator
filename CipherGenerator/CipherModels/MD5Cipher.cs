using System.Security.Cryptography;
using System.Text;

namespace CipherGenerator.CipherModels
{
    public static class Md5Cipher
    {
        public static string Md5Encrypt(this string word)
        {
            var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(word);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();

            foreach (var values in hashBytes) sb.Append(values.ToString("X2"));

            return sb.ToString();
        }
    }
}
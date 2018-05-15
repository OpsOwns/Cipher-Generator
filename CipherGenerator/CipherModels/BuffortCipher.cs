using System.Linq;

namespace CipherGenerator.CipherModels
{
    public static class BuffortCipher
    {
        public static string BuffortEncrypt(this string word, int key)
        {
            string encryptedWord = string.Empty;
            var wordArry = word.ToCharArray();
            char[] newArry = new char[wordArry.Length];
            for (int i = 0; i < wordArry.Length; i++)
            {
                int value = wordArry[i];
                value -= 97;
                value = 26 - value + key;
                value = value % 26;
                value += 97;
                newArry[i] += (char)value;
            }
            encryptedWord = newArry.Aggregate(encryptedWord, (current, value) => current + value);
            return encryptedWord.ToLower();
        }

        public static string BuffortDecrypt(this string word, int key)
        {
            string decryptedWord = string.Empty;
            var wordArry = word.ToCharArray();
            char[] newArry = new char[wordArry.Length];
            for (int i = 0; i < wordArry.Length; i++)
            {
                int value = wordArry[i];
                value -= 97;
                value = 26 - value + key;
                value = value % 26;
                value += 97;
                newArry[i] += (char)value;
            }
            decryptedWord = newArry.Aggregate(decryptedWord, (current, value) => current + value);
            return decryptedWord.ToLower();
        }
    }
}
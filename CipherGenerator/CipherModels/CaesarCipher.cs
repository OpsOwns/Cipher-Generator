using System;

namespace CipherGenerator.CipherModels
{
    public static class CaesarCipher
    {
        public static string CaesarCrypt(this string word, int key)
        {
            char[] wordCharArray = word.ToLower().ToCharArray();
            string cipherWordEncryption = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                int number = wordCharArray[i] + key;
                if (number > 122)
                {
                    cipherWordEncryption += Convert.ToString((char)(number - 26));
                }
                else if (number < 97)
                {
                    cipherWordEncryption += Convert.ToString((char)(number + 26));
                }
                else if (number >= 97 && number <= 122)
                {
                    cipherWordEncryption += Convert.ToString((char)number);
                }

            }

            return cipherWordEncryption;
        }

        public static string CaesarDecrypt(this string word, int step)
        {
            char[] wordCharArray = word.ToLower().ToCharArray();
            string cipherWordDecryption = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                int number = wordCharArray[i] - step;

                if (number > 122)
                {
                    cipherWordDecryption += Convert.ToString((char)(number - 26));
                }
                else if (number < 97)
                {
                    cipherWordDecryption += Convert.ToString((char)(number + 26));
                }
                else if (number >= 97 && number <= 122)
                {
                    cipherWordDecryption += (char)number;
                }


            }

            return cipherWordDecryption;
        }
    }
}
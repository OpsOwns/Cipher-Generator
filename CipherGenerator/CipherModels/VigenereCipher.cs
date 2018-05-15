namespace CipherGenerator.CipherModels
{
    public static class VigenereCipher
    {
        public static string VigenereEncrypt(this string word, string key)
        {
            char[] wordCharArray = word.ToLower().ToCharArray();
            char[] keyCharArray = key.ToLower().ToCharArray();
            char[] encryptWordArray = new char[word.Length];
            string encryptedWord = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                encryptWordArray[i] = (char)((wordCharArray[i] - 'a' + (keyCharArray[i % key.Length] - 'a') + 26) % 26 + 'a');
                encryptedWord += encryptWordArray[i];
            }
            return encryptedWord;
        }

        public static string VigenereDecrypt(this string word, string key)
        {
            char[] wordCharArray = word.ToLower().ToCharArray();
            char[] keyCharArray = key.ToLower().ToCharArray();
            char[] decryptWordArray = new char[word.Length];
            string decryptedWord = string.Empty;

            for (int i = 0; i < word.Length; i++)
            {
                decryptWordArray[i] = (char)((wordCharArray[i] - 'a' - (keyCharArray[i % key.Length] - 'a') + 26) % 26 + 'a');
                decryptedWord += decryptWordArray[i];
            }
            return decryptedWord;
        }
    }
}

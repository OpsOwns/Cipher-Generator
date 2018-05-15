namespace CipherGenerator.CipherModels
{
    public static class RailFencecCipher
    {
        public static string RailFencecCipherEncrypt(this string message, int key)
        {
            var arryKeys = new char[key, message.Length];

            for (var i = 0; i < key; i++)
                for (var j = 0; j < message.Length; j++)
                    arryKeys[i, j] = '0';

            int row = 0, col = 0;
            var dirDown = false;

            foreach (var val in message)
            {
                if (row == 0 || row == key - 1)
                    dirDown = !dirDown;

                arryKeys[row, col++] = val;

                if (dirDown)
                    row++;
                else
                    row--;
            }

            var encryptedWord = string.Empty;
            for (var i = 0; i < key; i++)
                for (var j = 0; j < message.Length; j++)
                    if (arryKeys[i, j] != '0')
                        encryptedWord += arryKeys[i, j];

            return encryptedWord.ToLower();
        }

        public static string RailFencecCipherDecrypt(this string message, int key)
        {
            var arryKey = new char[key, message.Length];

            for (var i = 0; i < key; i++)
                for (var j = 0; j < message.Length; j++)
                    arryKey[i, j] = '0';

            var dirDown = false;
            int row = 0, col = 0;

            for (var i = 0; i < message.Length; i++)
            {
                if (row == 0) dirDown = true;

                if (row == key - 1) dirDown = false;

                arryKey[row, col++] = '*';

                if (dirDown)
                    row++;
                else
                    row--;
            }

            var index = 0;
            for (var i = 0; i < key; i++)
                for (var j = 0; j < message.Length; j++)
                    if (arryKey[i, j] == '*' && index < message.Length)
                        arryKey[i, j] = message[index++];

            var decryptedWord = string.Empty;

            row = 0;
            col = 0;

            for (var i = 0; i < message.Length; i++)
            {
                if (row == 0) dirDown = true;

                if (row == key - 1) dirDown = false;

                if (arryKey[row, col] != '*') decryptedWord += arryKey[row, col++];

                if (dirDown)
                    row++;
                else
                    row--;
            }

            return decryptedWord.ToLower();
        }
    }
}
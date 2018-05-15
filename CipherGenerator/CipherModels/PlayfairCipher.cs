using System.Linq;

namespace CipherGenerator.CipherModels
{
    public static class PlayfairCipher
    {
        public static string PlayfairEncrypt(this string word, string key)
        {
            key = key.ToLower();
            string sGrid = string.Empty;
            var sAlpha = "abcdefghiklmnopqrstuvwxyz";

            word = word.ToLower();
            var sOutput = "";
            key = key.Replace('j', 'i');
            foreach (var t in key)
                if (sGrid == null || !sGrid.Contains(t))
                    sGrid += t;

            foreach (var t in sAlpha)
                if (!sGrid.Contains(t))
                    sGrid += t;

            word = word.Replace('j', 'i');
            for (var i = 0; i < word.Length; i += 2)
                if (i + 1 < word.Length && word[i] == word[i + 1])
                    word = word.Insert(i + 1, "x");
            if (word.Length % 2 > 0) word += "x";
            var iTemp = 0;
            do
            {
                var iPosA = sGrid.IndexOf(word[iTemp]);
                var iPosB = sGrid.IndexOf(word[iTemp + 1]);
                var iRowA = iPosA / 5;
                var iColA = iPosA % 5;
                var iRowB = iPosB / 5;
                var iColB = iPosB % 5;

                if (iColA == iColB)
                {
                    iPosA += 5;
                    iPosB += 5;
                }
                else
                {
                    if (iRowA == iRowB)
                    {
                        if (iColA == 4)
                            iPosA -= 4;
                        else
                            iPosA += 1;
                        if (iColB == 4)
                            iPosB -= 4;
                        else
                            iPosB += 1;
                    }
                    else
                    {
                        if (iRowA < iRowB)
                        {
                            iPosA -= iColA - iColB;
                            iPosB += iColA - iColB;
                        }
                        else
                        {
                            iPosA += iColB - iColA;
                            iPosB -= iColB - iColA;
                        }
                    }
                }
                if (iPosA >= sGrid.Length) iPosA = 0 + (iPosA - sGrid.Length);
                if (iPosB >= sGrid.Length) iPosB = 0 + (iPosB - sGrid.Length);
                if (iPosA < 0) iPosA = sGrid.Length + iPosA;
                if (iPosB < 0) iPosB = sGrid.Length + iPosB;
                sOutput += sGrid[iPosA] + sGrid[iPosB].ToString();
                iTemp += 2;
            } while (iTemp < word.Length);
            var encryptedWord = sOutput;
            return encryptedWord;
        }

        public static string PlayfairDecryption(this string word, string key)
        {
            key = key.ToLower();
            string sGrid = string.Empty;
            string sAlpha = "abcdefghiklmnopqrstuvwxyz";
            string sInput = word.ToLower();
            string decryptedWord = "";
            key = key.Replace('j', 'i');
            foreach (var t in key)
            {
                if ((sGrid == null) || (!sGrid.Contains(t)))
                {
                    sGrid += t;
                }
            }
            foreach (var t in sAlpha)
            {
                if (!sGrid.Contains(t))
                {
                    sGrid += t;
                }
            }
            int iTemp = 0;
            do
            {
                int iPosA = sGrid.IndexOf(sInput[iTemp]);
                int iPosB = sGrid.IndexOf(sInput[iTemp + 1]);
                int iRowA = iPosA / 5;
                int iColA = iPosA % 5;
                int iRowB = iPosB / 5;
                int iColB = iPosB % 5;
                if (iColA == iColB)
                {
                    iPosA -= 5;
                    iPosB -= 5;
                }
                else
                {
                    if (iRowA == iRowB)
                    {
                        if (iColA == 0)
                        {
                            iPosA += 4;
                        }
                        else
                        {
                            iPosA -= 1;
                        }
                        if (iColB == 0)
                        {
                            iPosB += 4;
                        }
                        else
                        {
                            iPosB -= 1;
                        }
                    }
                    else
                    {
                        if (iRowA < iRowB)
                        {
                            iPosA -= iColA - iColB;
                            iPosB += iColA - iColB;
                        }
                        else
                        {
                            iPosA += iColB - iColA;
                            iPosB -= iColB - iColA;
                        }
                    }
                }
                if (iPosA > sGrid.Length)
                {
                    iPosA = 0 + (iPosA - sGrid.Length);
                }
                if (iPosB > sGrid.Length)
                {
                    iPosB = 0 + (iPosB - sGrid.Length);
                }
                if (iPosA < 0)
                {
                    iPosA = sGrid.Length + iPosA;
                }
                if (iPosB < 0)
                {
                    iPosB = sGrid.Length + iPosB;
                }
                decryptedWord += sGrid[iPosA] + sGrid[iPosB].ToString();
                iTemp += 2;
            } while (iTemp < sInput.Length);

            return decryptedWord;
        }
    }
}
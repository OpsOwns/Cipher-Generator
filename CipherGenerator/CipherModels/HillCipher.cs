using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Accord.Math;

namespace CipherGenerator.CipherModels
{
    public static class HillCipher
    {
        public static string HillEncrypt(this string word, string keyString)
        {
            var dictionary = new Dictionary<char, int>();
            var encryptValue = "";
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
            for (var i = 0; i < alphabet.Length; i++)
                dictionary.Add(alphabet[i], i);
            var spellWord = word.ToLower().ToCharArray();

            string[] tokens = keyString.Split(',');

            double[] convertedItems = Array.ConvertAll(tokens, double.Parse);

            var key = convertedItems.Length == 4 ? Make2DArray(convertedItems, 2, 2) : Make2DArray(convertedItems, 3, 3);

            if (key.Length == 4)
            {
                if (spellWord.Length % 2 == 0)
                {
                    var value = new double[spellWord.Length];
                    for (var i = 0; i < spellWord.Length; i++)
                        value[i] = dictionary.SingleOrDefault(x => x.Key == spellWord[i]).Value;
                    var result = new double[word.Length];

                    for (var row = 0; row < result.Length; row += 2)
                    {
                        var vald = value[row];
                        var valb = value[row + 1];

                        var vala = key[0, 0] * vald + key[0, 1] * valb;
                        var valc = key[1, 0] * vald + key[1, 1] * valb;

                        result[row] += vala % 26;
                        result[row + 1] += valc % 26;
                    }

                    encryptValue = result.Aggregate(encryptValue,
                        (current, looked) => current + dictionary.FirstOrDefault(z => z.Value == looked).Key.ToString());
                    return encryptValue;
                }
                else
                {
                    var value = new double[spellWord.Length + 1];
                    var newArry = new char[spellWord.Length + 1];

                    for (var i = 0; i < spellWord.Length + 1; i++)
                        if (i == spellWord.Length)
                            newArry[i] += 'x';
                        else
                            newArry[i] += spellWord[i];

                    for (var i = 0; i < newArry.Length; i++)
                        value[i] = dictionary.SingleOrDefault(x => x.Key == newArry[i]).Value;

                    var result = new double[word.Length + 1];


                    for (var row = 0; row < result.Length; row += 2)
                    {
                        var vald = value[row];
                        var valb = value[row + 1];
                        var vala = key[0, 0] * vald + key[0, 1] * valb;
                        var valc = key[1, 0] * vald + key[1, 1] * valb;
                        result[row] += vala % 26;
                        result[row + 1] += valc % 26;
                    }

                    encryptValue = result.Aggregate(encryptValue,
                        (current, looked) => current + dictionary.FirstOrDefault(z => z.Value == looked).Key.ToString());
                    return encryptValue;
                }
            }

            if (key.Length != 9) return encryptValue;
            {
                if (spellWord.Length % 2 == 0)
                {
                    var value = new double[spellWord.Length];
                    for (var i = 0; i < spellWord.Length; i++)
                        value[i] = dictionary.SingleOrDefault(x => x.Key == spellWord[i]).Value;
                    var result = new double[value.Length];
                    double letter = 0;
                    var num = 3;
                    for (var k = 0; k < word.Length - 1; k++)
                    {
                        var d = num;
                        int s;
                        for (s = 0; s <= 2; s++)
                        {
                            int j;
                            for (j = 0; j < 3; j++)
                                if (k > 2)
                                {
                                    letter += value[d] * key[s, j];
                                    d++;
                                }
                                else
                                {
                                    letter += value[j] * key[s, j];
                                }

                            if (d >= num + 3)
                            {
                                num = d - 3;
                                d = num;
                            }

                            result[k] += letter % 26;

                            if (k < result.Length)
                                k++;
                            letter = 0;
                        }

                        k--;
                    }

                    encryptValue = result.Aggregate(encryptValue,
                        (current, looked) => current + dictionary.FirstOrDefault(z => z.Value == looked).Key.ToString());
                    return encryptValue;
                }
                else
                {

                    var value = new int[spellWord.Length + 1];
                    var newArry = new char[spellWord.Length + 1];

                    for (var i = 0; i < spellWord.Length + 1; i++)
                        if (i == spellWord.Length)
                            newArry[i] += 'x';
                        else
                            newArry[i] += spellWord[i];

                    for (var i = 0; i < newArry.Length; i++)
                        value[i] = dictionary.SingleOrDefault(x => x.Key == newArry[i]).Value;

                    var result = new double[value.Length + 1];

                    double letter = 0;
                    var num = 3;
                    for (var k = 0; k < word.Length - 1; k++)
                    {
                        var d = num;
                        int s;
                        for (s = 0; s <= 2; s++)
                        {
                            int j;
                            for (j = 0; j < 3; j++)
                                if (k > 2)
                                {
                                    letter += value[d] * key[s, j];
                                    d++;
                                }
                                else
                                {
                                    letter += value[j] * key[s, j];
                                }

                            if (d >= num + 3)
                            {
                                num = d - 3;
                                d = num;
                            }

                            result[k] += letter % 26;

                            if (k < newArry.Length)
                                k++;
                            letter = 0;
                        }

                        k--;
                    }

                    encryptValue = result.Aggregate(encryptValue,
                        (current, looked) => current + dictionary.FirstOrDefault(z => z.Value == looked).Key.ToString());

                    return encryptValue;
                }
            }
        }
        public static T[,] Make2DArray<T>(T[] input, int height, int width)
        {
            T[,] output = new T[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    output[i, j] = input[i * width + j];
                }
            }
            return output;
        }

        public static string HillDecrypt(this string word, string keyString)
        {
            string[] tokens = keyString.Split(',');

            double[] convertedItems = Array.ConvertAll(tokens, double.Parse);

            var key = convertedItems.Length == 4 ? Make2DArray(convertedItems, 2, 2) : Make2DArray(convertedItems, 3, 3);

            if (convertedItems.Length == 4)
            {
                var trans = key.Transpose();
                var det = trans.Determinant();
                int detValue = Convert.ToInt32(det);

                detValue = detValue.det_mod_26();

                var invertedMatrix = trans.InverseMatrix(detValue);

                double[,] rest = new double[2, 2];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        rest[i, j] += invertedMatrix[j, i] * detValue;
                    }
                }
                string newKey = "";
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        newKey += (rest[j, i] % 26 + 26) % 26 + ",";

                    }
                }
                string updatedKey = newKey.Substring(0, newKey.Length - 1);

                string decryptedWord = word.HillEncrypt(updatedKey);

                return decryptedWord.ToLower();

            }
            else
            {

                var trans = key.Transpose();
                var det = trans.Determinant();
                int detValue = Convert.ToInt32(det);

                detValue = detValue.det_mod_26();

                var invertedMatrix = trans.InverseMatrix(detValue);

                double[,] rest = new double[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        rest[i, j] += invertedMatrix[j, i] * detValue;
                    }
                }
                string newKey = "";
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        newKey += (rest[j, i] % 26 + 26) % 26 + ",";

                    }
                }

                string updatedKey = newKey.Substring(0, newKey.Length - 1);

                string decryptedWord = word.HillEncrypt(updatedKey);

                return decryptedWord.ToLower();
            }


        }

        public static int det_mod_26(this int det)
        {
            const int mod = 26;
            int result = 1;
            var value = ((det % mod) + mod) % mod;
            if (value == 1)
                return result;
            while (result < mod &&
                   value * ++result % 26 != 1)
            {
            }
            return result;
        }

        public static double[,] InverseMatrix(this double[,] matrix, int det)
        {
            var rows = matrix.GetLength(0);
            var cols = matrix.GetLength(1);

            if (rows != cols)
                MessageBox.Show("Macierz musi być kwadratem");

            if (rows == 3)
            {
                double a = matrix[0, 0], b = matrix[0, 1], c = matrix[0, 2];
                double d = matrix[1, 0], e = matrix[1, 1], f = matrix[1, 2];
                double g = matrix[2, 0], h = matrix[2, 1], i = matrix[2, 2];

                var den = det;
                if (den.Equals(0))
                    MessageBox.Show("Wskaźnik nie może być 0");

                double m = 1;

                var inv = new double[3, 3];
                int wartosc1 = (int)(m * (e * i - f * h));
                int wartosc2 = (int)(-m * (d * i - g * f));
                int wartosc3 = (int)(m * (d * h - g * e));

                int wartosc4 = (int)(-m * (b * i - h * c));
                int wartosc5 = (int)(m * (a * i - c * g));
                int wartosc6 = (int)(-m * (a * h - g * b));

                int wartosc7 = (int)(m * (b * f - e * c));
                int wartosc8 = (int)(-m * (a * f - c * d));
                int wartosc9 = (int)(m * (a * e - b * d));

                inv[0, 0] = wartosc1;
                inv[0, 1] = wartosc2;
                inv[0, 2] = wartosc3;
                inv[1, 0] = wartosc4;
                inv[1, 1] = wartosc5;
                inv[1, 2] = wartosc6;
                inv[2, 0] = wartosc7;
                inv[2, 1] = wartosc8;
                inv[2, 2] = wartosc9;

                return inv;
            }

            if (rows != 2) return null;
            {
                double a = matrix[0, 0], b = matrix[0, 1];
                double c = matrix[1, 0], d = matrix[1, 1];
                double den = det;
                if (den.Equals(0))
                    MessageBox.Show("Wskaźnik nie może być 0");

                double m = 1;
                var inv = new double[2, 2];
                var wartosc1 = (int)(m * d);
                var wartosc2 = (int)(-m * c);
                var wartosc3 = (int)(-m * b);
                var wartosc4 = (int)(m * a);

                inv[0, 0] = wartosc1;
                inv[0, 1] = wartosc2;
                inv[1, 0] = wartosc3;
                inv[1, 1] = wartosc4;

                return inv;
            }
        }
    }
}

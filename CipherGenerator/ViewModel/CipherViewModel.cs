using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using CipherGenerator.CipherModels;
using Prism.Commands;
using Prism.Mvvm;

namespace CipherGenerator.ViewModel
{
    [Flags]
    public enum CipherTypes
    {
        Cezara = 0,
        Playfaira = 1,
        Płotkowy = 2,
        Vigenere = 3,
        Beauforta = 4,
        Hilla = 5,
        Md5 = 6
    }

    public class CipherViewModel : BindableBase
    {
        public CipherViewModel()
        {
            DecryptImg = @"\Images\close.png";
            EncryptImg = @"\Images\close.png";
            InformationAboutCrypt();
            EncryptCommand = new DelegateCommand(EncryptWord);
            DecryptCommand = new DelegateCommand(DecryptWord);
        }
        public List<CipherTypes> CipherColletion => Enum.GetValues(typeof(CipherTypes)).Cast<CipherTypes>().ToList();
        private CipherTypes _crypt;
        private string _wordTocrypt = string.Empty;
        private string _wordResult = string.Empty;
        private bool _enableBox = true;
        private bool _enableButton;
        private bool _enableButtonDet;
        private string _textKey = string.Empty;
        private string _textMsg = string.Empty;
        private string _decryptImg = string.Empty;
        private string _encryptImage = string.Empty;
        private readonly Regex _wordEnter = new Regex("^[a-zA-Z]{1,25}$");
        private readonly Regex _numbers = new Regex("^[0-9]{1}$");
        private readonly Regex _hillNumber = new Regex("^[0-9]+(,[0-9]+)*,?$");
        public string DecryptImg
        {
            get => _decryptImg;
            set => SetProperty(ref _decryptImg, value);
        }
        public CipherTypes CihperType
        {
            get => _crypt;
            set
            {
                SetProperty(ref _crypt, value);
                InformationAboutCrypt();
                if (_crypt == CipherTypes.Md5)
                {
                    EnableBox = false;
                    EnableButtonDet = false;
                    TextKey = string.Empty;
                }
                else
                {
                    EnableBox = true;
                }

                WordResult = string.Empty;
                TextKey = string.Empty;

                CheckBtnEnabled();
            }
        }

        public string EncryptImg
        {
            get => _encryptImage;
            set => SetProperty(ref _encryptImage, value);
        }

        public bool EnableButtonDet
        {
            get => _enableButtonDet;
            set => SetProperty(ref _enableButtonDet, value);
        }

        public string TextKey
        {
            get => _textKey;
            set
            {
                SetProperty(ref _textKey, value);
                CheckBtnEnabled();
            }
        }

        public bool EnableButton
        {
            get => _enableButton;
            set => SetProperty(ref _enableButton, value);
        }

        public void CheckBtnEnabled()
        {
            EnableButton = WordToCrypt != string.Empty && TextKey != string.Empty;
            EnableButtonDet = WordToCrypt != string.Empty && TextKey != string.Empty;

            if (EnableButtonDet == false || EnableButton == false)
            {
                DecryptImg = @"\Images\close.png";
                EncryptImg = @"\Images\close.png";
            }
            else
            {
                DecryptImg = @"\Images\open.png";
                EncryptImg = @"\Images\lock.png";
            }

            if (CihperType == CipherTypes.Md5 && WordToCrypt != string.Empty)
            {
                EnableButton = true;
                EncryptImg = @"\Images\lock.png";
            }

        }

        public string WordToCrypt
        {
            get => _wordTocrypt;
            set
            {
                SetProperty(ref _wordTocrypt, value);
                CheckBtnEnabled();


            }
        }

        public string TextMsg { get => _textMsg; set => SetProperty(ref _textMsg, value); }

        public string WordResult
        {
            get => _wordResult;
            set => SetProperty(ref _wordResult, value);
        }

        public bool EnableBox
        {
            get => _enableBox;
            set => SetProperty(ref _enableBox, value);
        }

        public bool ValidateKey(string message, CipherTypes type)
        {

            bool result = false;

            switch (type)
            {
                case CipherTypes.Cezara:
                    result = _numbers.IsMatch(message);
                    break;
                case CipherTypes.Płotkowy:
                    result = _numbers.IsMatch(message);
                    break;
                case CipherTypes.Md5:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Beauforta:
                    result = _numbers.IsMatch(message);
                    break;
                case CipherTypes.Vigenere:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Playfaira:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Hilla:
                    result = _hillNumber.IsMatch(message);
                    break;
            }

            return result;
        }

        public bool ValidateMessage(string message, CipherTypes type)
        {

            bool result = false;

            switch (type)
            {
                case CipherTypes.Cezara:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Płotkowy:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Md5:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Beauforta:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Vigenere:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Playfaira:
                    result = _wordEnter.IsMatch(message);
                    break;
                case CipherTypes.Hilla:
                    result = _wordEnter.IsMatch(message);
                    break;
            }

            return result;
        }



        public void InformationAboutCrypt()
        {
            if (CihperType == CipherTypes.Cezara || CihperType == CipherTypes.Płotkowy || CihperType == CipherTypes.Beauforta)
            {
                TextMsg = "Można wprowadzić liczbę z zakresu 0-9 jako klucz.";
            }
            else if (CihperType != CipherTypes.Md5)
            {
                TextMsg = "Można wprowadzić dowolne słowo będące kluczem, zawierające jedynie znaki łacińskie.";
            }

            switch (CihperType)
            {
                case CipherTypes.Hilla:
                    TextMsg = "Możesz wprowadzić liczby po , z zakresu 0-9, maksymalnie 9 min 4";
                    break;
                case CipherTypes.Md5:
                    TextMsg = "Dany szyfr nie wymaga klucza, lecz zaszyfrowanej wiadomości nie można odszyfrować";
                    break;
            }
        }

        public void EncryptWord()
        {
            switch (CihperType)
            {
                case CipherTypes.Cezara:

                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.CaesarCrypt(Convert.ToInt32(TextKey));
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz lub dane słowo.", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Beauforta:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.BuffortEncrypt(Convert.ToInt32(TextKey));
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz lub dane słowo.", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Vigenere:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.VigenereEncrypt(TextKey);
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz lub dane słowo.", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Md5:
                    if (ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.Md5Encrypt();
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz lub dane słowo.", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Płotkowy:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.RailFencecCipherEncrypt(Convert.ToInt32(TextKey));
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Playfaira:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.PlayfairEncrypt(TextKey);
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Hilla:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                    {
                        WordResult = WordToCrypt.HillEncrypt(TextKey);
                    }
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
            }
        }

        public void DecryptWord()
        {
            switch (CihperType)
            {
                case CipherTypes.Cezara:

                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.CaesarDecrypt(Convert.ToInt32(TextKey));
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz lub dane słowo.", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Beauforta:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.BuffortDecrypt(Convert.ToInt32(TextKey));
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz lub dane słowo.", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Vigenere:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.VigenereDecrypt(TextKey);
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz lub dane słowo.", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Płotkowy:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.RailFencecCipherDecrypt(Convert.ToInt32(TextKey));
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Playfaira:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.PlayfairDecryption(TextKey);
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
                case CipherTypes.Hilla:
                    if (ValidateKey(TextKey, CihperType) && ValidateMessage(WordToCrypt, CihperType))
                        WordResult = WordToCrypt.HillDecrypt(TextKey);
                    else
                    {
                        MessageBox.Show("Niepoprawny klucz", "Ostrzeżenie", MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                    }
                    break;
            }
        }

        public DelegateCommand EncryptCommand { get; }
        public DelegateCommand DecryptCommand { get; }

    }
}

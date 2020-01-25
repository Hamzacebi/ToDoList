using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Helpers.HelperOfToDoList.Extensions
{
    /// <summary>
    /// typeof(String) icin yazilan ozel fonksiyonlari iceren class
    /// </summary>
    public static class ExtensionsOfString
    {
        /// <summary>
        /// Girilen ifade icerisinde isaretli olan (Ğ-ğ, Ü-ü, Ş-ş, İ-ı, Ö-ö ve Ç-ç) isaretsiz olan kucuk harflere (Ğ-ğ->g, Ü-ü->u, Ş-ş->s, İ-ı->i, Ö-ö->o ve Ç-ç->c)
        /// donusturmeye yarayan fonksiyon
        /// </summary>
        /// <param name="inputText">Donusturulmek istenilen ifade</param>
        /// <returns></returns>
        public static string ConvertTurkishCharactersToEnglishCharacters(this String inputText)
        {
            if (!String.IsNullOrEmpty(inputText))
            {
                inputText = inputText.Trim().ToLower();
                if (!String.IsNullOrEmpty(value: inputText))
                {
                    //Kucuk 'ı' harfi donusturulemedigi icin bu kontrol koyulmak zorundadir
                    if (inputText.Contains("ı"))
                    {
                        inputText = inputText.Replace('ı', 'i');
                    }

                    inputText = inputText.Normalize(normalizationForm: NormalizationForm.FormD);

                    if (inputText.Any(character => char.GetUnicodeCategory(c: character) != UnicodeCategory.NonSpacingMark))
                    {
                        inputText = String.Join("",
                                                inputText.Where(charachter => char.GetUnicodeCategory(c: charachter) != UnicodeCategory.NonSpacingMark));
                    }

                }
            }
            return inputText;
        }
    }
}

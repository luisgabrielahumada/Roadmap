    public class Language : ILanguage
    {
        public Language() { }
        public Language(int languageID, string cultureCode)
        {
            LanguageID = languageID;
            CultureCode = cultureCode;
            LanguageDescription = CommonResources.Languages(this.LanguageID);
            EnglishDescription = CommonResources.LanguagesEN(this.LanguageID);
            DescriptionWithMarket = (cultureCode.Substring(cultureCode.Length - 2)).ToUpper() + " - " + CommonResources.Languages(this.LanguageID);
        }

        public int LanguageID { get; set; }
        public string LanguageDescription { get; set; }
        public string CultureCode { get; set; }
        public string EnglishDescription { get; set; }
        public string DescriptionWithMarket { get; set; }
        public string Country { get; set; }

        /// <summary>
        /// Gets the language's description from the Languages global resource file
        /// </summary>
        public string GetLanguageDescription()
        {
            var result = this.LanguageDescription;
            var x = System.Globalization.CultureInfo.CurrentUICulture;
            var y = System.Globalization.CultureInfo.CurrentCulture;
            try
            {
                var resourceValue = CommonResources.Languages(this.LanguageID);
                if (resourceValue != null)
                {
                    result = (string)resourceValue;
                    this.LanguageDescription = result;
                }
            }
            catch { }

            return result;
        }
    }

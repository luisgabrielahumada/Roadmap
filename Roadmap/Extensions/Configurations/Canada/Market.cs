using System.Collections.Generic;

public class CanadaMarket : Market
    {
        public CanadaMarket()
            : base()
        {
            Name        = MarketName.Canada;
            Description = "Canada";
            CookieValue = CountryCodes.Canada;
            CultureCode = CultureCodes.English_Canada;
            //CurrencyCode = CurrencyCodes.DollarsCAN;
            CountryCode = CountryCodes.Canada;
            //CultureCode = "fr-CA";
            IsDefault   = false;
            Countries   = new List<string> { CountryCodes.Canada};
            MaxOrderAmount = 1300;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 199;
            taxMask = "999-999-999";
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec",
                //Address = CorporateAddress(),
                Phone = "+1 438-834-3092",
                Email = "infocanada@immunotec.com",
                //Facebook = FacebookUrl(),
                //Twitter = TwitterUrl(),
                YouTube = "https://www.youtube.com/user/CorpImmunotec",
                Blog = "",
                Pinterest = "",
                Instagram = "https://www.instagram.com/immunoteccorporate/",
                LinkedIn = "https://www.linkedin.com/company/1813270",
                Google = "https://plus.google.com/+immunotec",
                Vimeo = "https://vimeo.com/immunotecinc",
                Podcast = "http://immunotec.podbean.com/",
                DefaultCompanyMessage = "",
            };

            //AvailablePaymentTypes = new List<IPaymentMethod>
            //{
            //    new CreditCard()                
            //};

            AvailableLanguages = new List<Language> 
            { 
                new Language(Languages.English_Canada, CultureCodes.English_Canada),
                new Language(Languages.French_Canada, CultureCodes.French_Canada),
                new Language(Languages.Spanish_Canada, CultureCodes.Spanish_Canada) // WEB-672
            };

            //AvailableAutoOrderFrequencyTypes = new List<Common.Api.ExigoWebService.FrequencyType>
            //{
            //    Api.ExigoWebService.FrequencyType.Monthly,
            //    Api.ExigoWebService.FrequencyType.BiWeekly,              
            //    Api.ExigoWebService.FrequencyType.Weekly
            //};

            AvailableShipMethods = new List<int> { 6, 7 };
        }

        public override IMarketConfiguration GetConfiguration()
        {
            return new CanadaConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "300 Rue Joseph-Carrier",
        //        Address2 = "",
        //        City = "Vaudreuil-Dorion",
        //        State = "QC",
        //        Zip = "J7V 5V5",
        //        Country = "CA"
        //    };
        //}

        //public string FacebookUrl()
        //{
        //    var language = GetSelectedLanguage();
        //    var url = string.Empty;
        //    switch (language)
        //    {
        //        case CultureCodes.French_Canada:
        //            url = "https://www.facebook.com/ImmunotecInc";
        //            break;
        //        case CultureCodes.Spanish_Canada: // WEB-672
        //            url = "https://www.facebook.com/ImmunotecInc.esp/";
        //            break;
        //        case CultureCodes.English_Canada:
        //        default:
        //            url = "https://www.facebook.com/Immunotec";
        //            break;
        //    }
        //    return url;
        //}
        //public string TwitterUrl()
        //{
        //    var language = Exigo.GetSelectedLanguage();
        //    var url = string.Empty;
        //    switch (language)
        //    {
        //        case CultureCodes.French_Canada:
        //            url = "https://twitter.com/ImmunotecFr";
        //            break;
        //        case CultureCodes.Spanish_Canada: // WEB-672
        //            url = "https://twitter.com/immunotec_hq";
        //            break;
        //        case CultureCodes.English_Canada:
        //        default:
        //            url = "https://twitter.com/immunotec_hq";
        //            break;
        //    }
        //    return url;
        //}


    }

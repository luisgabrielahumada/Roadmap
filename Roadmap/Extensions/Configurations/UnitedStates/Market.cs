

using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class UnitedStatesMarket : Market
    {
        public UnitedStatesMarket()
            : base()
        {
            Name        = MarketName.UnitedStates;
            Description = CommonResources.Countries(CountryCodes.UnitedStates);
            CookieValue = CountryCodes.UnitedStates;
            CultureCode = CultureCodes.English_UnitedStates;
            CurrencyCode = CurrencyCodes.DollarsUS;
            CountryCode = CountryCodes.UnitedStates;
            IsDefault   = true;
            Countries   = new List<string> { CountryCodes.UnitedStates };
            MaxOrderAmount = 1300;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 198;
            taxMask = "999-99-9999";
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec",
                //Address = CorporateAddress(),
                Phone = "+1 832-915-3603",
                Email = "info@immunotec.com",
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
                new Language(Languages.English_UnitedStates, CultureCodes.English_UnitedStates),
                new Language(Languages.Spanish_UnitedStates, CultureCodes.Spanish_UnitedStates)
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
            return new UnitedStatesConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "5895 Rickenbacker Road",
        //        Address2 = "",
        //        City = "Commerce",
        //        State = "CA",
        //        Zip = "90040",
        //        Country = "US"

        //    };
        //}
        //public string FacebookUrl()
        //{
        //    var language = Exigo.GetSelectedLanguage();
        //    var url = string.Empty;
        //    switch (language)
        //    {
        //        case "es-US":
        //            url = "https://www.facebook.com/ImmunotecInc.esp/";
        //            break;
        //        case "en-US":
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
        //        case "es-US":
        //            url = "https://twitter.com/immunotec_hq";
        //            break;
        //        case "en-US":
        //        default:
        //            url = "https://twitter.com/ImmunotecInc";
        //            break;
        //    }
        //    return url;
        //}

        public override string GetWalletAccount(HttpRequestBase request)
        {
            var Iscookie = request.Cookies.AllKeys.Contains(GlobalSettings.Globalization.SetAccessActive);
            if (request.IsLocal || Iscookie)
            {
                return "act-c7088cbe-2912-42d3-ba69-45df2d888e0c";
            }

            return "act-8938d141-cca5-433c-ba47-43dd6437acf8";
        }

    }



using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class UnitedKingdomMarket : Market
    {
        public UnitedKingdomMarket()
            : base()
        {
            Name        = MarketName.UnitedKingdom;
            Description = CommonResources.Countries(CountryCodes.UnitedKingdom);
            CookieValue = CountryCodes.UnitedKingdom;
            CultureCode = CultureCodes.English_GreatBritain;
            CurrencyCode = CurrencyCodes.PoundsUK;
            CountryCode = CountryCodes.UnitedKingdom;
            IsDefault   = true;
            Countries   = new List<string> { CountryCodes.UnitedKingdom };
            MaxOrderAmount = 1000;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 203;
            taxMask = "";
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec",
                //Address = CorporateAddress(),
                Phone = "+44 20 8103 9080",
                Email = "infoeurope@immunotec.com",
                Facebook = "https://www.facebook.com/Immunotec",
                Twitter = "https://twitter.com/immunotec_hq",
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
                new Language(Languages.English_GreatBritain, CultureCodes.English_GreatBritain),
            };

            //AvailableAutoOrderFrequencyTypes = new List<Common.Api.ExigoWebService.FrequencyType>
            //{
            //    Api.ExigoWebService.FrequencyType.Monthly,
            //    Api.ExigoWebService.FrequencyType.BiWeekly,              
            //    Api.ExigoWebService.FrequencyType.Weekly
            //};

            AvailableShipMethods = new List<int> { 6, 7 };

            IncludeTax = true;
        }

        public override IMarketConfiguration GetConfiguration()
        {
            return new UnitedKingdomConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "1st Floor, The Liffey Trust Centre",
        //        Address2 = "117‐126 Sheriff Street Upper",
        //        City = "Dublin 1",
        //        State = "",
        //        Zip = "",
        //        Country = "IE"
        //    };
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

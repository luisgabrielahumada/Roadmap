

using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class MexicoMarket : Market
    {
        public MexicoMarket()
            : base()
        {
            Name        = MarketName.Mexico;
            Description = CommonResources.Countries(CountryCodes.Mexico);
            CookieValue = CountryCodes.Mexico;
            CultureCode = CultureCodes.Spanish_Mexico;
            CurrencyCode = CurrencyCodes.PesosMEX;
            CountryCode = CountryCodes.Mexico;
            IsDefault   = false;
            Countries   = new List<string> { CountryCodes.Mexico };
            MaxOrderAmount = 22000;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 200;
            taxMask = "aaaa999999***";
            curpMask = "aaaa999999haa*****";
            AllowBankPayments = true;
            BankChoices = new Dictionary<string, string>() { { "HSBC", "2" }, {"Banamex", "3" } };
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec",
                //Address = CorporateAddress(),
                Phone = "+52 55 4161 3146",
                Email = "infomx@immunotec.com",
                Facebook = "https://www.facebook.com/ImmunotecIncMexico/",
                Twitter = "https://twitter.com/ImmunotecInc",
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
                new Language(Languages.Spanish_Mexico, CultureCodes.Spanish_Mexico)
            };

            //AvailableAutoOrderFrequencyTypes = new List<Common.Api.ExigoWebService.FrequencyType>
            //{
            //    Api.ExigoWebService.FrequencyType.Monthly,
            //    Api.ExigoWebService.FrequencyType.BiWeekly,              
            //    Api.ExigoWebService.FrequencyType.Weekly
            //};

            AvailableShipMethods = new List<int> { 6, 7 };
            //ID of the user account for each country associated with the shop, by sending only 
            //payment means belonging to that country will be displayed.
            AppId = "com.immunotec.payumexico";
            PrivateKey = "76bfbe61-4f15-48b3-a0b9-218b3cc36198";

            TestAppId = "com.immunotec.514789";
            TestPrivateKey = "1c09599d-afd8-40e6-9084-fc1c3ef32fe9";
            IncludeTax = true;
        }

        public override IMarketConfiguration GetConfiguration()
        {
            return new MexicoConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "Avenida Santa Fe, 428. Piso 2 Torre III",
        //        Address2 = "Col. Santa Fe Cuajimalpa",
        //        City = "Cuajimalpa de Morelos, C.P.",
        //        State = "",
        //        Zip = "05348",
        //        Country = "MX"
        //    };
        //}

        public override string GetWalletAccount(HttpRequestBase request)
        {
            var Iscookie = request.Cookies.AllKeys.Contains(GlobalSettings.Globalization.SetAccessActive);
            if (request.IsLocal || Iscookie)
            {
                return "act-85fd5b57-0c1a-4fb9-b2a8-8c5778991832";
            }

            return "act-569f0781-1e23-48be-a1eb-9ae3f799c30b";
        }
    }

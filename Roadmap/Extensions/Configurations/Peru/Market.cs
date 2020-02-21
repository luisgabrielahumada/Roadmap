

using System.Collections.Generic;

    public class PeruMarket : Market
    {
        public PeruMarket()
            : base()
        {
            Name = MarketName.Peru;
            Description = CommonResources.Countries(CountryCodes.Peru);
            CookieValue = CountryCodes.Peru;
            CultureCode = CultureCodes.Spanish_Peru;
            CountryCode = CountryCodes.Peru;
            CurrencyCode = CurrencyCodes.PeruSol;
            IsDefault = false;
            Countries = new List<string> { CountryCodes.Peru };
            MaxOrderAmount = 2000;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 200;
            taxMask = "9999999999";
            curpMask = "aaaa999999haa*****";
            AllowBankPayments = true;
            HasPayU = true;
            BankChoices = new Dictionary<string, string>() {  };
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec Peru S.A.C.",
                //Address = CorporateAddress(),
                Phone = "+51 1 707 1222",
                Email = "infope@immunotec.com",
                Facebook = "https://www.facebook.com/ImmunotecIncColombia/",
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
                Nit = "901.049.920-1"
            };

            //AvailablePaymentTypes = new List<IPaymentMethod>
            //{
            //    new CreditCard()
            //};

            AvailableLanguages = new List<Language>
            {
                new Language(Languages.Spanish_Peru, CultureCodes.Spanish_Peru)
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
            AppId = "com.immunotec.payuperu";
            PrivateKey = "20c996c6-a068-4d40-b110-6d795dfc93d0";

            ApiLogin = "2R52uj5SvMsP4s9";
            ApiKey = "uU8lmG57q7l2h1g1T9vel66t6P";

            TestAppId = "co.immunotest.unitperu";
            TestPrivateKey = "498b9cf9-e25c-4ce9-b773-28303ec63752";

            TestApiLogin = "He7PQXr7vE1E529";
            TestApiKey = "4e5pXj3o88TE04klsiJ317h3G9";
            IncludeTax = true;
        }

        public override IMarketConfiguration GetConfiguration()
        {
            return new PeruConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "Av. Emilio Cavenecia 151 Oficina 214-A,",
        //        Address2 = "Urb. Santa Cruz",
        //        City = "Lima",
        //        State = "Miraflores",
        //        Zip = "15021",
        //        Country = "PE"
        //    };
        //}
    }

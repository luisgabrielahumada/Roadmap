using System.Collections.Generic;

public class ColombiaMarket : Market
    {
        public ColombiaMarket()
            : base()
        {
            Name = MarketName.Colombia;
            Description = CommonResources.Countries(CountryCodes.Colombia);
            CookieValue = CountryCodes.Colombia;
            CultureCode = CultureCodes.Spanish_Colombia;
            CountryCode = CountryCodes.Colombia;
            CurrencyCode = CurrencyCodes.ColombianPeso;
            IsDefault = false;
            Countries = new List<string> { CountryCodes.Colombia };
            MaxOrderAmount = 2285000;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 200;
            taxMask = "9999999999";
            curpMask = "aaaa999999haa*****";
            AllowBankPayments = true;
            HasPayU = true;
            BankChoices = new Dictionary<string, string>() { { "Banco Colpatria", "5" } };
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec Colombia S.A.S.",
                //Address = CorporateAddress(),
                Phone = "+57 1 508 6287",
                Email = "infoco@immunotec.com",
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
                new Language(Languages.Spanish_Colombia, CultureCodes.Spanish_Colombia)
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
            AppId = "com.immunotec.payucolombia";
            PrivateKey = "a085df4a-4170-44d2-a354-2fcde74539f6";

            TestAppId = "com.immunotec.514788";
            TestPrivateKey = "0f1de304-6feb-4597-b7f4-4c2bda55fded";

            TestApiLogin = "1VtA10qYRI3c3vO";
            TestApiKey = "LYHSbBlP4OFAi5dfMJNdsU46AV";

            ApiLogin = "Bv37ZZ062AvaKnC";
            ApiKey = "5ReQ4kLAv56h9ub8Dp6466A5OK";

            IncludeTax = true;
        }

        public override IMarketConfiguration GetConfiguration()
        {
            return new ColombiaConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "Autopista Medellín, Km 8.5",
        //        Address2 = "Centro Empresarial Milan",
        //        City = "Medellin",
        //        State = "",
        //        Zip = "Tenjo, CUN. 250207",
        //        Country = "CO"
        //    };
        //}
    }

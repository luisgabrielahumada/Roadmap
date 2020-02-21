

using System.Collections.Generic;

    public class GuatemalaMarket : Market
    {
        public GuatemalaMarket()
            : base()
        {
            Name        = MarketName.Guatemala;
            Description = CommonResources.Countries(CountryCodes.Guatemala);
            CookieValue = CountryCodes.Guatemala;
            CultureCode = CultureCodes.Spanish_Guatemala;
            CurrencyCode = CurrencyCodes.GuatemalanQuetzal;
            CountryCode = CountryCodes.Guatemala;
            IsDefault   = false;
            Countries   = new List<string> { CountryCodes.Guatemala };
            MaxOrderAmount = 6000;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 0;
            taxMask = "9999999999999";
            curpMask = "9999999-*";
            nitMask = "9999999-9";
            AllowBankPayments = true;
            BankChoices = new Dictionary<string, string>() { { "Banrural", "Banrural" }, { "Banco Industrial", "4" } };
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec",
               // Address = CorporateAddress(),
                Phone = "+502 2 458 1290",
                Email = "infogt@immunotec.com",
                Facebook = "https://www.facebook.com/ImmunotecIncGuatemala/",
                Twitter = "https://twitter.com/ImmunotecInc",
                YouTube = "https://www.youtube.com/user/CorpImmunotec",
                Blog = "",
                Pinterest = "",
                Instagram = "",
                LinkedIn = "https://www.linkedin.com/company/immunotec",
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
                new Language(Languages.Spanish_Guatemala, CultureCodes.Spanish_Guatemala)
            };

            //AvailableAutoOrderFrequencyTypes = new List<Common.Api.ExigoWebService.FrequencyType>
            //{
            //    Api.ExigoWebService.FrequencyType.Monthly,
            //    Api.ExigoWebService.FrequencyType.BiWeekly,              
            //    Api.ExigoWebService.FrequencyType.Weekly
            //};

            AvailableShipMethods = new List<int> { 58, 60 };

            IncludeTax = true;
        }

        public override IMarketConfiguration GetConfiguration()
        {
            return new GuatemalaConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "Consolidados 807",
        //        Address2 = " S.A. 25 Avenida 31 - 23",
        //        Address3 = "Zona 12",
        //        City = "Colonia Santa Elisa ll",
        //        State = "Guatemala",
        //        Zip = "01012",
        //        Country = "GT"
        //    };
        //}
    }

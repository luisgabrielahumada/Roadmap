

using System.Collections.Generic;

    public class DominicanRepublicMarket : Market
    {
        public DominicanRepublicMarket()
            : base()
        {
            Name        = MarketName.DominicanRepublic;
            Description = CommonResources.Countries(CountryCodes.DominicanRepublic);
            CookieValue = CountryCodes.DominicanRepublic;
            CultureCode = CultureCodes.Spanish_DominicanRepublic;
            CurrencyCode = CurrencyCodes.DominicanPeso;
            CountryCode = CountryCodes.DominicanRepublic;
            IsDefault   = false;
            Countries   = new List<string> { CountryCodes.DominicanRepublic };
            MaxOrderAmount = 41500;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 201;
            taxMask = "***********";
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec República Dominicana S.R.L",
                //Address = CorporateAddress(),
                Phone = "+1 829-954-7209",
                Email = "inford@immunotec.com",
                Facebook = "https://www.facebook.com/ImmunotecInc.esp/",
                Twitter = "https://twitter.com/immunotecInc",
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
                new Language(Languages.Spanish_DominicanReplublic, CultureCodes.Spanish_DominicanRepublic)
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
            return new DominicanRepublicConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "Av. Abraham Lincoln, No 1009",
        //        Address2 = "",
        //        City = "Piantini",
        //        State = "Santo Domingo",
        //        Zip = "",
        //        Country = "DO"
        //    };
        //}
    }

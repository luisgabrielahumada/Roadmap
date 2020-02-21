

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class SpainMarket : Market
    {
        public SpainMarket()
            : base()
        {
            Name = MarketName.Spain;
            Description = CommonResources.Countries(CountryCodes.Spain);
            CookieValue = CountryCodes.Spain;
            CultureCode = CultureCodes.Spanish_Spain;
            CurrencyCode = CurrencyCodes.Euro;
            CountryCode = CountryCodes.Spain;
            IsDefault = true;
            Countries = new List<string> { CountryCodes.Spain };
            MaxOrderAmount = 1200;
            MaxMultipleAmount = 3;
            SportsNutritionCategoryID = 358;
            taxMask = "";
            Company = new CompanyInfo()
            {
                CorporateCalendarAccountID = 1,
                Name = "Immunotec Research España S.L.U.",
                //Address = CorporateAddress(),
                Phone = "(+34) 518 880 576",
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
                Nit = "B88487657"
            };

            //AvailablePaymentTypes = new List<IPaymentMethod>
            //{
            //    new CreditCard()
            //};

            AvailableLanguages = new List<Language>
            {
                new Language(Languages.Spanish_Spain, CultureCodes.Spanish_Spain),
                new Language(Languages.English_Spain, CultureCodes.English_Spain)
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
            return new SpainConfiguration();
        }

        //public Address CorporateAddress()
        //{
        //    return new Address
        //    {
        //        Address1 = "Paseo de la Castellana 43",
        //        Address2 = "",
        //        City = "Madrid",
        //        State = "",
        //        Zip = "28046",
        //        Country = "ES"
        //    };
        //}
    }

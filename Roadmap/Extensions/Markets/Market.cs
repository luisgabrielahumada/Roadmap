using System.Collections.Generic;
using System.Web;

public class Market : IMarket
    {
        public Market()
        {
            this.Configuration = GetConfiguration();
        }

        public MarketName Name { get; set; }
        public string Description { get; set; }
        public string CookieValue { get; set; }
        public string CultureCode { get; set; }
        public string CountryCode { get; set; }
        public bool IsDefault { get; set; }
        public IEnumerable<string> Countries { get; set; }
        public int MaxOrderAmount { get; set; }
        public int MaxMultipleAmount { get; set; }
        public string taxMask { get; set; }
        public string curpMask { get; set; }
        public string nitMask { get; set; }
        public CompanyInfo Company { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsPickup { get; set; }

        public List<IPaymentMethod> AvailablePaymentTypes { get; set; }
        public List<Language> AvailableLanguages { get; set; }
        //public List<Common.Api.ExigoWebService.FrequencyType> AvailableAutoOrderFrequencyTypes { get; set; }
        public List<int> AvailableShipMethods { get; set; }
        public IMarketConfiguration Configuration { get; set; }
        public bool AllowBankPayments { get; set; }
        public bool HasPayU { get; set; }
        public Dictionary<string, string> BankChoices { get; set; }


        // Category ID for items on the Sports Nutrition page
        public int SportsNutritionCategoryID { get; set; }

        public virtual IMarketConfiguration GetConfiguration()
        {
            return new UnitedStatesConfiguration();
        }
        public string TestAppId { get; set; }
        public string TestPrivateKey { get; set; }

        public string AppId { get; set; }
        public string PrivateKey { get; set; }


        public string TestApiLogin { get; set; }
        public string TestApiKey { get; set; }

        public string ApiLogin { get; set; }
        public string ApiKey { get; set; }
        public bool IncludeTax { get; set; }
        public virtual string GetWalletAccount(HttpRequestBase request) { return string.Empty; }
    }

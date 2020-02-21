using System.Collections.Generic;
using System.Web;

public static class CommonResources
{
    public static string Countries(string countryCode, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(countryCode, 2, "Country", "Countries", format);
    }
    public static string CountriesEN(string countryCode, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(countryCode, 2, "EN_Country", "CountriesEN", format);
    }
    public static string DepositAccountType(int accountTypeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(accountTypeID, 2, "DepositAccountType", "DepositAccountTypes", format);
    }

    public static string Language(int languageID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(languageID, 3, "Language", "Languages", format);
    }
    public static string Bonuses(int periodTypeID, int bonusID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        var resourceKeyPrefix = "Bonus";
        var padding = 4;

        // Build our resource key
        var resourceKey = "{0}_{1}_{2}".FormatWith(resourceKeyPrefix, periodTypeID, bonusID.ToString().PadLeft(padding, '0'));
        if (format != CommonResourceFormat.Default) resourceKey += "_{0}".FormatWith(format.ToString());

        // Get the resource
        var resource = GetGlobalResource("Common", resourceKey, "{0} {1} {2}".FormatWith(resourceKeyPrefix, periodTypeID, bonusID));

        // If the resource is null and we asked for a specific format, get the default format instead.
        if (resource.IsNullOrEmpty() && format != CommonResourceFormat.Default)
        {
            return Bonuses(periodTypeID, bonusID, CommonResourceFormat.Default);
        }
        else
        {
            return resource;
        }
    }
    public static string CreditCardTypes(int creditCardTypeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(creditCardTypeID, 2, "CreditCardType", "CreditCardTypes", format);
    }
    public static string Categories(string categorydescription, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(categorydescription, 2, "Category", "Categories", format);
    }
    public static string Languages(int languageID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(languageID, 3, "Language", "Languages", format);
    }
    public static string LanguagesEN(int languageID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(languageID, 3, "EN_Language", "Languages", format);
    }
    public static string CustomerTypes(int customerTypeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(customerTypeID, 2, "CustomerType", "CustomerTypes", format);
    }
    public static string CustomerTypeFilters(int customerTypeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(customerTypeID, 2, "CustomerTypeFilter", "CustomerTypeFilter", format);
    }
    public static string CustomerStatuses(int customerStatusID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(customerStatusID, 2, "CustomerStatus", "CustomerStatuses", format);
    }

    public static string CustomerStatuses(int customerStatusID, string key, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(customerStatusID, 2, key, key, format);
    }

    public static string OrderStatuses(int orderStatusID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(orderStatusID, 2, "OrderStatus", "OrderStatuses", format);
    }
    public static string Ranks(int rankID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(rankID, 2, "Rank", "Ranks", format);
    }
    //public static string RankQualifications(string text, string qualificationLabel, CommonResourceFormat format = CommonResourceFormat.Default)
    //{
    //    return GetGlobalResource("Common", "RankQualification_" + GlobalUtilities.RemoveSpecialCharacters(qualificationLabel), text);
    //}

    public static string Volumes(int volumeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(volumeID, 3, "Volume", "Volumes", format);
    }
    public static string FrequencyTypes(int frequencyTypeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(frequencyTypeID, 2, "FrequencyType", "FrequencyTypes", format);
    }
    public static string PaymentTypes(int paymentTypeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(paymentTypeID, 2, "PaymentType", "PaymentTypes", format);
    }
    public static string PayableTypes(int payableTypeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(payableTypeID, 2, "PayableType", "PayableTypes", format);
    }
    public static string PeriodTypes(int periodTypeID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(periodTypeID, 3, "PeriodType", "PeriodTypes", format);
    }
    public static string PointAccounts(int pointAccountID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(pointAccountID, 2, "PointAccount", "PointAccounts", format);
    }
    public static string Subscriptions(int subscriptionID, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(subscriptionID, 2, "Subscription", "Subscriptions", format);
    }
    public static string GetCountryTaxCode(string CountryCode, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        return GetCommonResource(CountryCode, 2, "TaxCode", "TaxCodes", format);
    }

    public static string EventTypes(string eventDescription, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        var key = eventDescription.Replace("&", "").Replace(" ", "").ToLower();
        return GetGlobalResource("Common", "EventType_" + key, eventDescription);
    }

    public static string ResourceTypes(string ResourceDescription, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        var key = ResourceDescription.Replace("&", "").Replace(" ", "").ToLower();
        return GetGlobalResource("Common", "ResourceType_" + key, ResourceDescription);
    }

    private static string GetCommonResource(object id, int padding, string resourceKeyPrefix, string classKey, CommonResourceFormat format = CommonResourceFormat.Default)
    {
        if (id == null) id = string.Empty;

        // Build our resource key
        var resourceKey = "{0}_{1}".FormatWith(resourceKeyPrefix, id.ToString().PadLeft(padding, '0'));
        if (format != CommonResourceFormat.Default) resourceKey += "_{0}".FormatWith(format.ToString());

        // Get the resource
        var fallback = (format == CommonResourceFormat.Default) ? "{0} {1}".FormatWith(resourceKeyPrefix, id) : string.Empty;
        var resource = GetGlobalResource("Common", resourceKey, fallback);

        // If the resource is null and we asked for a specific format, get the default format instead.
        if (resource.IsNullOrEmpty() && format != CommonResourceFormat.Default)
        {
            return GetCommonResource(id, padding, resourceKeyPrefix, "Common");
        }
        else
        {
            return resource;
        }
    }
    private static string GetGlobalResource(string classKey, string resourceKey, string fallback)
    {
        try
        {
            var result = HttpContext.GetGlobalResourceObject(classKey, resourceKey);

            if (result != null) return (string)result;
            else return fallback;
        }
        catch
        {
            return fallback;
        }
    }

}

public enum CommonResourceFormat
{
    Default,
    Short
}


public static class Languages
{
    /// <summary>
    ///	Language ID 0
    /// </summary>
    public const int English = 0;
    /// <summary>
    ///	Language ID 1
    /// </summary>
    public const int Spanish = 1;
    /// <summary>
    ///	Language ID 2
    /// </summary>
    public const int German = 2;
    /// <summary>
    ///	Language ID 3
    /// </summary>
    public const int Korean = 3;
    /// <summary>
    ///	Language ID 4
    /// </summary>
    public const int Belorussian = 4;
    /// <summary>
    ///	Language ID 5
    /// </summary>
    public const int Japanese = 5;
    /// <summary>
    ///	Language ID 6
    /// </summary>
    public const int French = 6;
    /// <summary>
    ///	Language ID 7
    /// </summary>
    public const int Mandarin = 7;
    /// <summary>
    ///	Language ID 8
    /// </summary>
    public const int ChineseTaiwan = 8;
    /// <summary>
    ///	Language ID 9
    /// </summary>
    public const int Thai = 9;
    /// <summary>
    ///	Language ID 10
    /// </summary>
    public const int TagalecPhillipino = 10;
    /// <summary>
    ///	Language ID 11
    /// </summary>
    public const int Hungarian = 11;
    /// <summary>
    ///	Language ID 12
    /// </summary>
    public const int Finnish = 12;
    /// <summary>
    ///	Language ID 13
    /// </summary>
    public const int Norsk = 13;
    /// <summary>
    ///	Language ID 14
    /// </summary>
    public const int Malay = 14;
    /// <summary>
    ///	Language ID 15
    /// </summary>
    public const int Indonesian = 15;
    /// <summary>
    ///	Language ID 16
    /// </summary>
    public const int Portuguese = 16;
    /// <summary>
    ///	Language ID 17
    /// </summary>
    public const int Italian = 17;
    /// <summary>
    ///	Language ID 18
    /// </summary>
    public const int Dutch = 18;
    /// <summary>
    ///	Language ID 19
    /// </summary>
    public const int Russian = 19;
    /// <summary>
    ///	Language ID 20
    /// </summary>
    public const int Slovakia = 20;
    /// <summary>
    ///	Language ID 21
    /// </summary>
    public const int Cyrillic = 21;
    /// <summary>
    ///	Language ID 22
    /// </summary>
    public const int Estonian = 22;
    /// <summary>
    ///	Language ID 203
    /// </summary>
    public const int CzechRepublic = 203;
    /// <summary>
    /// Language ID 208
    /// </summary>
    public const int French_Canada = 208;
    /// <summary>
    /// Language ID 213
    /// </summary>
    public const int English_UnitedStates = 213;
    /// <summary>
    /// Language ID 214
    /// </summary>
    public const int English_GreatBritain = 214;
    /// <summary>
    /// Language ID 215
    /// </summary>
    public const int English_Canada = 215;
    /// <summary>
    /// Language ID 217
    /// </summary>
    public const int Spanish_UnitedStates = 217;
    /// <summary>
    /// Language ID 218
    /// </summary>
    public const int Spanish_DominicanReplublic = 218;
    /// <summary>
    /// Language ID 219
    /// </summary>
    public const int Spanish_Mexico = 219;
    /// <summary>
    /// Language ID 220
    /// </summary>
    public const int Spanish_Guatemala = 220;
    /// <summary>
    /// Language ID 221
    /// </summary>
    public const int English_Ireland = 221;

    /// <summary>
    /// Language ID 222
    /// </summary>
    public const int Spanish_Colombia = 222;

    /// <summary>
    /// Language ID 223
    /// </summary>
    public const int Spanish_Peru = 223;

    /// <summary>
    /// Language ID 225
    /// </summary>
    public const int Spanish_Spain = 225;

    /// <summary>
    /// Language ID 226
    /// </summary>
    public const int English_Spain = 226;

    /// Language ID 224
    /// </summary>
    public const int Spanish_Canada = 224; // WEB-672

}

public static class CountryCodes
{

    public const string Canada = "CA";
    public const string UnitedStates = "US";
    public const string Ireland = "IE";
    public const string DominicanRepublic = "DO";
    public const string UnitedKingdom = "GB";
    public const string Mexico = "MX";
    public const string Guatemala = "GT";
    public const string Colombia = "CO";
    public const string Peru = "PE";
    public const string Spain = "ES";

    public static readonly IEnumerable<string> All = new List<string> { "AF", "AL", "AY", "DZ", "AS", "AD", "AO", "AI", "AQ", "AG", "AR", "AM", "AW", "AU", "AT", "AZ", "BS", "BH", "BD", "BB", "BY", "BE", "BZ", "BJ", "BM", "BT", "BO", "BA", "BW", "BV", "BR", "IO", "BN", "BG", "BF", "BI", "KH", "CA", "CN", "SV", "IN", "KR", "TW", "TH", "UG", "GB", "US" };
}

public static class Markets
{
    public static string MarketCookieName = "SelectedMarket";

    public static List<Market> AvailableMarkets
    {
        get
        {
            return new List<Market>
                    {
                        new CanadaMarket(),
                        new UnitedStatesMarket(),
                        new MexicoMarket(),
                        new IrelandMarket(),
                        new UnitedKingdomMarket(),
                        new DominicanRepublicMarket(),
                        new GuatemalaMarket(),
                        new ColombiaMarket(),
                        new PeruMarket(),
                        new SpainMarket()
                    };
        }
    }
}

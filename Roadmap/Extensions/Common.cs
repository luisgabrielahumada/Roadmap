using Roadmap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Common
{
    public static IEnumerable<Language> GetLanguages()
    {
        // Get a list of the available markets
        var availableLanguages = new List<Language>();
        var markets = Markets.AvailableMarkets;
        foreach (var market in markets)
        {
            if (market.AvailableLanguages == null) continue;
            foreach (var language in market.AvailableLanguages)
            {
                if (!availableLanguages.Any(c => c.CultureCode == language.CultureCode))
                {
                    language.Country = market.Description;
                    availableLanguages.Add(language);
                }
            }
        }

        // Get a list of the available languages from the avialble markets from above
        return availableLanguages.ToList();
    }
    /// <summary>
    /// Get the selected country code 
    /// </summary>
    /// <returns></returns>
    public static string GetSelectedCountryCode(string countryCode = CountryCodes.UnitedStates)
    {
        var context = HttpContext.Current.Request.RequestContext.HttpContext;
        var countryCookieValue = GetCookie(
            context: context,
            cookieName: "CountryCookieName",
            defaultValue: countryCode);

        var languageCookieValue = GetSelectedLanguage();

        languageCookieValue = languageCookieValue.IsNotNullOrEmpty() ? languageCookieValue.Substring(3, 2) : string.Empty;

        if (countryCookieValue.IsNotNullOrEmpty() && countryCookieValue == languageCookieValue)
        {
            return countryCookieValue;
        }
        else if (languageCookieValue.IsNotNullOrEmpty())
        {
            SetCookie(
                context: context,
                name: "CountryCookieName",
                value: languageCookieValue
                );
            return languageCookieValue;
        }
        else
        {
            SetCookie(
                context: context,
                name: "CountryCookieName",
                value: countryCode
                );
            return countryCode;
        }
    }
    public static string GetCookie(HttpContextBase context, string cookieName, object defaultValue = null, DateTime? defaultExpiration = null, bool? httpOnly = null)
    {
        var cookie = (context.Response.Cookies.AllKeys.Contains(cookieName) ? context.Response.Cookies[cookieName] : null)
            ?? context.Request.Cookies[cookieName]
            ?? GenerateCookie(context, cookieName, defaultValue, defaultExpiration, httpOnly);

        return cookie.Value;
    }
    public static void SetCookie(HttpContextBase context, string name, string value)
    {
        SetCookie(context, name, value, DateTime.Now.AddMonths(1));
    }
    public static void SetCookie(HttpContextBase context, string name, string value, DateTime expiration, bool? httpOnly = null)
    {
        // If the cookie is LastWebAlias ​​the expiration date is changed so that it does not save it
        expiration = DateTime.Now.AddMonths(1);

        var cookie = (context.Response.Cookies.AllKeys.Contains(name) ? context.Response.Cookies[name] : null)
            ?? context.Request.Cookies[name]
            ?? GenerateCookie(context, name, value, expiration, httpOnly);

        cookie.Value = value;
        cookie.Expires = expiration;
        cookie.HttpOnly = true;
        cookie.Secure = !context.Request.IsLocal;

        if (context.Response.Cookies.AllKeys.Contains(name))
        {
            context.Response.Cookies.Remove(name);
        }
        context.Response.Cookies.Add(cookie);
    }
    public static void DeleteCookie(HttpContextBase context, string name)
    {
        DeleteCookie(context.ApplicationInstance.Context, name);
    }
    public static void DeleteCookie(HttpContext context, string name)
    {
        var cookie = context.Request.Cookies[name];

        if (cookie != null)
        {
            cookie.Expires = DateTime.Now.AddDays(-5);
            context.Response.Cookies.Set(cookie);
        }
    }
    private static HttpCookie GenerateCookie(HttpContextBase context, string name, object defaultValue = null, DateTime? expiration = null, bool? httpOnly = null)
    {
        var cookie = new HttpCookie(name);

        cookie.Value = defaultValue == null ? null : defaultValue.ToString();
        if (expiration != null)
        {
            cookie.Expires = (DateTime)expiration;
        }
        cookie.HttpOnly = true; //httpOnly ?? true;

        // all requests that are not localhost should be secure
        cookie.Secure = !context.Request.IsLocal;

        if (context.Response.Cookies.AllKeys.Contains(name))
        {
            context.Response.Cookies.Remove(name);
        }
        context.Response.Cookies.Add(cookie);

        return cookie;
    }
    public static string GetSelectedLanguage(string defaultCultureCode = null)
    {
        // use default market language or specified language if provided
        var defaultLanguage = defaultCultureCode ?? "es-MX";

        

        // get/create the cookie
        var context = HttpContext.Current.Request.RequestContext.HttpContext;
        var cookieValue = GetCookie(
            context: context,
            cookieName: "LanguageCookieName",
            defaultValue: defaultLanguage,
            httpOnly: false);

        // verify language against available languages
        var language = GetLanguages().FirstOrDefault(c => c.CultureCode == cookieValue);
        if (language == null)
        {
            // if language isnt valid. set the first language to the cookie
            language = GetLanguages().FirstOrDefault();
            SetCookie(
                context: context,
                name: "LanguageCookieName",
                value: language.CultureCode);
            cookieValue = language.CultureCode;
        }

        return cookieValue;
    }
    public static int GetSelectedLanguageID(string language = "")
    {
        if (language == "")
        {
            language = GetSelectedLanguage();
        }

        switch (language)
        {
            case CultureCodes.French_Canada:
                return Languages.French_Canada;
            case "es":
            case CultureCodes.Spanish_UnitedStates:
                return Languages.Spanish_UnitedStates;
            case CultureCodes.Spanish_DominicanRepublic:
                return Languages.Spanish_DominicanReplublic;
            case CultureCodes.Spanish_Mexico:
                return Languages.Spanish_Mexico;
            case CultureCodes.Spanish_Guatemala:
                return Languages.Spanish_Guatemala;
            case CultureCodes.Spanish_Colombia:
                return Languages.Spanish_Colombia;
            case CultureCodes.Spanish_Peru:
                return Languages.Spanish_Peru;
            case CultureCodes.Spanish_Spain:
                return Languages.Spanish_Spain;
            case CultureCodes.Spanish_Canada: // WEB-672
                return Languages.Spanish_Canada;
            case "en":
            case CultureCodes.English_UnitedStates:
                return Languages.English_UnitedStates;
            case CultureCodes.English_GreatBritain:
                return Languages.English_GreatBritain;
            case CultureCodes.English_Ireland:
                return Languages.English_Ireland;
            case CultureCodes.English_Canada:
                return Languages.English_Canada;
            case CultureCodes.English_Spain:
                return Languages.English_Spain;
            default:
                return Languages.English_UnitedStates;
        }
    }
    public static Language GetLanguage(int languageID, string countryCode = null)
    {
        var allLanguages = GetLanguages();
        // get the first language that matches the country specific language IDs
        var language = allLanguages.FirstOrDefault(l => l.LanguageID == languageID);

        // legacy support
        if (language == null && (languageID == Languages.English || languageID == Languages.Spanish))
        {
            // get the language for the country/language pair from legacy where languageID was non-country specific
            var languageCode = GetLanguageCode(countryCode, languageID);
            language = allLanguages.FirstOrDefault(l => l.CultureCode == languageCode);
        }

        // fallbacks
        if (language == null)
        {
            // try to get the selected country's language
            language = GetMarket(countryCode)?.AvailableLanguages.FirstOrDefault();
        }
        if (language == null)
        {
            // get the default market's language
            language = GetMarket(null)?.AvailableLanguages.FirstOrDefault();
        }
        return language;
    }
    public static string GetLanguageCode(string countryCode, int languageID)
    {
        switch (countryCode)
        {
            case CountryCodes.UnitedStates:
                if (languageID == Languages.English || languageID == Languages.English_UnitedStates) // check for English(0) for hold over from non-iso languageID logic
                {
                    return CultureCodes.English_UnitedStates;
                }
                else { return CultureCodes.Spanish_UnitedStates; }
            case CountryCodes.Canada:
                if (languageID == Languages.English || languageID == Languages.English_Canada) // check for English(0) for hold over from non-iso languageID logic
                {
                    return CultureCodes.English_Canada;
                }
                else if (languageID == Languages.Spanish || languageID == Languages.Spanish_Canada) // WEB-672
                {
                    return CultureCodes.Spanish_Canada;
                }
                else { return CultureCodes.French_Canada; }
            case CountryCodes.DominicanRepublic:
                return CultureCodes.Spanish_DominicanRepublic;
            case CountryCodes.Mexico:
                return CultureCodes.Spanish_Mexico;
            case CountryCodes.Ireland:
                return CultureCodes.English_Ireland;
            case CountryCodes.UnitedKingdom:
                return CultureCodes.English_GreatBritain;
            case CountryCodes.Guatemala:
                return CultureCodes.Spanish_Guatemala;
            case CountryCodes.Colombia:
                return CultureCodes.Spanish_Colombia;
            case CountryCodes.Peru:
                return CultureCodes.Spanish_Peru;
            case CountryCodes.Spain:
                if (languageID == Languages.Spanish_Spain)
                {
                    return CultureCodes.Spanish_Spain;
                }
                else { return CultureCodes.English_Spain; }
            default:
                return CultureCodes.English_UnitedStates;
        }
    }
    public static string GetCountryCode(string cultureCode)
    {
        switch (cultureCode)
        {
            case CultureCodes.English_Canada:
            case CultureCodes.French_Canada:
            case CultureCodes.Spanish_Canada: // WEB-672
                return CountryCodes.Canada;
            case CultureCodes.English_UnitedStates:
            case CultureCodes.Spanish_UnitedStates:
                return CountryCodes.UnitedStates;
            case CultureCodes.Spanish_Mexico:
                return CountryCodes.Mexico;
            case CultureCodes.English_Ireland:
                return CountryCodes.Ireland;
            case CultureCodes.English_GreatBritain:
                return CountryCodes.UnitedKingdom;
            case CultureCodes.Spanish_DominicanRepublic:
                return CountryCodes.DominicanRepublic;
            case CultureCodes.Spanish_Guatemala:
                return CountryCodes.Guatemala;
            case CultureCodes.Spanish_Colombia:
                return CountryCodes.Colombia;
            case CultureCodes.Spanish_Peru:
                return CountryCodes.Peru;
            case CultureCodes.Spanish_Spain:
                return CountryCodes.Spain;
            case CultureCodes.English_Spain:
                return CountryCodes.Spain;
            default:
                return CountryCodes.UnitedStates;
        }
    }

    public static Market GetMarket(string countryCode)
    {
        return GlobalSettings.Markets.AvailableMarkets.FirstOrDefault(m => m.Countries.Contains(countryCode))
            ?? GlobalSettings.Markets.AvailableMarkets.FirstOrDefault(m => m.IsDefault)
            ?? GlobalSettings.Markets.AvailableMarkets.FirstOrDefault();
    }
}

    

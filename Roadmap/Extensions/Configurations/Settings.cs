using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

    public static class GlobalSettings
    {
        /// <summary>
        /// Exigo-specific API credentials and configurations
        /// </summary>
        public static class Exigo
        {
            public static bool EnviromentIsConfiguredCorrectly = true;
            /// <summary>
            /// Bubbles up a fatal error and reports to designated gatekeepers if failed
            /// </summary>
            public static void VerifyEnvironment(HttpContext context)
            {
//                var debugEnvironments = ConfigurationManager.AppSettings["DebugEnvironments"].Split(',');
//                var environmentGatekeepers = ConfigurationManager.AppSettings["EnvironmentGatekeepers"].Split(';');
//                var releaseMode = ConfigurationManager.AppSettings["ReleaseMode"];
//                var isLocal = context.Request.IsLocal;
//                bool isValidEnv = (releaseMode.ToLower() == "debug" && debugEnvironments.Contains(context.Request.Url.Host.ToLower()))
//                                    ||
//                                  (releaseMode.ToLower() != "debug" && !debugEnvironments.Contains(context.Request.Url.Host.ToLower()));
//                if (!isValidEnv)
//                {
//                    if (EnviromentIsConfiguredCorrectly)
//                    {
//                        Exigo.EnviromentIsConfiguredCorrectly = isValidEnv;
//                        ExigoService.Exigo.SendEmail(new SendEmailRequest
//                        {
//                            To = (isLocal ? new[] { environmentGatekeepers.FirstOrDefault() } : environmentGatekeepers),
//                            From = GlobalSettings.Emails.NoReplyEmail,
//                            ReplyTo = new[] { GlobalSettings.Emails.NoReplyEmail },
//                            SMTPConfiguration = GlobalSettings.Emails.SMTPConfigurations.Default,
//                            Subject = "{0} - Deployment Environment Mismatch".FormatWith(GlobalSettings.Company.Name),
//                            Body = @"
//                    <p>
//                        {1} has had the wrong environment settings deployed to the {0} server.
//                    </p>
//                    <p>
//                        The site is currently dissabled to prevent damage to the {0} database.
//                    </p>
//"
//                                .FormatWith(releaseMode, GlobalSettings.Company.Name)
//                        });
//                    }

//                    throw new Exception("Environment Mismatch: The deployment platform is incorect for this instance {0} as {1}".FormatWith(context.Request.Url.Host.ToLower(), releaseMode.ToLower()));

//                }
            }

            /// <summary>
            /// Web Session Settings
            /// </summary>
            public static class UserSession
            {
                public static string StorageType = "db";
                public static int MinutesToLive = 1440;
                public static bool UseOLTPInMemory = false;
                public static int DbExpireSessionTaskMilliSecDelay = 1800000;
            }

            public static class Caching
            {
                public static bool Enabled = true;
                public static int Lifespan = 300000;
                public static string Schema = "_cache";

                public static class CacheTimeouts
                {
                    /// <summary>
                    /// 5 minutes
                    /// </summary>
                    public const int VeryShort = 5;
                    /// <summary>
                    /// 20 minutes
                    /// </summary>
                    public const int Short = 20;
                    /// <summary>
                    /// 6 hours in minutes
                    /// </summary>
                    public const int Long = 360;
                    /// <summary>
                    /// 1 day in minutes
                    /// </summary>
                    public const int VeryLong = 1440;
                }
            }
        

            /// <summary>
            /// Web service, OData and SQL API credentials and configurations
            /// </summary>
            public static class Api
            {
                public static string LoginName = ConfigurationManager.AppSettings["Api.LoginName"];
                public static string Password = ConfigurationManager.AppSettings["Api.Password"];
                //Errors out without exception and won't authenticate when CompanyKey is incorrect
                public static string CompanyKey = ConfigurationManager.AppSettings["Api.CompanyKey"];

                //PRODUCTION
                public static bool UseSandboxGlobally = bool.Parse(ConfigurationManager.AppSettings["Api.UseSandboxGlobally"]);

                ///USESANDBOX IS TRUE BY DEFAULT SET TO FALSE TO TEST PRODUCTION API
                //public static bool UseSandboxGlobally = false;

                //Configuration Fullstory
                public static string fs_debug = ConfigurationManager.AppSettings["Api.FullStory.Debug"];
                public static string fs_host = ConfigurationManager.AppSettings["Api.FullStory.Host"];
                public static string fs_org = ConfigurationManager.AppSettings["Api.FullStory.Org"];
                public static string fs_namespace = ConfigurationManager.AppSettings["Api.FullStory.Namespace"];


                public static int SandboxID
                {
                    get
                    {
                        if (UseSandboxGlobally)
                        {
                            return int.Parse(ConfigurationManager.AppSettings["Api.SandboxID"]); //Currently set to 2
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }

                public static string ApiExigoEndPoint
                {
                    get
                    {
                      return ConfigurationManager.AppSettings["Api.Exigo.EndPoint"];
                    }
                }

                /// <summary>
                /// Replicated SQL connection strings and configurations
                /// </summary>
                public static class Sql
                {
                    public static class ConnectionStrings
                    {
                        public static string SqlReporting
                        {
                            get
                            {
                                if (UseSandboxGlobally)
                                {
                                    /// <summary>
                                    /// SET BY DEFAULT TO USE SANDBOX
                                    /// </summary>
                                    return ConfigurationManager.ConnectionStrings["Api.Sql.ConnectionStrings.SqlReporting"].ToString();
                                }
                                else
                                {
                                    /// USE THIS TO TEST AGAINST PRODUCTION DATA LOCALLY
                                    return ConfigurationManager.ConnectionStrings["Api.Sql.ConnectionStrings.SqlReporting_production"].ToString();
                                }
                            }
                        }
                        /// <summary>
                        /// SET BY DEFAULT TO USE SANDBOX
                        /// </summary>
                        //public static string SqlReporting = ConfigurationManager.ConnectionStrings["Api.Sql.ConnectionStrings.SqlReporting"].ToString();

                        /// USE THIS TO TEST AGAINST PRODUCTION DATA LOCALLY
                        //public static string SqlReporting = ConfigurationManager.ConnectionStrings["Api.Sql.ConnectionStrings.SqlReporting_production"].ToString();
                    }
                }
            }

            /// <summary>
            /// Payment API credentials
            /// </summary>
            public static class PaymentApi
            {
                public static string LoginName = ConfigurationManager.AppSettings["Api.PaymentApi.LoginName"];
                public static string Password = ConfigurationManager.AppSettings["Api.PaymentApi.Password"];
            }

            /// <summary>
            /// Content Manager Toggle
            /// </summary>
            public static class ContentManager
            {
                public static bool IsEditModeOn = true;
            }
        }

        /// <summary>
        /// Default backoffice settings
        /// </summary>
        public static class Backoffices
        {
            public static string GoogleAnalyticsWebPropertyID = "UA-66364312-5";

            public static int SessionTimeout = 20; // In minutes            
            /// <summary>
            /// This is the customer ID of the Content Manager Administrator and the one that has
            /// access to the resource files
            /// </summary>
            public static int AdministratorID = 1;

            public const int AutoOrderBVTreshold = 400;
            public static string PurchaseRenewalItemCookie = Globalization.CookieKey + "PurchaseRenewalItemCookie";
            public static string RenewalItemCodeCookie = Globalization.CookieKey + "RenewalItemCodeCookie";
            public static string INeedToRenewalNow = Globalization.CookieKey + "INeedToRenewalNow";
            public static string RenewalStatus = Globalization.CookieKey + "RenewalStatus";
            public static string RenewNow = Globalization.CookieKey + "RenewNow";
            public static string ZendeskToken = Globalization.CookieKey + "Zendesk";
            public static string RemindMeLater = Globalization.CookieKey + "RemindMeLater";

            //public static List<int> ValidCustomerTypes
            //{
            //    get
            //    {
            //        return new List<int>
            //        {
            //            CustomerTypes.Consultant
            //        };
            //    }
            //}

            /// <summary>
            /// Silent login URL's and configurations
            /// </summary>
            public static class SilentLogins
            {
                public static string DistributorBackofficeUrl = Company.BaseBackofficeUrl + "/silentlogin/?token={0}";
                public static string RetailCustomerUrl = Company.BaseReplicatedeUrl + "/{0}/account/silentlogin/?token={1}";
            }

            /// <summary>
            /// Waiting room configurations
            /// </summary>
            public static class WaitingRooms
            {
                /// <summary>
                /// The number of days a customer can be placed in a waiting room after their initial enrollment.
                /// </summary>
                public static int GracePeriod = 30;
            }

            public class CompanyNews
            {
                public static int[] Departments
                {
                    get
                    {
                        int[] response = new int[0];
                        // Multiple Departments May be used via comma seperated list of ID #'s. By passing "", all News Items that are set as 'AvailableInBackOffice' will return.
                        string configDepartments = "1,2,3,4,5,6";
                        if (!configDepartments.IsNullOrEmpty())
                        {
                            response = Array.ConvertAll(configDepartments.Split(','), int.Parse);
                        }
                        return response;
                    }
                }
            }

            public static class Reports
            {
                /// <summary>
                /// Parameters for standard reports
                /// </summary>
                public static class Dashboard
                {
                    public static class NewestDistributors
                    {
                        // Hard coded for demo purposes, change to CustomerType lookups when implementing new client.
                        //public static List<int> CustomerTypes = new List<int> { Common.CustomerTypes.Consultant };
                        public static List<int> CustomerStatuses = new List<int> { CustomerStatusTypes.Active };
                        //Setting to 0 will ignore the date filter and grab the top X amount regardless of how old they are
                        public static int Days = 0;
                        // number of days in the past
                        public static int MaxResultSize = 12;
                    }

                    public static class CompanyNews
                    {
                        public static int Department
                        {
                            get
                            {
                                int response = 0;
                                // Multiple Departments May be used via comma seperated list of ID #'s. By passing "", all News Items that are set as 'AvailableInBackOffice' will return.
                                string configDepartments = "";
                                if (!configDepartments.IsNullOrEmpty())
                                {
                                    response = int.Parse(configDepartments);
                                }
                                return response;
                            }
                        }

                    }
                }
                public static class NewestDistributors
                /// <summary>
                /// Newest Distributors Report on the dashboard
                /// </summary>
                {
                    // Hard coded for demo purposes, change to CustomerType lookups when implementing new client.
                    //public static List<int> CustomerTypes = new List<int> { Common.CustomerTypes.Consultant };
                    public static List<int> CustomerStatuses = new List<int> { CustomerStatusTypes.Active };
                    //Setting to 0 will ignore the date filter and grab the top X amount regardless of how old they are
                    public static int Days = 30;
                }

                public static class NewestCustomers
                /// <summary>
                /// WEB-811 Newest Customers Report on the dashboard
                /// </summary>
                {
                    // Hard coded for demo purposes, change to CustomerType lookups when implementing new client.
                    //public static List<int> CustomerTypes = new List<int> { Common.CustomerTypes.Preferred, Common.CustomerTypes.Retail};
                    public static List<int> CustomerStatuses = new List<int> { CustomerStatusTypes.Active };
                    //Setting to 0 will ignore the date filter and grab the top X amount regardless of how old they are
                    public static int Days = 30;
                }

                public static class CommissionReportCacheRefresh
                //kicks off a async endless looping task to update an order in the database and call the rankqual api to ensure the commission report cache doesn't expire.
                //This is really only needed on sites that don't receive traffic for 12+ hours at a time and also haven't received a single order update int that same timeframe (e.g. demo and testing sites)
                {
                    public static bool UseTaskToForceReportCacheRefresh = true;
                    public static int taskWaitTime = 60; //In Minutes
                }
            }

            public static class SodApi
            {
                public static string ApiKey = "3d0352e4595695b4a7b0138484dd5c4f";
                public static string Url = "https://immunotec-sd-success-com.pmp.psft.co/account/login";
                public static string TermoraryEmail = "emailForSod@gmail.com";
            }

            public static class DriveMarketing
            {
                public static string DmToken = "nRtARPdXueBngguAKC29WLeL";
                public static string Url = "https://shop.immunotec.com/rest/default/V1/dm-sso";
                public static string UrlTest = "http://kyle-immunotec.drivemarketing.com/rest/default/V1/dm-sso";
            }

            public static class Zendesk
            {
                public static string ClientIdTest = "immunotec";
                public static string UrlTest = "https://immunotec1580229218.zendesk.com";
                public static string SecrectTest = "c8c4af1297ff976f923bfb637a518f2507582a57dc6e781985319a521a9f18d4";
                public static string EmailTest = "lina.castaneda@tailorsoft.co";
                public static string SHARED_KEYTest = "OFqEyJ4QGpThFoFBqlFYvOMzV3hGNx8xSEWMwKCwTfbUUb06";

                public static string ClientId = "immunotec";
                public static string Url = "https://immunotec.zendesk.com";
                public static string Secrect = "ce1d1b1c437c50ef2c5ac7f60258d07e00729409d15bb1985e7033111ee28405";
                public static string Email = "lina.castaneda@tailorsoft.co";
                public static string SHARED_KEY = "uOXlD1FRWx80neIy37GMGrQCUnnOSlT8IjRiOFGiHoCe0uCM";

            }
        }

        /// <summary>
        /// Default replicated site settings
        /// </summary>
        public static class ReplicatedSites
        {
            public static int SessionTimeout = 20;
            public static string DefaultWebAlias = "corporphan";
            public static int DefaultAccountID = 2;
            public static int IdentityRefreshInterval = 15; // In minutes
            public static string FormattedBaseUrl = Company.BaseReplicatedeUrl + "/{0}";
            public static string GoogleAnalyticsWebPropertyID = "UA-66364312-6";
            public static string UrlBlog = "http://blogtest.immunotec.com";
            public static string EnrollmentOperation = "UpgradetoConsultant";

            public static string GetFormattedUrl(string webAlias)
            {
                return FormattedBaseUrl.FormatWith(webAlias);
            }
            public static string EnrollmentUrl = FormattedBaseUrl +  "/enrollment";
            public static string GetEnrollmentUrl(object webAlias)
            {
                return string.Format(EnrollmentUrl, webAlias);
            }

            /// <summary>
            /// Comma seperated Web Category IDs
            /// </summary>
            public static string DefaultHomePageProducts = "";
            public static string TopXHomePageProducts = "5";
            public static string HomePageProductsWebCat = "63";

            public static string JsonIp = "https://jsonip.com?callback=?";
            public static string GeoHost = "https://tools.keycdn.com/geo.json?host=";
        }

        /// <summary>
        /// Default items settings
        /// </summary>
        public static class Items
        {
            public static int WebID = 1;
        }

        /// <summary>
        /// Market configurations used for orders, autoOrders, products and more
        /// </summary>
        public static class Markets
        {
            public static string MarketCookieName = Globalization.CookieKey + "SelectedMarket";            

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

        /// <summary>
        /// Language and culture code configurations
        /// </summary>
        public static class Globalization
        {
            public static string CookieKey = "Immunotec";
            public static string CountryCookieName = CookieKey + "SelectedCountry";
            public static string CountryCookieChosenName = CookieKey + "CountryChosen";
            public static string SiteCultureCookieName = CookieKey + "SiteCulture";
            public static string LanguageCookieName = CookieKey + "SelectedLanguage";
            public static string LogInAlertCookieName = CookieKey + "LogInAlert";
            public static string LastWebAliasCookieName = CookieKey + "LastWebAlias";
            public static string SetAccessActive = CookieKey + "SetAccess";
            public static string SetCreateConsultant = CookieKey + "SetCreateConsultant";
            public static string SetTestCalculateOrder = CookieKey + "SetTestCalculateOrder";
            public static string YourIPAddress = CookieKey + "YourIPAddress";
            public static string EventID = CookieKey + "EventID";
            public static string IsConsultant = CookieKey + "IsConsultant";
            public static string InMaintenance = CookieKey + "InMaintenance";
            public static string ThreatMetrixSessionId = CookieKey + "ThreatMetrixSessionId"; // WEB-692
            public static string ThreatMetrixAvoidRedirect = CookieKey + "ThreatMetrixAvoidRedirect"; // WEB-692

            public static string InPersonalConsumption = "2";
            public static string OutPersonalConsumption = "1";
            public static string[] BackList =new string[] { ".js", ".php" , ".png" , ".xml", ".jpg", ".woff2", ".gif", ".wcp" };

            public static string ExpirationStartDatePickUp = CookieKey + "ExpirationStartDatePick";
            public static string ExpirationEndDatePickUp = CookieKey + "ExpirationEndDatePick";
        }

        public static class DateFormats
        {
            public static string USDateFormat = "MMMM d, yyyy";
            public static string CADateFormat = "MMMM d, yyyy";
            public static string MXDateFormat = "MMMM d, yyyy";
            public static string DODateFormat = "MMMM d, yyyy";
            public static string GBDateFormat = "MMMM d, yyyy";
            public static string IEDateFormat = "MMMM d, yyyy";
        }

        /// <summary>
        /// Language and culture code configurations
        /// </summary>
        public static class AutoOrders
        {
            /// <summary>
            /// Auto orders only allowed between 4th and 22nd (inclusive) of each month
            /// </summary>public static List<int> AvailableAutoOrderDays
            public static List<int> AvailableAutoOrderDays
            {
                get
                {
                    return Enumerable.Range(4, 19).ToList();
                }
            }
            //public static List<int> AvailableFrequencyTypeIDs
            //{
            //    get
            //    {
            //        return new List<int>
            //        {
            //            FrequencyTypes.Monthly
            //        };
            //    }
            //}
            //public static List<FrequencyType> AvailableFrequencyTypes = AvailableFrequencyTypeIDs.Select(c => ExigoService.Exigo.GetFrequencyType(c)).ToList();
        }

        /// <summary>
        /// Customer avatar configurations
        /// </summary>
        public static class Avatars
        {
            public static string DefaultAvatarAsBase64 = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAgGBgcGBQgHBwcJCQgKDBQNDAsLDBkSEw8UHRofHh0aHBwgJC4nICIsIxwcKDcpLDAxNDQ0Hyc5PTgyPC4zNDL/2wBDAQkJCQwLDBgNDRgyIRwhMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjIyMjL/wAARCAEsASwDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD0WiiigAooooAKKKKACiiigBO1LRRQAneloooAKKKKAEpaKKACiiigApO1LRQAUUUUAFFFFABRRRQAUUUUAJ3paKKACiiigAoopO1AC0UUUAFFFFABRSd6WgAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAopKWgBOKWiigAooooAKKTvS0AJS0UUAFJS0UAFFFFABRRRQAUnelooAKKKKACiiigApO9LRQAnaloooAKKKKACiiigBKKWigAopO9LQAUlLRQAUUUUAFJS0UAJS0UUAFFFFACUtFFABSUtFABSUtJQAtFFFABRRRQAUUUUAFFFFABRRRQAUUUnegBaKKKACinRxvK4SNSzHsK17bQJGwbiTYP7q8mgDGpyo7/AHULfQV1cOl2cH3YQx9W5q4FVRhQB9KAOMFpdHpbSn/gBprW06fehkH1Q121FAHCkYNFdrJbwyjEkSN9VrPn0O1lyY90Te3IoA5qir11pVzaguV3oP4lqjQAUUneloAKKKKACiiigAooooAKKKKACiiigAooooAKKTvS0AFFFFABRRRQAUnalooAKKKKACiiigAq9YaZJetuOUiHVvX6U/S9NN3J5knEKn/vr2rp1VUUKoAUcADtQBFbWkNomyFMep7mp6KKACiiigAooooAKKKKACsq/wBHiuQXhAjl/Rq1aKAOIlieCQxyKVYdQaZXXX9hHfRYPEgHyt6Vyk0TwStHIuGWgBlFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFACd6WiigAooooAKKKKACk5paKACrFlaNeXKxDherH0FV66jRrUW9mJCP3kvzH6dqAL8USQxLGgwqjAFPoooAKKKKACikpaACiiigAooooAKKKKACszV7D7TD5qD96g7fxD0rTooA4Wir+r2gtbzKDCSfMPaqFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQBPZQ/abyOLszc/SuyAwMDpXO+H4g11JIf4VwPxro6ACiiigAooooAKKO1HagAooooAO9HakpaACiiigAooooAzdat/OsGcfejO4f1rl67eRBJE6HoykGuJZdrFT1BwaAEooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoopO1AHQ+Hl/cTN6uBW1WP4e/49JR/00/pWxQAUUUUAFFFJ3oAWiiigAooooAKKKKACiiigAooooAK4y+XbfTr/tmuzrjtROdRuP8AfNAFaiiigAooooAKKKKACiiigAooooAKKKKACkpaKACiiigAooooAKKKKAN3w6/+vj+jVu1y2izeVqKqTxICtdTQAUUUUAFFJS0AFFFFABRRRQAUUUUAFFFFABRRRQAVxVw/mXMr/wB5yf1rrL6b7PZTSdwpx9a46gAooooAKKKKACiiigAooooAKKKKAE70tFFABRRRQAUUUnegBaKKKACik7UtACo5jkV14ZTkV2dvMLi3SVejDNcXW1oV7tc2rn5W5T60AdBRRRQAUUdqKACikpaACiiigAooooAO1FFFABRRUU0yQQtK5wqjJoAyNfucLHbA9fmb+lYNS3E73M7zP95j+VRUAFJ2paTvQAtFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFKrFWDA4I5BpKKAOq0zUFvIcMcTL94evvWhXEQzPBKssbbWXvXT6fqUV6m0kLMOq+v0oA0KKKKACiiigAooooAKKKKACiimswRSzEBR1JoAUkAZNczq+ofapPJiP7lD1/vGpNU1bz8wW5Ij6M396sigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACk70tFABRRRQAUUUnegBaKKKAClVmRgykhh0Iq5Z6XcXnzAbI/7zD+Vb1ppVta4bb5kn95qAINMvLudQs0DFe0vStaiigAopKWgAooooAKKKKAGSu0cZZELkdFB61y+o311cSFJlaJR/BjFdXUUsEc6bZUDr7igDiqK3bvQOr2r/APAG/wAaxZI3hcpIhVh2IoAZRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUVJBBJcSrHEu5jQAxEeRwiKWY8ACugsNFSLElzh36hewq3YadHZJnhpT95sfyq9QAgAAwKWiigAooooAKKSloAKKKKACiiigAooo7UAFV7mzhu02ypn0PcVYooA5K+02WybP34j0cD+dUq7hlV1KsAVPUGuc1PSTbZmgBMXcf3aAMqiiigAooooAKKKKACiiigAooooAKKKTtQAtFFFABRSUtABRRRgmgB8UTzSrHGu5m4ArqtPsUsYcDmRvvNUOk6eLWLzZB++f8A8dHpWnQAUUUd6ACjtRRQAUlFLQAUUUUAFFFFABRRRQAUUUUAFFFFABSEAjB6UtFAHNarpn2ZjNEP3THkf3ayq7h0WRCrgMp4INcnqNi1lcYHMbcqf6UAU6KKKACiiigAooooAKKKKACiik7UALRRRQAlFLRQAVr6LY+dL9okHyIflHqazLeB7idIU+8xxXY28K28CRIAFUYoAlooooAKKKKACiiigAooooAKO1FFABRRRQAUUUUAFFFFABRRRQAUUUUAFVr21S8tmibg9VPoas0UAcPJG0UjRuMMpwRTa3des+l0g9n/AKGsKgAooooAKKKKACiiigAooooAKKKKACiiljRpJFRclmOBQBu6BagK10w5Pyp/WtyoreFbeBIl6KMVLQAUUUUAFFFHagApKWigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKAGSxrNE0bjKsMGuMuImt7h4m6qcV21c/4gttskdwo4b5W+tAGLRRRQAUUUUAFFFFACd6WiigAopKWgArT0O382+8wj5Yxu/HtWZXSaDDssmkPWRv0FAGtRR2ooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAqpqMH2mxlTGTjK/UVbooA4Wip72HyL2aPsG4+lQUAFFFFABRRRQAUUUUAFFFFABXZWUfk2UMfogz9a5GBPMuI0/vOBXa0ALRRRQAUlLRQAUUUUAFFFFABRRSUAHeloooAKKKKACiiigAo7UUUAFFFFABR2oooAKKKKACiiigDmtfjC3qPj76frWVXQeIY8wQyf3WxXP0AFFFFABRRRQAUUUUAFFJ2ooAuaWu/U4B/tZ/KuvrldF51SP2B/lXVUAFHaiigA70UlLQAUUd6O9ABRRRQAlLRR3oAKKKKACiiigAooooAKKKKACiiigAoo70UAFFFFABRRR3oAzdcXdpjn+6wNcvXW6tzpc/0H865KgAooooAKKTvS0Af//Z";
        }

        /// <summary>
        /// Error logging configuration
        /// </summary>
        public static class ErrorLogging
        {
            public static bool ErrorLoggingEnabled = true;
            public static string[] EmailRecipients = new List<string> {"lgac73230463@gmail.com"}.ToArray();
        }

        /// <summary>
        /// Email configurations
        /// </summary>
        public static class Emails
        {
            public static string NoReplyEmail = "noreply@exigonow.com";
            public static string ContactUsEmail = "noreply@exigonow.com";
            public static string VerifyEmailUrl = Company.BaseBackofficeUrl + "/verifyemail";

            // NEED NEW CREDS FROM CLIENT IF THEY ARE TO SEND ANY EMAILS FROM THE WEB
            public static class SMTPConfigurations
            {
                public static SMTPConfiguration Default = new SMTPConfiguration
                {
                    Server = "smtp.sendgrid.net",
                    Port = 25,
                    Username = "Immunotec",
                    Password = "SG987889*$",
                    EnableSSL = false
                };

                public static SMTPConfiguration Gmail = new SMTPConfiguration
                {
                    Server = "smtp.gmail.com",
                    Port = 25,
                    Username = "luisgabrielahumada@gmail.com",
                    Password = "lG73230463",
                    EnableSSL = true
                };

                
            }
            public static class Defaults
            {
                public static string[] To = new string[] { "noreply@exigonow.com" };
                public static string[] ReplyTo = new string[] { "noreply@exigonow.com" };
                public static string Subject = "Subject";
                public static string Body = "Body";
                public static string From = "noreply@exigonow.com";
                public static bool IsHtml = true;
                public static System.Net.Mail.MailPriority Priority = System.Net.Mail.MailPriority.Normal;
                public static bool UseExigoApi = true;
            }
        }

        /// <summary>
        /// Company information
        /// </summary>
        public static class Company
        {
            public static int[] CorporateCalendarAccountID = { 1, 44025, 1092985, 044059 };
            public static string Name = "Immunotec";
            public static string RNC = "1-31-289541";
            //public static Address Address = new Address()
            //{
            //    Address1 = "300 Rue Joseph-Carrier",
            //    Address2 = "",
            //    City = "Vaudreuil-Dorion",
            //    State = "QC",
            //    Zip = "J7V 5V5",
            //    Country = "CA"
            //};
            public static string Phone = "+1 832-915-3603";
            public static string Email = "info@immunotec.com";
            //public static string Facebook = "http://www.facebook.com/";
            //public static string Twitter = "http://twitter.com/";
            //public static string YouTube = "http://youtube.com/";
            //public static string Blog = "http://blogger.net/blog/";
            //public static string Pinterest = "http://www.pinterest.com";
            //public static string Instagram = "http://www.instagram.com";
            public static string DefaultCompanyMessage = "This is our company statement.";


            public static string BaseBackofficeUrl = ConfigurationManager.AppSettings["Company.BaseBackofficeUrl"];
            public static string BaseReplicatedeUrl = ConfigurationManager.AppSettings["Company.BaseReplicatedeUrl"];
        }

        /// <summary>
        /// EncryptionKeys used for silent logins and other AES encryptions
        /// </summary>
        public static class EncryptionKeys
        {
            public static string General = "SDCLKJYAFS654ASF321FP87K"; // 24 characters 

            public static class SilentLogins
            {
                public static string Key = GlobalSettings.Exigo.Api.CompanyKey + "silentlogin";
                public static string IV = "kjJ6F6sf84vfV432"; // Must be 16 characters long
            }
        }

        public static class RegularExpressions
        {
            public const string NoSpecialCharacters = @"^[^~`^<>!@#$%&*()=/{}\[\]?+|\\;:_0-9]+$";
            public const string EmailAddresses = @"^[^@]+@[^@]+\.[^@]+$";  // Has only one @ symbol, at least one character before the @, at least one character between the @ and the period, and at least one character after the period
            public const string LoginName = "^[a-zA-Z0-9]{3,}$";
            public const string Password = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{10,128}$";
            public const string PhoneNumber = @"^\d{15}$";
            public const string PhoneNumberUK = @"^\d{15}$";
            public const string PhoneNumberGT = @"^\d{15}$";
            public const string PhoneNumberCO = @"^[(]{3}[0-9]{1}[)]{1}[0-9]{10}$";
            public const string MobilePhoneCO = @"^[57-]{3}[0-9]{10}$";


            public const string BankAccountNumber = @"^\d{1,15}$";
            public const string BankAccountNumberPE = @"^\d{20}$";
            public const string BankRoutingNumber = @"^\d{9}$";
            public const string BankRoutingNumberGuatemala = @"^\d{3}$";
            public const string BankRoutingNumberCO_PE = @"^\d{1,2}$";
            public const string CVV = @"\d{3,4}$";

            // City expression
            public const string GTNoSpecialCharactersCity = @"^[^~`^<>!@#$%&*=/{}\[\]?+|\\;:_]+$";

            // TaxID expressions by country           
            public const string UnitedStatesTaxID = @"^(?!(000|666))\d{3}-(?!00)\d{2}-(?!0000)\d{4}$";
            public const string CanadaTaxID = @"^\d{3}-?\d{3}-?\d{3}$";
            public const string MexicoTaxID = @"^[a-zA-Z]{4}\d{6}[a-zA-Z\d]{3}$";
            public const string DominicanRepublicTaxID = @"^\d{11}";
            public const string GuatemalaTaxID = @"^\d{13}";
            public const string GuatemalaNITID = @"^[\d]{7}[-]{1}[\S]{1}$";
            public const string JS_GuatemalaNITID = @"^[\\d]{7}[-]{1}[\\S]{1}$";
            public const string ColombiaTaxID = @"^\d{13}";

            // Address
            // CW 2018/05/02 #103995 - Address 1, 2, and 3 cannot be more than 40 characters
            public const string AddressLine = @"^.{0,40}$";
            public const string AddressLineMX = @"^.{0,35}$";
            public const string City = @"^.{1,15}$";
            public const string Zip = @"^([^~`^<>!@#$%&*()=/{}\[\]?+|\\;:_]{4,15})$";
            public const string ZipPeru = @"^([^~`^<>!@#$%&*()=/{}\[\]?+|\\;:_]{1,3})$";
            public const string Email = "^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$";

            public const string CurpID = @"^([A-Z]{4})(\d{2}(0?[1-9]|1[1-2])(3[01]|[12][0-9]|0?[1-9]))[A-Z]{2}[A-Z0-9]{6}$";
        }

        /// <summary>
        /// Debug Module Configuration
        /// </summary>
        public static class Debug
        {
            //JS, 09/15/2015
            //Added Cookie Name for Debug Parameters
            public static string DebugCookieName = "exigolite_DebugMode";
        }

        /// <summary>
        /// A Collection of API Keys for Google Services
        /// </summary>
        public static class Google
        {
            /// <summary>
            /// The Google Maps API Key for the Client
            /// </summary>
            public static string Maps = "AIzaSyBzS3gskQJO-01JoBg8TOpr1aTvyKIK-6Y";
        }

        public static class HyperWallet
        {
            public const string Url = "https://immunotec.hyperwallet.com/";

            public const bool Mode = true;
            public const string UrlPayTest = "https://uat-api.paylution.com/rest/v3";           
            public const string UserTest = "restapiuser@9684151682";
            public const string PasswordTest = "4JDTVQGngZ5jLF2u_31";

            public const string UrlPay = "https://api.paylution.com/rest/v3/";
            public const string User = "restapiuser@116601421682";
            public const string Password = "VC2vdd6n3k9Va28e";
        }

        /// WEB-810 - Use to reference the URL related to Conventions
        public static class Convetions
        {
            public const string Beyond2020Url = "http://beyond.immunotec.com/";
        }

        public static class PayU
        {
            public static string PayuUrl = "https://api.paymentsos.com";
            public static string Version = "1.1.0";
            public static string EndPointBank = "https://api.payulatam.com/payments-api/4.0/service.cgi";
            public static string EndPointBankTest = " https://sandbox.api.payulatam.com/payments-api/4.0/service.cgi";
        }

        public static class Aventri
        {
            public static string Url = "https://www.eiseverywhere.com/api/v2";
            public static string NewRegUrl = "https://www.eiseverywhere.com/ereg/newreg.php";

            public static string AccountIdTest = "9216";
            public static string KeyTest = "a2862e1647f4021738816c5a5a82a22946cad3c5";

            public static string AccountId = "9216";
            public static string Key = "a2862e1647f4021738816c5a5a82a22946cad3c5";
        }

        public static class Dates
        {
            public static DateTime RequirePasswordChangeDate = new DateTime(2019, 04, 08, 0, 0, 0, DateTimeKind.Utc);
        }

        // WEB-692
        public static class ThreatMetrix
        {

            private static string UrlTemplate = "{0}?org_id={1}&session_id={2}";
            public static string TagsUrl = ConfigurationManager.AppSettings["Api.ThreatMetrix.Tags.Url"];
            public static string ApiKey = ConfigurationManager.AppSettings["Api.ThreatMetrix.Key"];
            public static string OrgId = ConfigurationManager.AppSettings["Api.ThreatMetrix.Org.Id"];
            public static string ApiUrl = ConfigurationManager.AppSettings["Api.ThreatMetrix.Session.Query.Url"];

            public static bool IsActive
            {
                get
                {

                    bool success = Boolean.TryParse(ConfigurationManager.AppSettings["Api.ThreatMetrix.Active"], out bool active);

                    return (success) ? active : false;
                }
            }

            public static string GetThreatMetrixUrl(bool IsThreatMetrix, string SessionId, string sufix = "")
            {

                string scrString = String.Empty;

                if (IsThreatMetrix)
                {
                    var OrgId = GlobalSettings.ThreatMetrix.OrgId;
                    var TagsUrl = GlobalSettings.ThreatMetrix.TagsUrl;

                    if (OrgId.IsNotNullOrEmpty() && SessionId.IsNotNullOrEmpty() && TagsUrl.IsNotNullOrEmpty())
                    {
                        scrString = UrlTemplate.Replace("{0}", TagsUrl + sufix).Replace("{1}", OrgId).Replace("{2}", SessionId);
                    }

                }

                return scrString;
            }

        }
    }

    public enum MarketName
    {
        UnitedStates,
        Canada,
        DominicanRepublic,
        Guatemala,
        UnitedKingdom,
        Ireland,
        Mexico,
        Colombia,
        Peru,
        Spain
    }
    public enum AvatarType
    {
        Tiny,
        Small,
        Default,
        Large
    }
    public enum SocialNetworks
    {
        Facebook = 1,
        GooglePlus = 2,
        Twitter = 3,
        Blog = 4,
        LinkedIn = 5,
        MySpace = 6,
        YouTube = 7,
        Pinterest = 8,
        Instagram = 9
    }

    public enum TreeTypes
    {
        Enroller = 1,
        Unilevel = 2
    }

    public enum LogTypes
    {
        RedirectPaymentMethodOne = 1
    }

    public enum EnrollmentPackTypes
    {
        Basic,
        Advanced,
        Premium
    }

    public enum OtherPayment
    {
        PayWithCash,
        PayWithBank,
        PayWithBankTransfer,
        PayWithHyperWallet
    }

    public static class CustomerStatusTypes
    {
        public const int Active = 1;
        public const int Terminated = 2;
        public const int Inactive = 3;

    }

    public static class ApiWarnings
    {
        public const string SpecialShippingArea = "Shipping on this order will be charged at 20% surplus.";
    }

    // WEB-692
    public static class MetrixParametersEmun
    {
        public const string

            // Mandatory parameters
            OrgId = "org_id",
            ApiKey = "api_key",
            SessionId = "session_id",
            ServiceType = "service_type",
            EventType = "event_type",
            Policy = "policy",
            Action = "action",
            RequestId = "request_id",

            // Recommended parameters
            AccountEmail = "account_email",
            AccountFirstName = "account_first_name",
            AccountLastName = "account_last_name",
            AccountDateOfBirth = "account_date_of_birth",
            CustomerEventType = "customer_event_type",
            TransactionId = "transaction_id",
            CcNumberHash = "cc_number_hash",
            OnlineTld = "online_tld",
            OnlineTld_handle = "online_tld_handle",
            AchAccountHash = "ach_account_hash",
            DriversLicenseNumberHash = "drivers_license_number_hash",
            SsnHash = "ssn_hash",
            LineOfBusiness = "line_of_business",
            ApplicationName = "application_name",
            NationalIdNumber = "national_id_number",
            NationalIdType = "national_id_type",

            // Optional parameters
            AccountTelephoneCountryCode = "account_telephone_country_code",
            AccountLogin = "account_login",
            AccountNumber = "account_number",
            AccountTelephone = "account_telephone",
            AccountAddressStreet1 = "account_address_street1",
            AccountAddressStreet2 = "account_address_street2",
            AccountAddressCity = "account_address_city",
            AccountAddressState = "account_address_state",
            AccountAddressCountry = "account_address_country",
            AccountAddressZip = "account_address_zip",
            ShippingAddressStreet1 = "shipping_address_street1",
            ShippingAddressStreet2 = "shipping_address_street2",
            ShippingAddressCity = "shipping_address_city",
            ShippingAddressState = "shipping_address_state",
            ShippingAddressCountry = "shipping_address_country",
            ShippingAddressZip = "shipping_address_zip",
            AchRoutingNumber = "ach_routing_number",
            LocalAttrib1 = "local_attrib_1",
            LocalAttrib2 = "local_attrib_2",
            LocalAttrib3 = "local_attrib_3",
            LocalAttrib4 = "local_attrib_4",
            LocalAttrib5 = "local_attrib_5",
            LocalAttrib6 = "local_attrib_6",
            LocalAttrib7 = "local_attrib_7",
            LocalAttrib8 = "local_attrib_8",
            LocalAttrib9 = "local_attrib_9",
            LocalAttrib10 = "local_attrib_10",
            LocalAttrib11 = "local_attrib_11",
            LocalAttrib12 = "local_attrib_12",
            LocalAttrib13 = "local_attrib_13",
            LocalAttrib14 = "local_attrib_14",
            LocalAttrib15 = "local_attrib_15",
            InputIpAddress = "input_ip_address",
            ApiVersion = "api_version",

            // Transaction Amount  Inputs
            TransactionAmount = "transaction_amount",
            TransactionCurrency = "transaction_currency",
            OuputFormat = "output_format";

    }

    public  static class Parameters
    {
        public static DateTime StartDatePickUp = new DateTime(2019,12,3);

        public static DateTime EndDatePickUp = new DateTime(2020,1,9,15,0,0);
    }

[assembly: Xamarin.Forms.Dependency(typeof(MyLeasing.iOS.Implementation.Localize))]
namespace MyLeasing.iOS.Implementation
{
    using Foundation;
    using MyLeasing.Helpers;
    using MyLeasing.Interfaces;
    using System.Globalization;
    using System.Threading;

    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguaje = "en";

            if (NSLocale.PreferredLanguages.Length > 0) netLanguaje = iOSToDotnetLanguage(NSLocale.PreferredLanguages[0]);
            CultureInfo cultureInfo;
            try { cultureInfo = new CultureInfo(netLanguaje); }
            catch(CultureNotFoundException)
            {
                try
                {
                    var fallback = ToDotnetFallBackLanguage(new PlatformCulture(netLanguaje));
                    cultureInfo = new CultureInfo(fallback);
                }
                catch (System.Exception)
                {
                    cultureInfo = new CultureInfo("en");
                }
            }

            return cultureInfo;
        }

        private string ToDotnetFallBackLanguage(PlatformCulture platformCulture)
        {
            var netLanguge = platformCulture.LanguageCode;
            switch (platformCulture.LanguageCode)
            {
                case "pt":
                    netLanguge = "pt-PT";
                    break;
                case "gsw":
                    netLanguge = "de-CH";
                    break;
            }
            return netLanguge;
        }

        private string iOSToDotnetLanguage(string iOSLanguage)
        {
            var netLanguage = iOSLanguage;
            switch (iOSLanguage)
            {
                case "ms-MY": //Malaysia(Malaysia)
                case "ms-SG": //Malaysia(Singapur)
                    netLanguage = "ms";
                    break;
                case "gsw-CH": // (Swiss German)
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }

        public void SetLocalize(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
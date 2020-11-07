[assembly: Xamarin.Forms.Dependency(typeof(MyLeasing.Droid.Implementation.Localize))]
namespace MyLeasing.Droid.Implementation
{
    using MyLeasing.Helpers;
    using MyLeasing.Interfaces;
    using System;
    using System.Globalization;
    using System.Threading;

    public class Localize : ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            string netLanguage = AndroidToDotnetLanguage(Java.Util.Locale.Default.ToString().Replace("_", "-"));
            CultureInfo cultureInfo;
            try { cultureInfo = new CultureInfo(netLanguage); }
            catch (CultureNotFoundException)
            {
                try
                {
                    var fallBack = ToDotnetFallBackLanguage(new PlatformCulture(netLanguage));
                    cultureInfo = new CultureInfo(fallBack);
                }
                catch (Exception)
                {
                    cultureInfo = new CultureInfo("en");
                }
            }
            return cultureInfo;
        }

        private string AndroidToDotnetLanguage(string androidLanguage)
        {
            var netLanguage = androidLanguage;

            switch (androidLanguage)
            {
                case "ms-BN":
                case "ms-MY":
                case "ms-SG":
                    netLanguage = "ms";
                    break;
                case "gsw-CH":
                    netLanguage = "de-CH";
                    break;
            }
            return netLanguage;
        }

        private string ToDotnetFallBackLanguage(PlatformCulture platformCulture)
        {
            var netLanguage = platformCulture.LanguageCode;
            switch (platformCulture.LanguageCode)
            {
                case "gsw":
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
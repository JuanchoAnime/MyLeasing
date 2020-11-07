namespace MyLeasing.Helpers
{
    using System;

    public class PlatformCulture
    {
        public string PlatformString { get; set; }

        public string LanguageCode { get; set; }

        public string LocalCode { get; set; }

        public PlatformCulture(string platformCultureString)
        {
            if (string.IsNullOrEmpty(platformCultureString))
                throw new ArgumentException("Expected Culture Identifier", "platformCultureString");

            PlatformString = platformCultureString.Replace("_", "-");
            if (PlatformString.IndexOf("-", StringComparison.Ordinal) > 0) 
            {
                var parts = PlatformString.Split('-');
                LanguageCode = parts[0];
                LocalCode = parts[1];
            }
            else 
            {
                LanguageCode = PlatformString;
                LocalCode = string.Empty;
            }
        }

        public override string ToString() => PlatformString;
    }
}

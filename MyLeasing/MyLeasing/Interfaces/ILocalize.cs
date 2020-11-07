namespace MyLeasing.Interfaces
{
    using System.Globalization;

    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();

        void SetLocalize(CultureInfo cultureInfo);
    }
}

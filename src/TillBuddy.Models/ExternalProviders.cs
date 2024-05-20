namespace TillBuddy.Models;

public static class ExternalProviders
{
    public const string TillBuddy = "TillBuddy";
    public const string Omnium = "Omnium";
    public const string WinSilver = "WinSilver";
    public const string GCC = "GCC";
    public const string Shopify = "Shopify";
    public const string None = "None";

    public static List<string> All
    {
        get
        {
            return new List<string>() { TillBuddy, Omnium, GCC, WinSilver, None };
        }
    }
}

namespace TillBuddy.Models;

public static class ExternalProviders
{
    public const string TillBuddy = "TillBuddy";
    public const string Omnium = "Omnium";
    public const string WinSilver = "WinSilver";
    public const string Shopify = "Shopify";
    public const string Tripletex = "Tripletex";
    public const string None = "None";

    public static List<string> All
    {
        get
        {
            return [TillBuddy, Omnium, WinSilver, Shopify, Tripletex, None];
        }
    }
}

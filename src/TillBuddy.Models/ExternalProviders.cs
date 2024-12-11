namespace TillBuddy.Models;

public static class ExternalProviders
{
    public const string TillBuddy = "TillBuddy";
    public const string Omnium = "Omnium";
    public const string Shopify = "Shopify";
    public const string Tripletex = "Tripletex";
    public const string Diller = "Diller";
    public const string None = "None";

    public static List<string> All
    {
        get
        {
            return [TillBuddy, Omnium, Shopify, Tripletex, Diller, None];
        }
    }
}

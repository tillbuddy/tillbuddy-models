namespace TillBuddy.Models;
public interface ICampaignDiscount
{
    public string GroupId { get; set; }
    public IMoney? Discount { get; set; }
    public IMoney? DiscountShare { get; set; }
    public bool IsVisible { get; set; }
    public ICampaignInfo? CampaignInfo { get; set; }
}

public class CampaignDiscount : ICampaignDiscount
{
    public string GroupId { get; set; } = null!;
    public IMoney? Discount { get; set; }
    public IMoney? DiscountShare { get; set; }
    public bool IsVisible { get; set; }
    public ICampaignInfo? CampaignInfo { get; set; }
}

public class CampaignDiscountRequest : CampaignDiscount
{
}


public class CampaignDiscountResponse : CampaignDiscount
{
}
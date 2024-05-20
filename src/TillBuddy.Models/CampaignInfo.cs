namespace TillBuddy.Models;

public interface ICampaignInfo
{
    public string Name { get; set; }
    public string CampaignId { get; set; }
}

public class CampaignInfo : ICampaignInfo
{
    public string Name { get; set; } = null!;
    public string CampaignId { get; set; } = null!;
}

public class CampaignInfoRequest: CampaignInfo
{
}


public class CampaignInfoResponse : CampaignInfo
{
}

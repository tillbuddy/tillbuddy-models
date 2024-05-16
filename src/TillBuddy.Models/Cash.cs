namespace TillBuddy.Models
{
    public interface ICash
    {
        public string UserId { get; set; }
        public string Amount { get; set; }
        public DateTime RegisteredAt { get; set; }

    }

    public class CashRequest : ICash
    {
        public string UserId { get; set; } = null!;
        public string Amount { get; set; } = null!;
        public DateTime RegisteredAt { get; set; }
    }
}

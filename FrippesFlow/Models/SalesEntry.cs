namespace FrippesFlow.Models
{
    public class SalesEntry
    {
        public int Id { get; set; }
        public DateTime Week { get; set; }
        public int AmountSold { get; set; }
        public double PricePer { get; set; }
    }
}
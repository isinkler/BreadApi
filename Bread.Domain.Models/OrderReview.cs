namespace Bread.Domain.Models
{
    public class OrderReview
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public int OrderId { get; set; }
        
        public Order Order { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class OrderReview
    {
        public int Id { get; set; }

        public int Score { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public int PaymentType { get; set; }
        
        public double Price { get; set; }

        public int UserId { get; set; }

        public int? OrderReviewId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(OrderReviewId))]
        public OrderReview OrderReview { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}

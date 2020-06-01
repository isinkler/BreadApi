using System.Collections.Generic;

namespace Bread.DataTransfer
{
    public class Order
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public int PaymentType { get; set; }

        public double Price { get; set; }

        public int UserId { get; set; }

        public int? OrderReviewId { get; set; }

        public User User { get; set; }

        public OrderReview OrderReview { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}

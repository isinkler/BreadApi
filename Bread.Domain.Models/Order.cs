using Bread.Common.Enumerations;

using System.Collections.Generic;

namespace Bread.Domain.Models
{
    public class Order : BreadDomainModel
    {
        public OrderStatus Status { get; set; }

        public int PaymentType { get; set; }

        public double Price { get; set; }

        public int UserId { get; set; }

        public int? OrderReviewId { get; set; }
        
        public User User { get; set; }
        
        public OrderReview OrderReview { get; set; }

        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}

using Bread.Common.Enumerations;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bread.DataTransfer
{
    public class Order : BreadDataTransfer
    {
        public OrderStatus Status { get; set; }
        
        public int PaymentType { get; set; }

        public double Price { get; set; }

        [Required]
        public int UserId { get; set; }

        public int? OrderReviewId { get; set; }

        public User User { get; set; }

        public OrderReview OrderReview { get; set; }

        [Required]
        [MinLength(1)]
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}

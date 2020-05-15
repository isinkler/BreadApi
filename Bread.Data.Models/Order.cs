using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int Status { get; set; }

        public int PaymentType { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}

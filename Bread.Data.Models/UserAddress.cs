using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class UserAddress
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int AddressId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class User : BreadDataModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Phone]
        public string Phone { get; set; }

        public int? RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }

        public ICollection<Order> Orders { get; set; }        

        public ICollection<RedeemedVoucher> RedeemedVouchers  { get; set; }
    }
}

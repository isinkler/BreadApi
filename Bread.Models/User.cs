using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bread.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Phone]
        public string Phone { get; set; }

        public List<Order> Orders { get; set; }
    }
}

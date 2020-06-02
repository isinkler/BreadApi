using System.ComponentModel.DataAnnotations;

namespace Bread.DataTransfer
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string EmailAddress { get; set; }

        public string Password { get; set; }
        
        public string Phone { get; set; }
    }
}

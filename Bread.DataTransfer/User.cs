using System.ComponentModel.DataAnnotations;

namespace Bread.DataTransfer
{
    public class User : BreadDataTransfer
    {
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

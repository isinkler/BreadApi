using System.ComponentModel.DataAnnotations;

namespace Bread.DataTransfer
{
    public class Authentication
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

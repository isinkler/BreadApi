using System.ComponentModel.DataAnnotations;

namespace Bread.DataTransfer
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

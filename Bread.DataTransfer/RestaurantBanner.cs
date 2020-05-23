using System.ComponentModel.DataAnnotations;

namespace Bread.DataTransfer
{
    public class RestaurantBanner
    {
        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public byte[] Banner { get; set; }
    }
}

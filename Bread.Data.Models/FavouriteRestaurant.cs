using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class FavouriteRestaurant
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int RestaurantId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }
    }
}

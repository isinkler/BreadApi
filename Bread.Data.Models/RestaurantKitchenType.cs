using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class RestaurantKitchenType
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public int KitchenTypeId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }

        [ForeignKey(nameof(KitchenTypeId))]
        public KitchenType KitchenType { get; set; }
    }
}

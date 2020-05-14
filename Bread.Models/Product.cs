using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public double Price { get; set; }

        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public Restaurant Restaurant { get; set; }
    }
}

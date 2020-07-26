using System.Collections.Generic;

namespace Bread.Domain.Models
{
    public class Product : BreadDomainModel
    {                
        public string Name { get; set; }

        public double Price { get; set; }

        public string ImagePath { get; set; }

        public int RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }

        public ICollection<Topping> Toppings { get; set; }
    }
}

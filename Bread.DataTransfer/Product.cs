using System.Collections.Generic;

namespace Bread.DataTransfer
{ 
    public class Product : BreadDataTransfer
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }

        public ICollection<Topping> Toppings { get; set; }
    }
}

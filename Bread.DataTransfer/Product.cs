using System.Collections.Generic;

namespace Bread.DataTransfer
{ 
    public class Product
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public double Price { get; set; }

        public int RestaurantId { get; set; }
        
        public Restaurant Restaurant { get; set; }

        public ICollection<Topping> Toppings { get; set; }
    }
}

namespace Bread.Domain.Models
{
    public class Topping
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }
        
        public Product Product { get; set; }
    }
}

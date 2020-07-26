using System.Collections.Generic;

namespace Bread.Domain.Models
{
    public class Restaurant : BreadDomainModel
    {       
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

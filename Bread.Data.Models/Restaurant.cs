using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bread.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int PriceCategory { get; set; }

        public string BannerPath { get; set; }

        [Required]
        public TimeSpan OpenFrom { get; set; }

        [Required]
        public TimeSpan OpenTo { get; set; }

        public int? AddressId { get; set; }

        public int ManagerId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }

        [ForeignKey(nameof(ManagerId))]
        public User Manager { get; set; }

        public ICollection<Product> Products { get; set; }

        public ICollection<RestaurantKitchenType> KitchenTypes { get; set; }
    }
}

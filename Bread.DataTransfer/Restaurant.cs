﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bread.DataTransfer
{
    public class Restaurant : BreadDataTransfer
    {
        [Required]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

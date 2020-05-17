﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Bread.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int PriceCategory { get; set; }

        public TimeSpan OpenFrom { get; set; }

        public TimeSpan OpenTo { get; set; }
    }
}
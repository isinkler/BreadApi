﻿namespace Bread.Domain.Models
{
    public class User : BreadDomainModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }
}

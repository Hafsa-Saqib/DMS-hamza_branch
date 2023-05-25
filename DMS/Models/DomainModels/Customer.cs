﻿using System.Reflection.Metadata;

namespace DMS.Models.DomainModels
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string CustomerCategory { get; set; }
        public string NTN { get; set; }
        public string CompNo { get; set; }

    }
}

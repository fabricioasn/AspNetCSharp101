using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityContorsoPets.Models
{
    public class Customer
    {
#nullable enable
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string email { get; set; }
#nullable disable
        public ICollection<Order> Orders { get; set; }
    }
}

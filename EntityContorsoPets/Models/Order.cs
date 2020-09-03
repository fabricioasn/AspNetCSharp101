using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityContorsoPets.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public DateTime? OrderFufilled { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }
    }
}

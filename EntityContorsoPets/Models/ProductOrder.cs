using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Text;

namespace EntityContorsoPets.Models
{
    public class ProductOrder
    {
        [Key]
        public int ProductOrderId { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityContorsoPets.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string name { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal price { get; set; }


    }
}

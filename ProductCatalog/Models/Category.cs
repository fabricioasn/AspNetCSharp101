using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProductCatalog.Models
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }

        [Required]
        public string Title { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

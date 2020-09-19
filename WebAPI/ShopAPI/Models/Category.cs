using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("Category")]
    public class Category
    {

        [Key]
        [Column("cat_ID")]
        public int Id { get; set; }

        /*business logic wich applies the string field 'Title' an length renge(max,min) 
         * and qualfies it as required content*/
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage ="Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [DataType("varchar(100)")]
        public string Title { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

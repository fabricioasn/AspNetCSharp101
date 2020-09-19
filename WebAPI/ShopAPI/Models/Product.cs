using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("prod_ID")]
        public int ID { get; set; }
        /*business logic wich applies the string field 'Title' an length renge(max,min) 
        * and qualfies it as required content*/
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        [DataType("varchar(120)")]
        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter entre 3 e 60 caractere.")]
        [DataType("varchar(200)")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage ="O preço deve ser maior que zero!")]  
        [DataType("Money")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria Inválida!")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }


    }
}

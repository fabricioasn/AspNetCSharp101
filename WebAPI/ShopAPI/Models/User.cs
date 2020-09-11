﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        /*business logic wich applies the string field 'Username' an length renge(max,min) 
        * and qualfies it as required content*/
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]

        public string Password { get; set; }
        public string Role { get; set; }

    }
}
